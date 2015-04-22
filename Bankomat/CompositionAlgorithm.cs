using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Bankomat
{
    class CompositionAlgorithm
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(CompositionAlgorithm));
        List<Money> outMoney = new List<Money>();
        
        public State1 st;
        public CompositionAlgorithm(int output, List<Money> mom)
        {
            if (mom.Count == 0) { st = State1.NoMoney; log.Error("Exception " + st.ToString() + "\n"); return; }            
            StringBuilder str = new StringBuilder();
            int remain = 0;
            int count = 0;
            foreach (Money c in mom) 
            {
                remain = output - count;
                if (remain > 0 && remain / c.val != 0 && c.count != 0)
                {
                    int b = c.count; 
                    if (c.count > remain / c.val)
                        b = remain / c.val;
                    outMoney.Add(new Money(c.val, b));
                    count += c.val * b;
                     
                }
            }
            if (output == count)
            {
                st = State1.AllOk; log.Info(st.ToString() + "\n");
            }
            else { st = State1.Error; outMoney.Clear(); log.Error("Exception " + st.ToString() + "\n"); }
        }

        public List<Money> ToOut()
        {
            return outMoney;
        }
    }
}
