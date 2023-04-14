using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class TelaCadastroCaixa : Tela
    {
        public void EscolherOpcaoMenu()
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenu("Caixa");

                continuar = InicializarOpcaoEscolhida();
            }
        }

        public void AdicionarCadastroCaixa()
        {
            VisualizarCaixas();

            Caixas infoCaixa = ObterCadastroCaixa();

            repositorioCaixas.Adicionar(infoCaixa);

            VisualizarCaixas();

            MensagemColor("\nCaixa adicionada com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public void EditarCadastroCaixa()
        {
            VisualizarCaixas();

            if (ValidaListaVazia(repositorioCaixas.listaDados))
            {
                Caixas idCadastroCaixaSelecionado = ValidaIdCaixas("editar");

                Caixas infoCaixaAtualizado = ObterCadastroCaixa();

                repositorioCaixas.Editar(idCadastroCaixaSelecionado, infoCaixaAtualizado);

                VisualizarCaixas();

                MensagemColor($"\nCaixa editada com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        public void ExcluirCadastroCaixa()
        {
            VisualizarCaixas();

            if (ValidaListaVazia(repositorioCaixas.listaDados))
            {
                Caixas idCadastroCaixaSelecionado = ValidaIdCaixas("excluir");

                repositorioCaixas.Excluir(idCadastroCaixaSelecionado);

                VisualizarCaixas();

                MensagemColor("\nCaixa excluída com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        public void VisualizarCaixas()
        {
            Console.Clear();

            Console.WriteLine("╔══════════════════╗");
            Console.WriteLine("║      Caixas      ║");
            Console.WriteLine("╚══════════════════╝");
            PulaLinha();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0, -10} │ {1, -20} │ {2, -30}", "ID", "Cor", "Etiqueta");
            Console.WriteLine("".PadRight(66, '―'));
            Console.ResetColor();

            foreach (Caixas info in repositorioCaixas.GetListaDados())
            {
                TextoZebrado();

                Console.WriteLine("{0, -10} │ {1, -20} │ {2, -30}", info.id, info.cor, info.etiqueta);
            }

            Console.ResetColor();

            PulaLinha();
        }

        private bool InicializarOpcaoEscolhida()
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

        public Caixas ValidaIdCaixas(string tipo)
        {
            Caixas caixa;

            do
            {
                caixa = repositorioCaixas.SelecionarId(ObterIdEscolhido(tipo));

                if (caixa == null)
                {
                    MensagemColor("Atenção, apenas ID`s existentes\n", ConsoleColor.Red);
                }

            } while (caixa == null);

            return caixa;
        }
    }
}
