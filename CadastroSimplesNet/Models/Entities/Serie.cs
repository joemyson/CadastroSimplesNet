using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroSimplesNet
{
    public class Serie : EntidadeBase
    {
       
        //Atributo
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        //Metodo construtor
        public Serie( Genero genero, string titulo, string descricao, int ano,bool excluido, int id)
            {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;

        }

        public Serie(int id, Genero genero, string titulo, int ano, string descricao)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Ano = ano;
            Descricao = descricao;
        }

        public override string ToString()
        {

            string retorno = "";
            retorno += "Genero :" + this.Genero + Environment.NewLine;
            retorno += "Titulo :" + this.Genero + Environment.NewLine;
            retorno += "Descricão :" + this.Genero + Environment.NewLine;
            retorno += "Ano :" + this.Ano + Environment.NewLine;
            retorno += "Excluido:" + this.Excluido;

            return retorno ;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public void Excluir()
        {
            this.Excluido = true;

        }
    }
}
