using System.Timers;

namespace _15shkiNew
{
    public delegate void MyDeleg (object sender, ElapsedEventArgs e);
    internal class GameTimer
    {
        
        private static GameTimer? instance;
        private System.Timers.Timer aTimer;
        private int counter = 0;
        private const int interval = 1000;
        public static GameTimer GetInstance
        {
            get
            {
                instance ??= new GameTimer();
                return instance;
            }
        }

        private GameTimer()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += ShowTwst;
            aTimer.Interval = interval;
            aTimer.AutoReset = true;
        }

        public void Start()
        {
            aTimer.Enabled = true;
        }
        public void Stop()
        {
            aTimer.Stop();
        }

        public void Update(Action action )
        {
            action();
        }

        private void ShowTwst( Object source, ElapsedEventArgs e)
        {
            
        }



    }
}
