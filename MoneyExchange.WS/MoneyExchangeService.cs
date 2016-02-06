using System.ServiceProcess;
using System.Threading;

namespace MoneyExchange.WS
{
    public partial class MoneyExchangeService : ServiceBase
    {
        public MoneyExchangeService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            while (true)
            {
                DataBaseObserver.Start();
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
