using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class TelaCadastroRevistas
    {
        public static void Menu()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();

                Console.WriteLine("Controle de Revistas");
                PulaLinha();
                Console.WriteLine("(1)Visualizar Revistas");
                Console.WriteLine("(2)Adicionar Revista");
                Console.WriteLine("(3)Editar Revista");
                Console.WriteLine("(4)Excluir Revista");
                PulaLinha();
                Console.WriteLine("(S)Sair");
                PulaLinha();
                Console.Write("Escolha: ");

                continuar = InicializarOpcaoEscolhida();
            }
        }

        public static void AdicionarCadastroRevista()
        {
            VisualizarRevistas();

            Revistas infoRevista = ObterCadastroRevista();

            RepositorioRevistas.Adicionar(infoRevista);

            VisualizarRevistas();

            MensagemColor("\nRevista adicionada com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public static void EditarCadastroRevista()
        {
            VisualizarRevistas();

            Revistas idCadastroRevistaSelecionado = ValidaIdRevistas("editar");

            Revistas infoRevistaAtualizado = ObterCadastroRevista();

            RepositorioRevistas.Editar(idCadastroRevistaSelecionado, infoRevistaAtualizado);

            VisualizarRevistas();

            MensagemColor("\nRevista editada com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public static void ExcluirCadastroRevista()
        {
            VisualizarRevistas();

            Revistas idCadastroRevistaSelecionado = ValidaIdRevistas("excluir");

            RepositorioRevistas.Excluir(idCadastroRevistaSelecionado);

            VisualizarRevistas();

            MensagemColor("\nRevista excluída com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public static void VisualizarRevistas()
        {
            Console.Clear();

            int i = 0;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0, -10} │ {1, -20} │ {2, -15} │ {3, -15} │ {4, -15}", "ID", "Tipo de Coleção", "N°Edição", "Ano", "Caixa");
            Console.WriteLine("".PadRight(75, '―'));
            Console.ResetColor();

            foreach (Revistas info in RepositorioRevistas.GetListaRevistas())
            {
                if (i % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                    Console.ResetColor();

                Console.WriteLine("{0, -10} │ {1, -20} │ {2, -15} │ {3, -15} │ {4, -15}", info.id, info.colecao, info.edicao, info.ano, info.caixa.etiqueta);

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
                case "1": VisualizarRevistas(); Console.ReadLine(); break;
                case "2": AdicionarCadastroRevista(); break;
                case "3": EditarCadastroRevista(); break;
                case "4": ExcluirCadastroRevista(); break;
                case "S": return false; break;
                default: break;
            }
            return true;
        }

        private static Revistas ObterCadastroRevista()
        {
            Revistas infoRevista = new()
            {
                colecao = ObterColecao(),
                edicao = ObterEdicao(),
                ano = ObterAno(),
                caixa = ObterCaixa()
            };

            return infoRevista;
        }

        private static int ObterIdEscolhido(string acao)
        {
            int idEscolhido = ValidaNumero($"Digite o ID da linha que deseja {acao}: ");

            return idEscolhido;
        }

        private static string ObterColecao()
        {
            Console.Write("Escreva o Tipo de Coleção: ");
            string colecao = Console.ReadLine();
            return colecao;
        }

        private static int ObterEdicao()
        {
            int edicao = ValidaNumero("Escreva o Número da Edição: ");
            return edicao;
        }

        private static int ObterAno()
        {
            int ano = ValidaNumero("Escreva o Ano da Revista: ");
            return ano;
        }

        private static Caixas ObterCaixa()
        {
            TelaCadastroCaixa.VisualizarCaixas();
            Caixas caixa = TelaCadastroCaixa.ValidaIdCaixas("guardar a Revista: ");
            return caixa;
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

        private static Revistas ValidaIdRevistas(string tipo)
        {
            Revistas caixa;

            do
            {
                caixa = RepositorioRevistas.SelecionarId(ObterIdEscolhido(tipo));

                if (caixa == null)
                {
                    MensagemColor("Atenção, apenas ID`s existentes\n", ConsoleColor.Red);
                }

            } while (caixa == null);

            return caixa;
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
