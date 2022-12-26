using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitasovASP.Data.Models
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<Brick>();
        }
        public List<Brick> CartLines { get; set; }

        public double FinalPrice
        {
            get
            {
                double sum = 0;
                foreach(Brick brick in CartLines)
                {
                    sum += brick.Price;
                }
                return sum;
            }
        }
    }
}
