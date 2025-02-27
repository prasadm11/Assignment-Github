using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4t1
{
     public class User
    {
        static int count = 0;

        public User()
        {
            count++;
        }

        public int display()
        {
            return count;
        }




    }
}
