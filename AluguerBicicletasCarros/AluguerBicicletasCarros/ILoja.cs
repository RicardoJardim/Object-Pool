using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguerBicicletasCarros
{
    //INTERFACE PARA A LOJA, QUE IRA CONTER VARIAS POOLS
    public interface ILoja
    {
      
        IObject AdquirirReutilizavel();
        void DevolverReutilizavel(IObject item);
        void SetMaxPoolSize(int settingPoolSize);
        void FillDisponiveis();
    }
}
