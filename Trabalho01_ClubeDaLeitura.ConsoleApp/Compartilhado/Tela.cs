using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class Tela
    {
        public static TelaCadastroAmigos telaCadastroAmigos = new();
        public static TelaCadastroCaixa telaCadastroCaixa = new();
        public static TelaCadastroRevistas telaCadastroRevistas = new();
        public static TelaCadastroEmprestimos telaCadastroEmprestimos = new();
        public static RepositorioAmigos repositorioAmigos = new();
        public static RepositorioCaixas repositorioCaixas = new();
        public static RepositorioRevistas repositorioRevistas = new();
        public static RepositorioEmprestimos repositorioEmprestimos = new();

        public void MostrarMenu(string tipo)
        {
            Console.Clear();

            Console.WriteLine($"Controle de {tipo}s");
            PulaLinha();
            Console.WriteLine($"(1)Visualizar {tipo}s");
            Console.WriteLine($"(2)Adicionar {tipo}");
            Console.WriteLine($"(3)Editar {tipo}");
            Console.WriteLine($"(4)Excluir {tipo}");
            PulaLinha();
            Console.WriteLine("(S)Sair");
            PulaLinha();
            Console.Write("Escolha: ");
        }

        public int ObterIdEscolhido(string acao)
        {
            int idEscolhido = ValidaNumero($"Digite o ID da linha que deseja {acao}: ");

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

        public static void TextoZebrado()
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

        private static bool zebra = true;
    }
}
