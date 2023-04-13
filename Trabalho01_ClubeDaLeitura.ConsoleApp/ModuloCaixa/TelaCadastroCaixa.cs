using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class TelaCadastroCaixa
    {
        public static void Menu()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();

                Console.WriteLine("Controle de Caixas");
                PulaLinha();
                Console.WriteLine("(1)Visualizar Caixas");
                Console.WriteLine("(2)Adicionar Caixa");
                Console.WriteLine("(3)Editar Caixa");
                Console.WriteLine("(4)Excluir Caixa");
                PulaLinha();
                Console.WriteLine("(S)Sair");
                PulaLinha();
                Console.Write("Escolha: ");

                continuar = InicializarOpcaoEscolhida();
            }
        }

        public static void AdicionarCadastroCaixa()
        {
            VisualizarCaixas();

            Caixas infoCaixa = ObterCadastroCaixa();

            RepositorioCaixas.Adicionar(infoCaixa);

            VisualizarCaixas();

            MensagemColor("\nCaixa adicionada com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public static void EditarCadastroCaixa()
        {
            VisualizarCaixas();

            Caixas idCadastroCaixaSelecionado = ValidaIdCaixas("editar");

            Caixas infoCaixaAtualizado = ObterCadastroCaixa();

            RepositorioCaixas.Editar(idCadastroCaixaSelecionado, infoCaixaAtualizado);

            VisualizarCaixas();

            MensagemColor($"\nCaixa editada com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public static void ExcluirCadastroCaixa()
        {
            VisualizarCaixas();

            Caixas idCadastroCaixaSelecionado = ValidaIdCaixas("excluir");

            RepositorioCaixas.Excluir(idCadastroCaixaSelecionado);

            VisualizarCaixas();

            MensagemColor("\nCaixa excluída com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public static void VisualizarCaixas()
        {
            Console.Clear();

            int i = 0;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0, -10} │ {1, -20} │ {2, -30}", "ID", "Cor", "Etiqueta");
            Console.WriteLine("".PadRight(60, '―'));
            Console.ResetColor();

            foreach (Caixas info in RepositorioCaixas.GetListaCaixas())
            {
                if (i % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                    Console.ResetColor();

                Console.WriteLine("{0, -10} │ {1, -20} │ {2, -30}", info.id, info.cor, info.etiqueta);

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
                case "1": VisualizarCaixas(); Console.ReadLine(); break;
                case "2": AdicionarCadastroCaixa(); break;
                case "3": EditarCadastroCaixa(); break;
                case "4": ExcluirCadastroCaixa(); break;
                case "S": return false; break;
                default: break;
            }
            return true;
        }

        private static Caixas ObterCadastroCaixa()
        {
            Caixas infoCaixa = new()
            {
                etiqueta = ObterEtiqueta(),
                cor = ObterCor(),
            };

            return infoCaixa;
        }

        public static int ObterIdEscolhido(string acao)
        {
            int idEscolhido = ValidaNumero($"Digite o ID da Caixa que deseja {acao}: ");

            return idEscolhido;
        }

        private static string ObterEtiqueta()
        {
            Console.Write("Escreva o nome da Etiqueta: ");
            string etiqueta = Console.ReadLine();
            return etiqueta;
        }

        private static string ObterCor()
        {
            Console.Write("Escreva a Cor da Caixa: ");
            string cor = Console.ReadLine();
            return cor;
        }

        private static void PulaLinha()
        {
            Console.WriteLine();
        }

        private static void MensagemColor(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.Write(mensagem);
            Console.ResetColor();
        }
        #endregion

        public static Caixas ValidaIdCaixas(string tipo)
        {
            Caixas caixa;

            do
            {
                caixa = RepositorioCaixas.SelecionarId(TelaCadastroCaixa.ObterIdEscolhido(tipo));

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
    }
}
