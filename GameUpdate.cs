using System.Net;

namespace _15shkiNew
{
    internal class GameUpdate
    {
        private MainApp app;

        public GameUpdate( ref MainApp mainApp )
        {
            app = mainApp;
        }

        private void Update ()
        {
            app.manager.Show();
        }
    }
}
