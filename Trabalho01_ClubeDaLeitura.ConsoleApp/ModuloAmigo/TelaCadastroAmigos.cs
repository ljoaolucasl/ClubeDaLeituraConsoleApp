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
                Amigos idCadastroAmigoSelecionado = ValidaIdRevistas("editar");

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
                Amigos idCadastroAmigoSelecionado = ValidaIdRevistas("excluir");

                repositorioAmigos.Excluir(idCadastroAmigoSelecionado);

                VisualizarAmigos();

                MensagemColor("\nAmigo excluído com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        public void VisualizarAmigos()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0, -10} │ {1, -25} │ {2, -25} │ {3, -20} │ {4, -30}", "ID", "Nome", "Nome do Responsável", "Telefone", "Endereço");
            Console.WriteLine("".PadRight(122, '―'));
            Console.ResetColor();

            foreach (Amigos info in repositorioAmigos.GetListaDados())
            {
                TextoZebrado();

                Console.WriteLine("{0, -10} │ {1, -25} │ {2, -25} │ {3, -20} │ {4, -30}", info.id, info.nome, info.nomeResponsavel, info.telefone, info.endereco);
            }

            Console.ResetColor();

            PulaLinha();
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

        private int ObterTelefone()
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

        private Amigos ValidaIdRevistas(string tipo)
        {
            Amigos amigo;

            do
            {
                amigo = repositorioAmigos.SelecionarId(ObterIdEscolhido(tipo));

                if (amigo == null)
                {
                    MensagemColor("Atenção, apenas ID`s existentes\n", ConsoleColor.Red);
                }

            } while (amigo == null);

            return amigo;
        }
    }
}
