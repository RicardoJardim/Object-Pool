using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geral
{
    //Elemento 2
    class Objeto2
    {
        //Numero de elementos
        public static int ElementsCreated { get; set; } = 0;
        
        public string State { get; set; }

        public Objeto2()
        {
            ElementsCreated++;
            State = "Ola";
        }

        public DateTime CreatedAt
        {
            get { return DateTime.Now; }
        }
        
    }
}
