using DIO.Series.Classes;
using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    internal interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        bool Excluir(int id);
        void Atualizar(int id, T entidade);
        int ProximoId();
    }
}
