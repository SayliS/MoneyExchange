using System.ServiceProcess;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace MoneyExchange.WS
{
    public partial class MoneyExchangeService : ServiceBase
    {
        readonly IWindsorContainer container;

        public MoneyExchangeService()
        {
            InitializeComponent();
            container = new WindsorContainer();
            container.Install(FromAssembly.This());

        }

        protected override void OnStart(string[] args)
        {
            DataBaseObserver.Start(container);
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
