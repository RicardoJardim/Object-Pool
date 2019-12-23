using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguerBicicletasCarros
{
    //CLASSE BICICLETA
    public class Bicicleta : IObject
    {
       
        public Bicicleta(int price = 100)
        {
            Price = price;
            Type = "Fast";
            GetID = ID;
        }

    }
}
