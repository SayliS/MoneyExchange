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
            System.ServiceProcess.ServiceBase[] ServicesToRun;
            ServicesToRun = new System.ServiceProcess.ServiceBase[] { new Service1() };
            System.ServiceProcess.ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
