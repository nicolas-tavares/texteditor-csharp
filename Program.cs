using System;
using System.IO;


namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("=================");
            Console.WriteLine("O que você deseja fazer ?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("=================");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo ?");
            Console.WriteLine("=================");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine("=================\n\n");
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para Sair)");
            Console.WriteLine("=================");
            string text = "";

            do
            {
                text += Console.ReadLine();   // "+=" para concatenar o que for adicionado pelo usuário e não substituir
                text += Environment.NewLine;  // Coloca uma nova linha
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("QQual caminho para salvar o arquivo ?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))  //StreamWriter para abrir arquivo pra escrita
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo '{path}' salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}
