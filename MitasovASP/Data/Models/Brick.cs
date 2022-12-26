using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MitasovASP.Data.Models
{
    public class Brick
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Color { set; get; }
        public string Image { set; get; }
        public bool WithHoles { set; get; }
        public bool Ribbed { set; get; }
        public double Price { set; get; }
    }
}
