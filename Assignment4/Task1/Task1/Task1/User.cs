﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class User
    {
        static int Count = 0;

        public User()
        {
            Count++;
        }

        public int Display()
        {
            return Count;
        }

    }
}
