namespace MoneyExchange.WS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

#if DEBUG
            //HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            var service = new MoneyExchangeService();
            service.Debug();

            //Thread.Sleep(5000);
            //service.Stop();
#else
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
            log4net.Config.XmlConfigurator.Configure();
            log.Info($"Starting {nameof(Program)}");
            System.ServiceProcess.ServiceBase[] ServicesToRun;
            ServicesToRun = new System.ServiceProcess.ServiceBase[] { new MoneyExchangeService() };
            System.ServiceProcess.ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
