using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskThread2
{
    public class ProductType
    {
        public ProductType(string name, uint id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; private set; }
        public uint Id { get; private set; }
    }

}
