using System;
namespace BikeRent
{
    public class Bike
    {
        private static int mBikeNumber;

        public Bike()
        {
            mId = mBikeNumber;
            mBikeNumber++;
        }

        public int mId { get; private set; }
    }
}
