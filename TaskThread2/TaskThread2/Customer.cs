using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskThread2
{
    public class Customer
    {
        public Customer(uint id, string name, string region)
        {
            Id = id;
            Name = name;
            Region = region;
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
    }

}
