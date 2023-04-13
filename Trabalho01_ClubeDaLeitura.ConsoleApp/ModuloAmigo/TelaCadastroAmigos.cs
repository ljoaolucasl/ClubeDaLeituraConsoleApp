using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaCadastroAmigos
    {
        public static void Menu()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();

                Console.WriteLine("Controle de Amigos");
                PulaLinha();
                Console.WriteLine("(1)Visualizar Amigos");
                Console.WriteLine("(2)Adicionar Amigo");
                Console.WriteLine("(3)Editar Amigo");
                Console.WriteLine("(4)Excluir Amigo");
                PulaLinha();
                Console.WriteLine("(S)Sair");
                PulaLinha();
                Console.Write("Escolha: ");

                continuar = InicializarOpcaoEscolhida();
            }
        }

        public static void AdicionarCadastroAmigo()
        {
            VisualizarAmigos();

            Amigos infoAmigo = ObterCadastroAmigo();

            RepositorioAmigos.Adicionar(infoAmigo);

            VisualizarAmigos();

            MensagemColor("\nAmigo adicionado com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public static void EditarCadastroAmigo()
        {
            VisualizarAmigos();

            Amigos idCadastroAmigoSelecionado = ValidaIdRevistas("editar");

            Amigos infoAmigoAtualizado = ObterCadastroAmigo();

            RepositorioAmigos.Editar(idCadastroAmigoSelecionado, infoAmigoAtualizado);

            VisualizarAmigos();

            MensagemColor("\nAmigo editado com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public static void ExcluirCadastroAmigo()
        {
            VisualizarAmigos();

            Amigos idCadastroAmigoSelecionado = ValidaIdRevistas("excluir");

            RepositorioAmigos.Excluir(idCadastroAmigoSelecionado);

            VisualizarAmigos();

            MensagemColor("\nAmigo excluído com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public static void VisualizarAmigos()
        {
            Console.Clear();

            int i = 0;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0, -10} │ {1, -25} │ {2, -25} │ {3, -20} │ {4, -30}", "ID", "Nome", "Nome do Responsável", "Telefone", "Endereço");
            Console.WriteLine("".PadRight(110, '―'));
            Console.ResetColor();

            foreach (Amigos info in RepositorioAmigos.GetListaAmigos())
            {
                if (i % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                    Console.ResetColor();

                Console.WriteLine("{0, -10} │ {1, -25} │ {2, -25} │ {3, -20} │ {4, -30}", info.id, info.nome, info.nomeResponsavel, info.telefone, info.endereco);

                i++;
            }
            Console.ResetColor();

            PulaLinha();
        }

        #region private

        private static bool InicializarOpcaoEscolhida()
        {
            string entrada = Console.ReadLine();

            switch (entrada.ToUpper())
            {
                case "1": VisualizarAmigos(); Console.ReadLine(); break;
                case "2": AdicionarCadastroAmigo(); break;
                case "3": EditarCadastroAmigo(); break;
                case "4": ExcluirCadastroAmigo(); break;
                case "S": return false; break;
                default: break;
            }
            return true;
        }

        private static Amigos ObterCadastroAmigo()
        {
            Amigos infoAmigo = new()
            {
                nome = ObterNome(),
                nomeResponsavel = ObterNomeResponsavel(),
                telefone = ObterTelefone(),
                endereco = ObterEndereco()
            };

            return infoAmigo;
        }

        private static int ObterIdEscolhido(string acao)
        {
            int idEscolhido = ValidaNumero($"Digite o ID da linha que deseja {acao}: ");

            return idEscolhido;
        }

        private static string ObterNome()
        {
            Console.Write("Escreva o Nome: ");
            string nome = Console.ReadLine();
            return nome;
        }

        private static string ObterNomeResponsavel()
        {
            Console.Write("Escreva o Nome do Responsável: ");
            string nomeResponsavel = Console.ReadLine();
            return nomeResponsavel;
        }

        private static int ObterTelefone()
        {
            int telefone = ValidaNumero("Escreva o Telefone: ");
            return telefone;
        }

        private static string ObterEndereco()
        {
            Console.Write("Escreva o Endereço: ");
            string endereco = Console.ReadLine();
            return endereco;
        }

        private static void MensagemColor(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.Write(mensagem);
            Console.ResetColor();
        }

        private static void PulaLinha()
        {
            Console.WriteLine();
        }
        #endregion

        #region validacoes

        private static Amigos ValidaIdRevistas(string tipo)
        {
            Amigos amigo;

            do
            {
                amigo = RepositorioAmigos.SelecionarId(ObterIdEscolhido(tipo));

                if (amigo == null)
                {
                    MensagemColor("Atenção, apenas ID`s existentes\n", ConsoleColor.Red);
                }

            } while (amigo == null);

            return amigo;
        }

        private static int ValidaNumero(string mensagem)
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

        #endregion
    }
}
