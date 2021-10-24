using System;
using System.Linq;
using DIO.Series.Enum;
using DIO.Series.Classes;

namespace DIO.Series
{
    internal class Program
    {
        private static readonly SerieRepositorio serieRepositorio = new();
        private static string opcaoEscolhida;
        private static void Main(string[] args)
        {
            do
            {
                Menu();

                switch (opcaoEscolhida)
                {
                    case "1":
                        ListarSerie();
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

                    case "X":
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } while (opcaoEscolhida != "X");

            Console.WriteLine("Obrigado por utilizar meus servicos.");
        }

        private static void ListarSerie()
        {
            Console.Clear();
            Console.WriteLine($"Lista de séries{Environment.NewLine}");

            var lista = serieRepositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");

                return;
            }

            foreach (var serie in lista)
            {
                Console.WriteLine(serie.ToString());
            }
        }

        private static void InserirSerie()
        {
            Console.Clear();
            Console.WriteLine($"Inserir nova série{Environment.NewLine}");

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opcoes acima: ");
            var entradaGenero = int.Parse(Console.ReadLine());

            if (entradaGenero <= 0 || entradaGenero > System.Enum.GetValues(typeof(Genero)).Length)
            {
                Console.WriteLine("Valor de genero invalido!");
                return ;
            }                

            Console.WriteLine("Digite o titulo da série: ");
            var entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série: ");
            var entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao de inicio da série: ");
            var entradaDescricao = Console.ReadLine();

            serieRepositorio.Insere(new Serie(id: serieRepositorio.ProximoId(),
                                              genero: (Genero)entradaGenero,
                                              titulo: entradaTitulo,
                                              ano: entradaAno,
                                              descricao: entradaDescricao));
        }

        private static void AtualizarSerie()
        {
            Console.Clear();
            Console.WriteLine($"Digite o id da série: {Environment.NewLine}");
            var indiceSerie = int.Parse(Console.ReadLine());

            if(!(serieRepositorio.RetornaPorId(indiceSerie) != null))
            {
                Console.WriteLine("Valor de id não encontrado!");
                return;
            }

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genero entre as opcoes acima: ");
            var entradaGenero = int.Parse(Console.ReadLine());

            if (entradaGenero <= 0 || entradaGenero > System.Enum.GetValues(typeof(Genero)).Length)
            {
                Console.WriteLine("Valor de genero invalido!");
                return;
            }

            Console.WriteLine("Digite o titulo da série: ");
            var entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da série: ");
            var entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descricao de inicio da série: ");
            var entradaDescricao = Console.ReadLine();

            serieRepositorio.Atualizar(indiceSerie, new Serie(
                                    id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao));
        }

        private static void ExcluirSerie()
        {
            Console.Clear();
            Console.WriteLine($"Digite o id da série: {Environment.NewLine}");
            var indiceSerie = int.Parse(Console.ReadLine());

            if (!serieRepositorio.Excluir(indiceSerie))
            {
                Console.WriteLine("Houve um erro ao tentar excluir!");
                return;
            }                

            Console.WriteLine($"Série excluida com sucesso!{Environment.NewLine}");
        }

        private static void VisualizarSerie()
        {
            Console.Clear();
            Console.WriteLine($"Digite o id da série: {Environment.NewLine}");
            var indiceSerie = int.Parse(Console.ReadLine());

            var serie = serieRepositorio.RetornaPorId(indiceSerie);

            if (!(serie != null))
            {
                Console.WriteLine("Valor de id não encontrado!");
                return;
            }
            Console.WriteLine(serie);
        }

        private static void Menu()
        {
            Console.WriteLine(
                    $"{Environment.NewLine}Informe a opcao desejada: " +
                    $"{Environment.NewLine}1 - Listar séries" +
                    $"{Environment.NewLine}2 - Inserir nova série" +
                    $"{Environment.NewLine}3 - Atualiza série" +
                    $"{Environment.NewLine}4 - Excluir série" +
                    $"{Environment.NewLine}5 - Visualizar série" +
                    $"{Environment.NewLine}X - Sair{Environment.NewLine}");

            opcaoEscolhida = Console.ReadLine().ToUpper();
        }
    }
}
