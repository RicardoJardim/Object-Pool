using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguerBicicletasCarros
{
    //STOCK DAS BICICLETAS
    public sealed class StockBikeLoja : ILoja
    {
        //LISTA DE ELEMENTOS DISPONIVEIS
        private static List<IObject> mDisponiveis = new List<IObject>();

        //LISTA DE ELEMENTOS EM UTILIZAÇÃO
        private static List<IObject> mEmUso = new List<IObject>();

        private static int counter = 0;
        private static int MaxTotalObjetos;

        //APLICAÇÃO DO SINGLETON <- APENAS É NECESSÁRIO 1 POOL PARA CADA TIPO DE OBJETOS
        static StockBikeLoja instance = new StockBikeLoja();

        static StockBikeLoja()
        {
        }
        private StockBikeLoja() { }

        public static StockBikeLoja Instance
        {
            get { return instance; }
        }


        //ADQUIRIR UM ELEMENTO DA POOL, CASO EXISTA RETIRA-O DA LISTA DE DISPONIVEIS,
        //CASO NAO TENHA INSTANCIA UM
        public IObject AdquirirReutilizavel()
        {
            lock (mDisponiveis)
            {
                Console.WriteLine(mDisponiveis.Count);

                if (mDisponiveis.Count != 0 && mDisponiveis.Count <= MaxTotalObjetos)
                {
                    IObject item = mDisponiveis[0];
                    mEmUso.Add(item);
                    mDisponiveis.RemoveAt(0);
                    counter--;
                    Console.WriteLine("Alugou uma bicicleta com o numero : " + item.GetID + ". Preço de: " + item.Price + "€\n");
                    return item;
                }
                else
                {

                    IObject obj = new Bicicleta();
                    mEmUso.Add(obj);
                    Console.WriteLine("Aumento da quantidade de objetos com o objeto: " + obj.GetType().Name + " com o numero " + obj.GetID + "\n");
                    return obj;
                }
            }
        }

        //DEVOLUÇÃO UM ELEMENTO DA POOL, CASO A LISTA CONTENHA O LIMITE DE ELEMENTOS, AVISA QUE ESTÁ CHEIA PARA DEVOLUÇÃO
        public void DevolverReutilizavel(IObject item)
        {
            lock (mDisponiveis)
            {
                if (counter < MaxTotalObjetos)
                {
                    Console.WriteLine("Devolução do objeto: " + item.GetType().Name + " com o numero " + item.GetID + "\n");
                    mDisponiveis.Add(item);
                    counter++;
                    mEmUso.Remove(item);
                }
                else
                {
                    Console.WriteLine("Nao é possivel devolver o carro, armazem está cheio!");
                }
            }
        }

        //DEFINE O NUMERO MAXIMO DE ELEMENTO DA POOL
        public void SetMaxPoolSize(int settingPoolSize)
        {
            MaxTotalObjetos = settingPoolSize;
        }

        public void FillDisponiveis()
        {
            for (var x = 0; x < MaxTotalObjetos; x++)
            {
                mDisponiveis.Add(new Bicicleta());
            }
        }
    }
}
