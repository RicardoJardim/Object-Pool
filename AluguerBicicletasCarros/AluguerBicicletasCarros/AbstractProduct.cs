using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguerBicicletasCarros
{
    //INTERFACE PARA OS OBJETOS EXISTENTES NA LOJA, 
    //COM APENAS ATRIBUTOS GERAIS
    public class IObject
    {
        public DateTime CreatedAt
        {
            get { return DateTime.Now; }
        }

        public string Type { get; set; }

        public int Price { get; set; }

        public static int ID { get; set; } = 0;
        public int GetID { get; set; }

        public IObject()
        {
            ID++;
        }
    }
}
