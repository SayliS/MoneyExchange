using System.ServiceProcess;
using System.Threading;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace MoneyExchange.WS
{
    public partial class MoneyExchangeService : ServiceBase
    {
        IWindsorContainer container;

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
                Thread.Sleep(1000 * 5);
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
