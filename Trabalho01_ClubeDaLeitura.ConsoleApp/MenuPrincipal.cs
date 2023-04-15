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
            RepositorioAmigos repositorioAmigos = new();
            RepositorioCaixas repositorioCaixas = new();

            RepositorioRevistas repositorioRevistas = new();
            repositorioRevistas.repositorioCaixas = repositorioCaixas;

            RepositorioEmprestimos repositorioEmprestimos = new();
            repositorioEmprestimos.repositorioAmigos = repositorioAmigos;
            repositorioEmprestimos.repositorioRevistas = repositorioRevistas;

            TelaCadastroAmigos telaCadastroAmigos = new();
            telaCadastroAmigos.repositorioAmigos = repositorioAmigos;

            TelaCadastroCaixa telaCadastroCaixa = new();
            telaCadastroCaixa.repositorioCaixas = repositorioCaixas;

            TelaCadastroRevistas telaCadastroRevistas = new();
            telaCadastroRevistas.repositorioRevistas = repositorioRevistas;
            telaCadastroRevistas.repositorioCaixas = repositorioCaixas;

            telaCadastroRevistas.telaCadastroCaixa = telaCadastroCaixa;

            TelaCadastroEmprestimos telaCadastroEmprestimos = new();
            telaCadastroEmprestimos.repositorioEmprestimos = repositorioEmprestimos;
            telaCadastroEmprestimos.repositorioAmigos = repositorioAmigos;
            telaCadastroEmprestimos.repositorioRevistas = repositorioRevistas;

            telaCadastroEmprestimos.telaCadastroAmigos = telaCadastroAmigos;
            telaCadastroEmprestimos.telaCadastroRevistas = telaCadastroRevistas;

            bool continuar = true;

            repositorioAmigos.PreCadastrarAmigos();
            repositorioCaixas.PreCadastrarCaixas();
            repositorioRevistas.PreCadastrarRevistas();
            repositorioEmprestimos.PreCadastrarEmprestimos();

            while (continuar)
            {
                MostrarMenuPrincipal();

                switch (ObterEscolha().ToUpper())
                {
                    case "1": telaCadastroAmigos.EscolherOpcaoMenu(); break;
                    case "2": telaCadastroRevistas.EscolherOpcaoMenu(); break;
                    case "3": telaCadastroCaixa.EscolherOpcaoMenu(); break;
                    case "4": telaCadastroEmprestimos.EscolherOpcaoMenu(); break;
                    case "S": continuar = false; break;
                    default: break;
                }
            }
        }

        private static void MostrarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("╔════════════════════════╗");
            Console.WriteLine("║    Clube da Leitura    ║");
            Console.WriteLine("╚════════════════════════╝");
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