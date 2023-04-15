using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaCadastroAmigos : Tela
    {
        public RepositorioAmigos repositorioAmigos = null;

        public void EscolherOpcaoMenu()
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenu("Amigo");

                continuar = InicializarOpcaoEscolhida();
            }
        }

        public void AdicionarCadastroAmigo()
        {
            VisualizarAmigos();

            Amigos infoAmigo = ObterCadastroAmigo();

            repositorioAmigos.Adicionar(infoAmigo);

            VisualizarAmigos();

            MensagemColor("\nAmigo adicionado com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public void EditarCadastroAmigo()
        {
            VisualizarAmigos();

            if (ValidaListaVazia(repositorioAmigos.listaDados))
            {
                Amigos idCadastroAmigoSelecionado = ValidaIdAmigos("Digite o ID do Amigo que deseja editar: ");

                Amigos infoAmigoAtualizado = ObterCadastroAmigo();

                repositorioAmigos.Editar(idCadastroAmigoSelecionado, infoAmigoAtualizado);

                VisualizarAmigos();

                MensagemColor("\nAmigo editado com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        public void ExcluirCadastroAmigo()
        {
            VisualizarAmigos();

            if (ValidaListaVazia(repositorioAmigos.listaDados))
            {
                Amigos idCadastroAmigoSelecionado = ValidaIdAmigos("Digite o ID do Amigo que deseja excluir: ");

                repositorioAmigos.Excluir(idCadastroAmigoSelecionado);

                VisualizarAmigos();

                MensagemColor("\nAmigo excluído com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        public void VisualizarAmigos()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("╔" + "".PadRight(130, '═') + "╗");
            Console.WriteLine("║                                                            Amigos                                                                ║");
            Console.WriteLine("╚" + "".PadRight(130, '═') + "╝");
            PulaLinha();
            Console.ForegroundColor = ConsoleColor.Blue;
            string espacamento = "{0, -5} │ {1, -30} │ {2, -30} │ {3, -20} │ {4, -35}";
            Console.WriteLine(espacamento, "ID", "Nome", "Nome do Responsável", "Telefone", "Endereço");
            Console.WriteLine("".PadRight(132, '―'));
            Console.ResetColor();

            foreach (Amigos info in repositorioAmigos.GetListaDados())
            {
                TextoZebrado();

                Console.WriteLine(espacamento, info.id, info.nome, info.nomeResponsavel, info.telefone, info.endereco);
            }

            Console.ResetColor();
            zebra = true;

            PulaLinha();
        }

        public Amigos ValidaIdAmigos(string mensagem)
        {
            Amigos amigo;

            do
            {
                amigo = repositorioAmigos.SelecionarId(ObterIdEscolhido(mensagem));

                if (amigo == null)
                {
                    MensagemColor("Atenção, apenas ID`s existentes\n", ConsoleColor.Red);
                }

            } while (amigo == null);

            return amigo;
        }

        private bool InicializarOpcaoEscolhida()
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

        private Amigos ObterCadastroAmigo()
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

        private string ObterNome()
        {
            Console.Write("Escreva o Nome: ");
            string nome = Console.ReadLine();
            return nome;
        }

        private string ObterNomeResponsavel()
        {
            Console.Write("Escreva o Nome do Responsável: ");
            string nomeResponsavel = Console.ReadLine();
            return nomeResponsavel;
        }

        private int ObterTelefone()
        {
            int telefone = ValidaNumero("Escreva o Telefone: ");
            return telefone;
        }

        private string ObterEndereco()
        {
            Console.Write("Escreva o Endereço: ");
            string endereco = Console.ReadLine();
            return endereco;
        }
    }
}
