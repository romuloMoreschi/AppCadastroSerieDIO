using System.Linq;
using DIO.Series.Interfaces;
using System.Collections.Generic;

namespace DIO.Series.Classes
{
    internal class SerieRepositorio : IRepositorio<Serie>
    {
        private readonly List<Serie> listaSerie = new();
        public void Atualizar(int id, Serie entidade)
        {
            listaSerie[listaSerie.FindIndex(l => l.Id == id)] = entidade;
        }

        public bool Excluir(int id)
        {
            return listaSerie.Remove(listaSerie.FirstOrDefault(l => l.Id == id));
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            try
            {
                return listaSerie[listaSerie.FindIndex(l => l.Id == id)];

            }
            catch(System.Exception)
            {
                return null;
            }
        }
    }
}
