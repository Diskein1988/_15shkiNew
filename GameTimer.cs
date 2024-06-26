using System.Timers;

namespace _15shkiNew
{
    internal class GameTimer
    {
        private static GameTimer? instance;
        private static System.Timers.Timer aTimer;
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

        }

        public void Start()
        {
            aTimer = new System.Timers.Timer( );
            aTimer.Interval = interval;
            aTimer.Elapsed += ShowTwst;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

        }
        public void Stop()
        {
            aTimer.Stop();
            aTimer.Dispose();
        }

        private void ShowTwst( Object source, ElapsedEventArgs e )
        {
            if ( counter <= 10 )
            {
            Console.WriteLine( "The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime );
                counter++;
            }
            else
            {
                counter = 0;
                Stop();
            }
        }



    }
}
