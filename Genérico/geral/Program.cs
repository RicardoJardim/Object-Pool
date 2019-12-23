using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geral
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //INSTACIAÇÃO DA POOL 1 DE ELEMENTOS Objeto
            ObjectPool<Objeto> objPoolObject1 = ObjectPool<Objeto>.Instance;
            objPoolObject1.SetMaxPoolSize(10);
            
            //INSTACIAÇÃO DA POOL 2 DE ELEMENTOS Objeto2
            ObjectPool<Objeto2> objPoolObject2 = ObjectPool<Objeto2>.Instance;
            objPoolObject2.SetMaxPoolSize(10);

            Client cli = new Client(objPoolObject1, objPoolObject2);

            Objeto obj1;
            Objeto obj2;
            Objeto2 obj3;
            Objeto2 obj4;

            obj1 = cli.AdquirirObj();
            obj3 = cli.AdquirirObj2();
            cli.DevolverObj(obj1);
            obj1 = cli.AdquirirObj();
            Console.WriteLine("Cliente pergunta algo ao Objeto2 "+obj3.State);
            cli.DevolverObj2(obj3);
            cli.DevolverObj(obj1);
            obj4 = cli.AdquirirObj2();
            cli.DevolverObj2(obj4);
            Console.ReadLine();
        }
    }

    class Client
    {
        //ASSOCIAÇÃO COM AS POOL'S EXISTENTES
        private ObjectPool<Objeto> pool1;
        private ObjectPool<Objeto2> pool2;

        public Client(ObjectPool<Objeto> aPool1, ObjectPool<Objeto2> aPool2)
        {
            pool1 = aPool1;
            pool2 = aPool2;
        }

        //AQUISIÇÃO DE UM OBJETO
        public Objeto AdquirirObj()
        {
            var obj1 = pool1.AdquirirReutilizavel();
            Console.WriteLine("Data de utilização: " + obj1.CreatedAt);
            Console.WriteLine("----------------------------");
            return obj1;
        }

        //DEVOLUÇÃO DE UM OBJETO
        public void DevolverObj(Objeto obj)
        {
            pool1.DevolverReutilizavel(obj);
            Console.WriteLine("Data de utilização: " + obj.CreatedAt);

            Console.WriteLine("----------------------------");
        }

        //AQUISIÇÃO DE UM OBJETO2
        public Objeto2 AdquirirObj2()
        {
            var obj2 = pool2.AdquirirReutilizavel();
            Console.WriteLine("Data de utilização: " + obj2.CreatedAt);
            Console.WriteLine("----------------------------");
            return obj2;
        }

        //DEVOLUÇÃO DE UM OBJETO2
        public void DevolverObj2( Objeto2 obj)
        {
            pool2.DevolverReutilizavel(obj);
            Console.WriteLine("Data de utilização: " + obj.CreatedAt);
            Console.WriteLine("Quantos Objeto2 foram criados?: " + Objeto2.ElementsCreated);
            Console.WriteLine("----------------------------");
        }
    }
}
