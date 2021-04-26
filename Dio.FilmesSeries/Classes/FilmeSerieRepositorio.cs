using DIO.Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dio.FilmesSeries.Classes
{

    public class FilmeSerieRepositorio : IRepositorio<FilmeSerie>
    {
        private List<FilmeSerie> listaSerie = new List<FilmeSerie>();
        public void Atualiza(int id, FilmeSerie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(FilmeSerie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<FilmeSerie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public FilmeSerie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}
