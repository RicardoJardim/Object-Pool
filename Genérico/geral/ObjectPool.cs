using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geral
{
    //CLASSE DA POOL GENERALIZADA QUE IRA RECEBER UM GENÉRICO
    public sealed class ObjectPool<T> where T : new()
    {
        //LISTA DE ELEMENTOS DISPONIVEIS
        private static List<T> mDisponiveis = new List<T>();

        //LISTA DE ELEMENTOS EM UTILIZAÇÃO
        private static List<T> mEmUso = new List<T>();

        private static int counter = 0;
        private static int MaxTotalObjetos;

        //APLICAÇÃO DO SINGLETON <- APENAS É NECESSÁRIO 1 POOL PARA CADA TIPO DE OBJETOS
        static ObjectPool<T> instance = new ObjectPool<T>();

        static ObjectPool(){ }
        private ObjectPool() { }

        public static ObjectPool<T> Instance
        {
            get { return instance; }
        }


        //ADQUIRIR UM ELEMENTO DA POOL, CASO EXISTA RETIRA-O DA LISTA DE DISPONIVEIS,
        //CASO NAO TENHA INSTANCIA UM
        public T AdquirirReutilizavel()
        {
            lock (mDisponiveis)
            {
                if (mDisponiveis.Count != 0 && mDisponiveis.Count < 10)
                {
                    T item = mDisponiveis[0];
                    mEmUso.Add(item);
                    mDisponiveis.RemoveAt(0);
                    counter--;
                    Console.WriteLine("Necessidade do objeto: " + typeof(T) + "\n");
                    return item;
                }
                else
                {
                    
                    T obj = new T();
                    mEmUso.Add(obj);
                    Console.WriteLine("Criação do objeto: "+typeof(T) + "\n");
                    return obj;
                }
            }
        }

        //DEVOLUÇÃO UM ELEMENTO DA POOL, CASO A LISTA CONTENHA O LIMITE DE ELEMENTOS, AVISA QUE ESTÁ CHEIA PARA DEVOLUÇÃO
        public void DevolverReutilizavel(T item)
        {
            lock (mDisponiveis)
            {
                if (counter < MaxTotalObjetos)
                {
                    Console.WriteLine("Devolução do objeto: " + typeof(T) + "\n");
                    mDisponiveis.Add(item);
                    counter++;
                    mEmUso.Remove(item);
                }
                else
                {
                    Console.WriteLine("Pool está cheia!");
                }
            }
        }

        //DEFINE O NUMERO MAXIMO DE ELEMENTO DA POOL
        public void SetMaxPoolSize(int settingPoolSize)
        {
            MaxTotalObjetos = settingPoolSize;
        }
    }
    
}
