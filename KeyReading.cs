using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15shkiNew
{
    internal class KeyReading
    {
        private int ReadKey()
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey(true);
            return key.KeyChar;
        }

        public Enum PressKey()
        {
            switch (ReadKey())
            {
                case 1:
                    return StartMenu.start;
                case 2:
                    return StartMenu.score;
                case 3:
                    return StartMenu.credits;
                case 0:
                    return StartMenu.exit;
                default:
                    return StartMenu.exit;

            }
        }


        enum StartMenu
        {
            start,
            score,
            credits,
            exit
        }
    }
}
