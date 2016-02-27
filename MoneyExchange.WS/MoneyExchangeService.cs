using System.Configuration;
using System.ServiceProcess;
using System.Threading;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace MoneyExchange.WS
{
    public partial class MoneyExchangeService : ServiceBase
    {
        readonly IWindsorContainer container;
        readonly int updateTime = int.Parse(ConfigurationManager.AppSettings.Get("ExecutionSleepIntervalInSeconds")) * 1000;

        public MoneyExchangeService()
        {
            InitializeComponent();
            container = new WindsorContainer();
            container.Install(FromAssembly.This());

        }

        protected override void OnStart(string[] args)
        {
            while (true)
            {
                DataBaseObserver.Start(container);
                Thread.Sleep(updateTime);
            }
        }

        protected override void OnStop()
        {
            DataBaseObserver.Stop();
        }

        public void Debug()
        {
            OnStart(null);
        }
    }
}
