using System;

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
            
        }

        private static void Editar()
        {
            
        }
    }
}