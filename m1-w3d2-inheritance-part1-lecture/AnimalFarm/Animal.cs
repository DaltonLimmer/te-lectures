using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFarm
{
    public class Animal
    {
        public virtual bool IsWarmBlooded()
        {
            return true;
        }

        public string Body { get; set; }

        public void Eat(string food)
        {
            
        }

        protected string Reproduce(bool isGirl)
        {
            string result = "Boy";
            if (isGirl)
            {
                result = "Girl";
            }
            return result;
        }
    }
}
