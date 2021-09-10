using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public static class ValidateoneProducer
    {
        public static bool validate(string producer)
        {
            foreach(char ch in producer)
            {
                if(ch.Equals(' '))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
