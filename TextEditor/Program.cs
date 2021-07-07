using System;
using System.IO;

namespace TextEditor
{
    static class Program
    {
        static void Main()
        {
            Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que vc deseja fazer?");
            Console.WriteLine("1 - Abrir um arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine() ?? string.Empty);

            switch (option)
            {
                case 0: Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        private static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            string path = Console.ReadLine();
            
            try
            {
                using var file = new StreamReader(path!);
                string text = file.ReadToEnd();
                Console.WriteLine("");
                Console.WriteLine(text);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível abrir o arquivo no diretório: {path}");
                Console.ReadLine();
                e.Data.Clear();
                Abrir();
                throw;
            }
            
            Console.ReadLine();
            Menu();
        }

        private static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("---------------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            } while (Console.ReadKey().Key != ConsoleKey.End);
            
            Salvar(text);
        }

        private static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            try
            {
                using var file = new StreamWriter(path!);
                file.Write(text);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: diretório {path} não existe!");
                Console.ReadLine();
                Salvar(text);
                e.Data.Clear();
                throw;
            }

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}