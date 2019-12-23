using System;
using System.Collections.Generic;
namespace GunPool
{
    public class GunShowcase
    {
        // Quantidade de objetos que estão disponiveis na pool
        const int mSize = 2;

        // Listas que guardam os objetos que estão na pool e os que estão a ser utilizados
        private static List<Gun> mAvailable = new List<Gun>();
        private static List<Gun> mInUse = new List<Gun>();

         static GunShowcase()
        {
            //Criação de objetos para colocar na pool
            for(int i = 1; i <= mSize; i++)
            {
                mAvailable.Add(new Gun("G36-"+i, i));
            }
        }


        //Retirar objetos da pool
        public static Gun GetGun()
        {
            lock (mAvailable)
            {
                if (mAvailable.Count != 0)
                {
                    Gun gun = mAvailable[0];
                    // Passar o objeto para a lista de objetos a ser utilizados
                    mInUse.Add(gun);
                    // Remover objeto da lista dos disponiveis 
                    mAvailable.RemoveAt(0);
                    Console.WriteLine("Soldier have a Gun  \n name: "+gun.mName+" \n id: "+gun.mId);
                    //retornar um objeto 
                    return gun;
                }
                else
                {
                    // Mensagem de erro, que idealmente seria uma exepcion que iruia ser tratada
                    Console.WriteLine("No Guns avaible");
                    return null;
                    //throw new InvalidOperationException("No guns are available");
                }
            }
        }

        // Devolver objeto à pool
        public static void ReleaseGun(Gun gun)
        {
            // Uma função que tem de ser feita antes da devolução do objeto,
            //não é obrigatório mas para este exemplo serve xD
            Clean(gun);

            lock (mAvailable)
            {
                // Colocar objeto na lista dos objetos disponiveis
                mAvailable.Add(gun);
                //remover objeto da lista dos usados
                mInUse.Remove(gun);
                Console.WriteLine("Gun Return");
            }

        }

        
        private static void Clean(Gun gun)
        {
            Console.WriteLine("Cleaning Gun with id: "+gun.mId);
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Gun Clean");
        }

        // Apenas mostra objetos disponiveis
        public static void AvailableGuns()
        {
            foreach(Gun gun in mAvailable)
            {
                Console.WriteLine(gun.mName+"\n");
            }
        }

        // Apenas mostra objetos a ser utilizados
        public static void UsedGuns()
        {
            foreach (Gun gun in mInUse)
            {
                Console.WriteLine(gun.mName + "\n");
            }
        }
    }
}
