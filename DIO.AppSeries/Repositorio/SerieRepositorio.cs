using System.Collections.Generic;
using DIO.AppSeries.Entities;

namespace DIO.AppSeries.Repositorio
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> lista = new List<Serie>();

        public void Atualiza(int id, Serie serie)
        {
            lista[id] = serie;
        }

        public void Exclui(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insere(Serie serie)
        {
            lista.Add(serie);
        }

        public List<Serie> Lista()
        {
            if (lista.Count == 0)
                throw new DomainException("Não há séries cadastradas");
                
            return lista;
        }

        public int ProximoId()
        {
            return lista.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return lista[id];
        }
    }
}