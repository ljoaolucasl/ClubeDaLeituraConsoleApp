using System.Collections;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class Tela
    {
        //public static TelaCadastroAmigos telaCadastroAmigos = new();
        //public static TelaCadastroCaixa telaCadastroCaixa = new();
        //public static TelaCadastroRevistas telaCadastroRevistas = new();
        //public static TelaCadastroEmprestimos telaCadastroEmprestimos = new();
        //public static RepositorioAmigos repositorioAmigos = new();
        //public static RepositorioCaixas repositorioCaixas = new();
        //public static RepositorioRevistas repositorioRevistas = new();
        //public static RepositorioEmprestimos repositorioEmprestimos = new();

        public void MostrarMenu(string tipo, ConsoleColor cor)
        {
            Console.Clear();

            Console.ForegroundColor = cor;
            Console.WriteLine($"Controle de {tipo}s");
            Console.ResetColor();
            PulaLinha();
            Console.WriteLine($"(1)Visualizar {tipo}s");
            Console.WriteLine($"(2)Adicionar {tipo}");
            Console.WriteLine($"(3)Editar {tipo}");
            Console.WriteLine($"(4)Excluir {tipo}");
            if(tipo == "Empréstimo")
                Console.WriteLine($"(5)Devoluções");

            PulaLinha();
            Console.WriteLine("(S)Sair");
            PulaLinha();
            Console.Write("Escolha: ");
        }

        public int ObterIdEscolhido(string mensagem)
        {
            int idEscolhido = ValidaNumero(mensagem);

            return idEscolhido;
        }

        public int ValidaNumero(string mensagem)
        {
            bool validaNumero;
            string entrada;
            int numero;

            do
            {
                Console.Write(mensagem);

                entrada = Console.ReadLine();

                validaNumero = int.TryParse(entrada, out numero);

                if (!validaNumero)
                {
                    MensagemColor("Atenção, apenas números\n", ConsoleColor.Red);
                }

            } while (!validaNumero);

            return numero;
        }

        public bool ValidaListaVazia(ArrayList lista)
        {
            if(lista.Count == 0) 
            {
                MensagemColor("A Lista de Cadastros está vazia . . .", ConsoleColor.DarkYellow);
                return false;
            }

            else
                return true;
        }

        public void MensagemColor(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.Write(mensagem);
            Console.ResetColor();
        }

        public void TextoZebrado()
        {
            if (zebra)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;
                zebra = false;
            }
            else { Console.ResetColor(); zebra = true; }
        }

        public void PulaLinha()
        {
            Console.WriteLine();
        }

        public bool zebra = true;
    }
}
