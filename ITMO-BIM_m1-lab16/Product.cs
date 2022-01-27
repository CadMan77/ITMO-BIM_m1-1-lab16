using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Product
    {
        int code;
        string name;
        decimal price;

        public int Code
        {
            get => code;
            set
            {
                if (value > 0)
                    this.code = value;
            }
        }

        public string Name
        {
            get => name;
            set => name = value;            
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (value > 0)
                    this.price = value;
            }
        }
    }
}
