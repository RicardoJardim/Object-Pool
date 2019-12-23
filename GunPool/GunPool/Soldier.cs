using System;
namespace GunPool
{
    public class Soldier
    {
        static int NumberOfSoldier;
        private int mId;
        private Gun mSoldierGun;
        


        public Soldier(string aName, string aEspeciality)
        {
            mId = NumberOfSoldier;
            NumberOfSoldier++;
            mName = aName;
            mEspeciality = aEspeciality;
            
        }

        public string mName { get; private set; }
        public string mEspeciality { get; private set; }

        public void getGun()
        {
            mSoldierGun = GunShowcase.GetGun();
        }

        public void returnGun()
        {
            GunShowcase.ReleaseGun(mSoldierGun);
            mSoldierGun = null;  
        }
    }
}
