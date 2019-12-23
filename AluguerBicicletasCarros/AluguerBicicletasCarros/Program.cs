using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguerBicicletasCarros
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoja bikeLoja = StockBikeLoja.Instance;
            bikeLoja.SetMaxPoolSize(10);
            bikeLoja.FillDisponiveis();

            //INSTACIAÇÃO DA POOL 2 DE ELEMENTOS Objeto2
            ILoja carLoja = StockCarLoja.Instance;
            carLoja.SetMaxPoolSize(10);
            carLoja.FillDisponiveis();

            Client cli = new Client(bikeLoja, carLoja);

            IObject obj1, obj2, obj3, obj4, obj5;


             obj1 = cli.Adquirir("bicicleta");
            
             obj2 = cli.Adquirir("bicicleta");

             obj3 = cli.Adquirir("bicicleta");

             obj4 = cli.Adquirir("carro");

             cli.Devolver(obj1);

            Console.ReadLine();
        }
    }
    class Client
    {
        //ASSOCIAÇÃO COM AS POOL'S EXISTENTES
        private ILoja pool1;
        private ILoja pool2;

        public Client(ILoja aPool1, ILoja aPool2)
        {
            pool1 = aPool1;
            pool2 = aPool2;
        }

        //AQUISIÇÃO DE UM OBJETO
        public IObject Adquirir(string aEscolha)
        {
            if (aEscolha == "bicicleta")
            {
                var obj1 = pool1.AdquirirReutilizavel();
                Console.WriteLine("Data de utilização: " + obj1.CreatedAt);
                Console.WriteLine("----------------------------");
                return obj1;
            }
            else if ( aEscolha == "carro")
            {
                var obj1 = pool2.AdquirirReutilizavel();
                Console.WriteLine("Data de utilização: " + obj1.CreatedAt);
                Console.WriteLine("----------------------------");
                return obj1;
            }
            else
            {
                Console.WriteLine("Item a adquirir nao existe na loja");
                return null;
            }

        }

        //DEVOLUÇÃO DE UM OBJETO
        public void Devolver(IObject obj)
        {
            if (obj is Bicicleta)
            {
                pool1.DevolverReutilizavel(obj);
                Console.WriteLine("Data de utilização: " + obj.CreatedAt);
                Console.WriteLine("----------------------------");
            }
            else if (obj is Carro)
            {
                pool2.DevolverReutilizavel(obj);
                Console.WriteLine("Data de utilização: " + obj.CreatedAt);
                Console.WriteLine("----------------------------");
            }
            else
            {
                Console.WriteLine("Item a devolver não é da loja");
            }
           
        }
    }
}
