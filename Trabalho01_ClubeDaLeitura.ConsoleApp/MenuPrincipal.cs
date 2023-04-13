using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp
{
    internal class MenuPrincipal
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenuPrincipal();

                switch (ObterEscolha().ToUpper())
                {
                    case "1": TelaCadastroAmigos.Menu(); break;
                    case "2": TelaCadastroRevistas.Menu(); break;
                    case "3": TelaCadastroCaixa.Menu(); break;
                    case "4": break;
                    case "S": continuar = false; break;
                    default: break;
                }
            }
        }

        private static void MostrarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("Clube da Leitura");
            PulaLinha();
            Console.WriteLine("(1)Controle de Amigos");
            Console.WriteLine("(2)Controle de Revistas");
            Console.WriteLine("(3)Controle de Caixas");
            Console.WriteLine("(4)Controle de Emprestimos");
            PulaLinha();
            Console.WriteLine("(S)Sair");
            PulaLinha();
            Console.Write("Escolha: ");
        }

        private static string ObterEscolha()
        {
            string entrada = Console.ReadLine();

            return entrada;
        }

        private static void PulaLinha()
        {
            Console.WriteLine();
        }
    }
}