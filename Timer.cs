namespace _15shkiNew
{
    internal class Timer
    {
        private TimeSpan _timer = new TimeSpan(0,0,0,0,1000);
        private static Timer? instance;

        public PeriodicTimer periodicTimer;
        public Timer()
        {
            periodicTimer = new PeriodicTimer(_timer);
        }

        public void Start()
        {
            Console.WriteLine(periodicTimer.Period);
        }

        public static Timer GetInstance
        {
            get
            {
                instance ??= new Timer();
                return instance;
            }
        }
        
    }
}
