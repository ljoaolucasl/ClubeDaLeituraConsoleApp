using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp
{
    public class MenuPrincipal
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenuPrincipal();

                switch (ObterEscolha().ToUpper())
                {
                    case "1": Tela.telaCadastroAmigos.EscolherOpcaoMenu(); break;
                    case "2": Tela.telaCadastroRevistas.EscolherOpcaoMenu(); break;
                    case "3": Tela.telaCadastroCaixa.EscolherOpcaoMenu(); break;
                    case "4": Tela.telaCadastroEmprestimos.EscolherOpcaoMenu(); break;
                    case "S": continuar = false; break;
                    default: break;
                }
            }
        }

        private static void MostrarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("╔══════════════════╗");
            Console.WriteLine("║ Clube da Leitura ║");
            Console.WriteLine("╚══════════════════╝");
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