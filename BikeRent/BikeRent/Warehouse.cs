using System;
using System.Collections.Generic;
namespace BikeRent
{
    // Warehouse é um singleton, tem como objetivos fornecer objetos a todas as lojas
    public class Warehouse
    {
        private static readonly Warehouse mInstance = new Warehouse();

        const int mBikeStockSize = 100;
        private static List<Bike> mAvaibleBikes = new List<Bike>();
        private static List<Bike> mBikesOnStores = new List<Bike>();

        static Warehouse() {
            for (int i = 1; i <= mBikeStockSize; i++)
            {
                mAvaibleBikes.Add(new Bike());
            }
        }

        private Warehouse()
        {
        }

        public static Warehouse getInstance()
        {
            return mInstance;
        }

        // Enviar bicicletas para loja
        public Bike RequestBike()
            {
                lock (mAvaibleBikes)
                {
                    if (mAvaibleBikes.Count != 0)
                    {
                        Bike bike = mAvaibleBikes[0];
                        mBikesOnStores.Add(bike);
                        mAvaibleBikes.RemoveAt(0);
                        Console.WriteLine("Armazem entregou bike:" + bike.mId);
                    return bike;
                    }
                    else
                    {
                        Console.WriteLine("O armazem não tem bicicletas disponiveis");
                        return null;
                        //throw new InvalidOperationException("No guns are available");
                }
            }
            }

        //Bicicleta retornada ao armazem
        public void BikeReturn(Bike aBike)
        {
            lock (mAvaibleBikes)
            {
                // Colocar objeto na lista dos objetos disponiveis
                mAvaibleBikes.Add(aBike);
                //remover objeto da lista dos usados
                mBikesOnStores.Remove(aBike);
            }
        }

        public void WarehouseStock()
        {
            Console.WriteLine("---------------WSTOCK--------------");
            Console.WriteLine(mAvaibleBikes.Count);
            Console.WriteLine("---------------EWSTOCK-------------");
        }
        }
    }
