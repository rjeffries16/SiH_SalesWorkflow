using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoAPICaller
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime lastRunTime = DateTime.UtcNow.AddDays(-1);

            for (; ;)
            {

                DateTime localTime = DateTime.UtcNow.AddHours(-7);
                if (lastRunTime.AddHours(23) < DateTime.UtcNow && localTime.Hour == 3)
                {
                    ZohoReportsAPI.ImportZohoData();
                     lastRunTime = DateTime.UtcNow;
                    Console.WriteLine("Last Run = " + localTime.ToShortDateString() + " " + localTime.ToShortTimeString());

                }
                Console.WriteLine("Checked At = " + localTime.ToShortDateString() + " " + localTime.ToShortTimeString() + " PDT");
                System.Threading.Thread.Sleep(1000 * 60 * 30);//run every 30 min
            }
            
            //Console.Write(result);
        }

    }
}
