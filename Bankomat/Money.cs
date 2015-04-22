using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    class Money
    {
        public Money(int val, int count)
        {
            this.val = val;
            this.count = count;
        }
        public int val;
        public int count;
    }
}
