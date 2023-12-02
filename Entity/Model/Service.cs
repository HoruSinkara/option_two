using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace option_two.Entity.Model
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration  { get; set; }
        public decimal Cost { get; set; }
        public int Sale { get; set; }

        public override string ToString()
        {
            return $@"{Id}, {Name}, {Duration}, {Cost.ToString().Substring(0, Cost.ToString().Length-3)}, {Sale}";
        }
    }

}
