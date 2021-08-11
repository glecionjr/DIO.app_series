
using System.Collections.Generic;

namespace DIO.AppSeries.Repositorio
{
    public interface IRepositorio <T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere (T serie);
        void Exclui(int id);
        void Atualiza(int id, T serie);
        int ProximoId();
    }
}