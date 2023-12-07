using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST1.Model
{
     public class Values
        {
            int x, y;
            public int X { get => x; set => x = value; }
            //ou
            public int Y { get { return y; } set { y = value; } }
        }
}
