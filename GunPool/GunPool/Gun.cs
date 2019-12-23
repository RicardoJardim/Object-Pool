using System;
namespace GunPool
{
    // Objeto que irá ser guardado na pool
    public class Gun
    {
        
        public Gun(string aName, int aId)
        {
            this.mName = aName;
            this.mId = aId;
        }

        public string mName { get; private set; }
        public int mId { get; private set; }


    }
}
