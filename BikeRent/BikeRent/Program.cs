using System;
using System.Collections.Generic;
namespace BikeRent
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
            List<Client> mClients = new List<Client>();
            for(int i = 1; i<= 10; i++)
            {
                mClients.Add(new Client("Cliente" + i));
            }

            //Criação de 2 lojas
            BikeRental store1 = new BikeRental();
            BikeRental store2 = new BikeRental();

            // Clientes alugam bicicletas na loja 1
            foreach(Client client in mClients)
            {
                client.RentBike(store1);
            }


            Warehouse wh = Warehouse.getInstance();
            wh.WarehouseStock();

            // Clientes devolvem bicicletas na loja 2
            foreach (Client client in mClients)
            {
                client.ReturnBike(store2);
            }

            
            wh.WarehouseStock();

        }
    }
}
