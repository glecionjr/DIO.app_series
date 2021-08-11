using System;
using System.Collections.Generic;

using DIO.AppSeries.Repositorio;
using DIO.AppSeries.Entities;
using DIO.AppSeries.Entities.Enums;

namespace DIO.AppSeries
{
    public class Program
    {
        public static SerieRepositorio series = new SerieRepositorio();
        private static int opcao;

        static void Main(string[] args)
        {
            Console.WriteLine("-------------- App SERIES --------------");
            Console.WriteLine(" ");

            do
            {
                System.Console.WriteLine(" [1] - Listar todas as Series ");
                System.Console.WriteLine(" [2] - Cadastrar Serie ");
                System.Console.WriteLine(" [3] - Atualizar Serie ");
                System.Console.WriteLine(" [4] - Detalhes de uma Serie ");
                Console.WriteLine(" ");
                System.Console.WriteLine(" [0] - Sair ");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        ListarSeries();
                        break;

                    case 2:
                        CadastrarSerie();
                        break;
                    
                    case 3:
                        AtualizarSerie();
                        break;

                    case 4:
                        DetalharSerie();
                        break;

                }

            } while (opcao != 0);
        }

        private static void DetalharSerie()
        {
            ListarSeries();

            System.Console.WriteLine("");
            System.Console.WriteLine("Informe a série para visualizar detalhes: ");
            int idSerie = int.Parse(Console.ReadLine());

            System.Console.WriteLine(" ------------ DETALHES DA SÉRIE ------------");
            System.Console.WriteLine("");            

            Serie s = series.RetornaPorId(idSerie);
            s.ToString();
            RetornarParaMenu();
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine(" ------------ ATUALIZAR DADOS DA SÉRIE ------------");
            System.Console.WriteLine("");

            ListarSeries();

            Type generos = typeof(Genero);

            foreach(var g in Enum.GetNames(generos))
            {                   
                System.Console.WriteLine((int)Enum.Parse(typeof(Genero), g) + " - " + g);
            }
            System.Console.WriteLine("");
            System.Console.WriteLine("Informe a série: ");
            int idSerie = int.Parse(Console.ReadLine());

            System.Console.WriteLine("");
            System.Console.WriteLine("Informe o Gênero: ");
            int opcaoGenero = int.Parse(Console.ReadLine());
            Genero genero = (Genero) opcaoGenero;

            System.Console.WriteLine("Informe o Título: ");
            string titulo = Console.ReadLine();

            System.Console.WriteLine("Informe Descrição: ");
            string descricao = Console.ReadLine();

            System.Console.WriteLine("Informe o Ano: ");
            int ano = int.Parse(Console.ReadLine());

            Serie serie = new Serie(id: series.ProximoId(), 
                                    genero: genero, 
                                    titulo: titulo, 
                                    descricao: descricao, 
                                    ano: ano);
            series.Atualiza(idSerie, serie);

            System.Console.WriteLine(" ");
            System.Console.WriteLine("Série cadastrada com sucesso... ");

            RetornarParaMenu();            
        }

        private static void CadastrarSerie()
        {
            System.Console.WriteLine(" ------------ CADASTRO DE SÉRIE ------------");
            System.Console.WriteLine("");

            Type generos = typeof(Genero);

            foreach(var g in Enum.GetNames(generos))
            {                   
                System.Console.WriteLine((int)Enum.Parse(typeof(Genero), g) + " - " + g);
            }
            System.Console.WriteLine("");
            System.Console.WriteLine("Informe o Gênero: ");
            int opcaoGenero = int.Parse(Console.ReadLine());
            Genero genero = (Genero) opcaoGenero;

            System.Console.WriteLine("Informe o Título: ");
            string titulo = Console.ReadLine();

            System.Console.WriteLine("Informe Descrição: ");
            string descricao = Console.ReadLine();

            System.Console.WriteLine("Informe o Ano: ");
            int ano = int.Parse(Console.ReadLine());

            Serie serie = new Serie(id: series.ProximoId(), 
                                    genero: genero, 
                                    titulo: titulo, 
                                    descricao: descricao, 
                                    ano: ano);
            series.Insere(serie);

            System.Console.WriteLine(" ");
            System.Console.WriteLine("Série cadastrada com sucesso... ");

            RetornarParaMenu();
        }

        private static void ListarSeries()
        {
            try
            {
                List<Serie> listaDeSeries = series.Lista();

                System.Console.WriteLine(" ------------ SÉRIES DISPONÍVEIS ------------");
                foreach(var serie in listaDeSeries)
                {
                    System.Console.WriteLine(serie);
                }
                System.Console.WriteLine("");
                RetornarParaMenu();
            }
            catch (DomainException message)
            {
                System.Console.WriteLine("[ERR..] " + message);
                RetornarParaMenu();
            }
        }

        private static void RetornarParaMenu()
        {
            System.Console.WriteLine("");
            System.Console.WriteLine("Tecle para continuar...");
            Console.ReadKey();
        }
    }
}
