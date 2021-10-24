using System;
using DIO.Series.Enum;

namespace DIO.Series.Classes
{
    internal class Serie : EntidadeBase
    {    
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
        }

        public string RetornaTitulo()
        {
            return Titulo;
        }

        public int RetornaId()
        {
            return Id;
        }

        public override string ToString()
        {
            string retorno = string.Empty;
            retorno += $"Genero: {Genero + Environment.NewLine}";
            retorno += $"Titulo: {Titulo + Environment.NewLine}";
            retorno += $"Descricao: {Descricao + Environment.NewLine}";
            retorno += $"Ano: {Ano + Environment.NewLine}";

            return retorno;
        }
    }
}
