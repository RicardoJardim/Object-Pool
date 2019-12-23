using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguerBicicletasCarros
{
    //CLASSE CARRO
    public class Carro :IObject
    {
    
        public Carro(int price = 200)
        {
            Price = price;
            Type = "Normal";
            GetID = ID;
        }
    }
}
