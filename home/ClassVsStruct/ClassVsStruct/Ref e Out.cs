using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassVsStruct
{
    public class Ref_e_Out
    {
        public void AlterarRef(ref int a)
        {
            a += 1000;
        }

        public void AlterarOut(out int b)
        {
            b = 1000;
            b += 15;
        }
    }
}
