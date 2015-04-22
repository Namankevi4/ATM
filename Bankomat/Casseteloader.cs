using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using log4net;

namespace Bankomat
{
    class Casseteloader
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(CompositionAlgorithm));
        List<Money> cassete = new List<Money>();
        
        public State2 st;
        public Casseteloader(string box)
        {
            string str;
            try
            {
                StreamReader sr = File.OpenText(box);
                while (!sr.EndOfStream)
                {
                    str = sr.ReadLine();
                    string[] arr = str.Split(' ');
                    cassete.Add(new Money(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1])));
                }
                st = State2.AllOK; log.Info(st.ToString() + "\n");
                cassete.Sort(delegate(Money cas1, Money cas2)
                {
                    return cas1.val.CompareTo(cas2.val);
                });
                cassete.Reverse();
            }
            catch (FileNotFoundException) { st = State2.NoCassete; log.Error("Exceptiom" + st.ToString() + "\n"); }
            
            
        }
        public List<Money> ToLoadCassete()
        {
            return cassete;
        }
    }
}
