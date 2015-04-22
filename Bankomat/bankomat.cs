using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    class bankomat
    {
        List<Money> _kol = new List<Money>();
        public void input(string box)
        {
            Casseteloader cs = new Casseteloader(box);
            if (cs.st == State2.AllOK)
            {
                _kol = cs.ToLoadCassete();
            }
            else { Console.WriteLine(cs.st); }
        }

        public void show_all_money()
        {
            foreach (Money mon in _kol)
            { Console.WriteLine(mon.val + ":" + mon.count); }
        }
        
        public void output(int finite_sum, List<Money> mon)
        {
            
            CompositionAlgorithm ca = new CompositionAlgorithm(finite_sum, _kol);
            if (ca.st == State1.AllOk)
            {
               mon = ca.ToOut();
               asd(mon);
 
               
               foreach (Money m in mon)
               {
                   Console.WriteLine(m.val + ":" + m.count);
               }
               Console.WriteLine("Succes Operation!");

            }
            else {Console.WriteLine(ca.st);}
        }
        void asd(List<Money> mon)
        {
            int index;
            foreach (Money n in mon)
            {
                index = _kol.FindIndex(l => l.val == n.val);
                _kol[index].count -= n.count;
            }
 
        }
        
    }
}
