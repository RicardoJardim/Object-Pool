using System;
using System.Collections.Generic;
namespace GunPool
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Instanciar 3 soldados
            Soldier soldier1 = new Soldier("João","Sniper");
            Soldier soldier2 = new Soldier("Manuel", "AR");
            Soldier soldier3 = new Soldier("Leonardo", "AR");
            // 3 soldados vão buscar objetos à pool
            soldier1.getGun();
            soldier2.getGun();
            // Como a pool só tem 2 objetos, este não consegue retirar o objeto
            soldier3.getGun();

            // Escreve na consola os objetos disponiveis e e os que estão a ser utilizados 
            Console.WriteLine("---------------ARMORY---------------");
            GunShowcase.AvailableGuns();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("---------------USEDGUNS-------------");
            GunShowcase.UsedGuns();
            Console.WriteLine("------------------------------------");

            // Soldado 1 devolve objeto
            soldier1.returnGun();

            // Escreve na consola os objetos disponiveis e e os que estão a ser utilizados 
            Console.WriteLine("---------------ARMORY---------------");
            GunShowcase.AvailableGuns();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("---------------USEDGUNS-------------");
            GunShowcase.UsedGuns();
            Console.WriteLine("------------------------------------");
        }
    }
}
