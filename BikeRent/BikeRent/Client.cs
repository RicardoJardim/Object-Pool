using System;
namespace BikeRent
{
    public class Client
    {
        public string mName { get; private set; }
        private Bike mBike;

        public Client(string aName)
        {
            mName = aName;
        }

        public void RentBike(BikeRental aBikeRental)
        {
            if (mBike == null)
            {
                mBike = aBikeRental.Rent();
                Console.WriteLine("O " + mName + " alugou a bicicleta " + mBike.mId);
            }
            else
            {
                Console.WriteLine("Este Cliente ja tem uma bicicleta alugada!");
            }
        }

        public void ReturnBike(BikeRental aBikeRental)
        {
            Console.WriteLine("O " + mName + " devolveu a bicicleta " + mBike.mId);
            aBikeRental.BikeReturn(mBike);
            mBike = null;
        }


        
    }
}
