using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskThread2
{
    public class Product
    {
        public Product(uint productId, ProductType type, string name)
        {
            ProductId = productId;
            Type = type;
            Name = name;
        }

        public uint ProductId { get; private set; }
        public ProductType Type { get; private set; }
        public string Name { get; private set; }
    }

}
