using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using log4net;
using log4net.Config;

namespace Bankomat
{
    class Program
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Casseteloader));
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            
            bankomat bank = new bankomat();

            bank.input("text.txt");
            
            List<Money> mon = new List<Money>();
            bank.output(50000, mon);
            bank.show_all_money();   
        }
    }
}

