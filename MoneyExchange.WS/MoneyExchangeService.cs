using System.Configuration;
using System.ServiceProcess;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Quartz;
using Quartz.Impl;
using System.Threading;

namespace MoneyExchange.WS
{
    public partial class MoneyExchangeService : ServiceBase
    {
        readonly IWindsorContainer container;
        IScheduler scheduler;
        static readonly string cronSchedule = ConfigurationManager.AppSettings.Get("CronSchedule");
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(MoneyExchangeService));
        public MoneyExchangeService()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info($"Starting {nameof(MoneyExchangeService)}");
            InitializeComponent();
            container = new WindsorContainer();
            container.Install(FromAssembly.This());
            scheduler = StdSchedulerFactory.GetDefaultScheduler();
            log.Info($"----1----");

        }

        protected override void OnStart(string[] args)
        {
            log.Info($"----2start----");
            ThreadStart threadDelegate = new ThreadStart(gg);
            Thread newThread = new Thread(threadDelegate);
            newThread.Start();
        }

        protected override void OnStop()
        {
            scheduler.Shutdown();
            DataBaseObserver.Stop();
        }

        public void Debug()
        {
            OnStart(null);
        }

        void gg()
        {
            scheduler.Start();
            var jobDataMap = new JobDataMap();
            jobDataMap.Add("container", container);

            var job = JobBuilder.Create<DataBaseObserver>()
                    .WithIdentity("DataBaseObserver")
                    .UsingJobData(jobDataMap)
                    .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity("DataBaseObserver")
                .StartNow()
                // TODO ДА уточним това как ще е точно
                //http://www.quartz-scheduler.net/documentation/quartz-2.x/tutorial/crontriggers.html
                .WithCronSchedule(cronSchedule)
                .Build();
            scheduler.ScheduleJob(job, trigger);
        }
    }
}
