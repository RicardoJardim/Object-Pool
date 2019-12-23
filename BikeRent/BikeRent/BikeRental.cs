using System;
using System.Collections.Generic;

namespace BikeRent
{
    public class BikeRental
    {
        const int mBikeStockSize = 5;
        private  List<Bike> mAvaibleBikesRent = new List<Bike>();
        private  List<Bike> mRentedBikes = new List<Bike>();
        Warehouse mWarehouse = Warehouse.getInstance();

        public BikeRental()
        {
            // Quando é criada uma loja o armazem fornece 5 bicicletas
            for (int i = 1; i<= mBikeStockSize; i++)
            {
                mAvaibleBikesRent.Add(mWarehouse.RequestBike());
            }
        }

        //Alugar bicicletas
        public Bike Rent() 
        {
            lock (mAvaibleBikesRent)
            {
                //Verifica se tem bicicleta no stock da loja se tiver aluga
                if (mAvaibleBikesRent.Count != 0)
                {
                    Bike bike = mAvaibleBikesRent[0];
                    mRentedBikes.Add(bike);
                    mAvaibleBikesRent.RemoveAt(0);
                    return bike;
                }
                // caso não tenha pede ao armazem 
                else
                {
                    Console.WriteLine("A loja não tem bicicletas mas vai verificar se tem disponioveis no armazem");
                    Bike bike= mWarehouse.RequestBike();
                    if(bike != null)
                    {
                        mRentedBikes.Add(bike);
                    }
                    return bike;
                }
            }
        }


        // Devolução de bicicleta à loja
        public void BikeReturn(Bike aBike)
        {
            lock (mAvaibleBikesRent)
            {
                mRentedBikes.Remove(aBike);

                // verifica se a loja tem espaco para a bicicleta se tive guarda caso contrario devolve ao armazem
                if (mAvaibleBikesRent.Count >= mBikeStockSize)
                {
                    Console.WriteLine("bicicleta:" + aBike.mId + " devolvida ao armazem");
                    mWarehouse.BikeReturn(aBike);
                }
                else
                {
                    Console.WriteLine("bicicleta:" + aBike.mId + " devolvida à loja");
                    mAvaibleBikesRent.Add(aBike);
                }
            }
        }
    }
}
