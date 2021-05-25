using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroSimplesNet
{
    public class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        public static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while( opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListaSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();


            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
           
        }
        private static void ListaSerie()
        {
            Console.WriteLine("Lista series");

            var lista = repositorio.Lista(); 
           
            if(lista.Count == 0)
            {
                Console.WriteLine("nemhuma serie cadastrada");
                return;
            }
            foreach(var serie in lista)
            {
                Console.WriteLine("#{0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        // inserir serie

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");
           
            // lista o texto com Enum

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("digite o gênero entere as opção acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Serie");
            string entradaTitulo = Console.ReadLine();

            Console.Write("digite o ano de inicio da serie :");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("digite a descricão da serie");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id:repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Isere(novaSerie);
        }

        // Atualiza serie
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da serie :");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("digite o gênero entere as opção acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Serie");
            string entradaTitulo = Console.ReadLine();
            Console.Write("digite o ano de inicio da serie :");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("digite a descricão da serie");
            string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualizar(indiceSerie, atualizarSerie);

        }
        // Excluir
        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da serie");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        //Visualizar serie

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da serie");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);

        }

        // obter opção do usuario
        private static string ObterOpcaoUsuario()
        {

            Console.WriteLine();
            Console.WriteLine("Cadastro de Serie a seu Dispor!!!");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine();
            Console.WriteLine("1 - Lista serie");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("c - limpar Tela");
            Console.WriteLine(" X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }


        
    }
}
