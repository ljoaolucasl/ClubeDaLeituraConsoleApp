using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class TelaCadastroCaixa : Tela
    {
        public RepositorioCaixas repositorioCaixas = null;

        public void EscolherOpcaoMenu()
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenu("Caixa", ConsoleColor.DarkYellow);

                continuar = InicializarOpcaoEscolhida();
            }
        }

        public void VisualizarCaixas()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("╔" + "".PadRight(44, '═') + "╗");
            Console.WriteLine("║                   Caixas                   ║");
            Console.WriteLine("╚" + "".PadRight(44, '═') + "╝");
            PulaLinha();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string espacamento = "{0, -5} │ {1, -10} │ {2, -25}";
            Console.WriteLine(espacamento, "ID", "Cor", "Etiqueta");
            Console.WriteLine("".PadRight(46, '―'));
            Console.ResetColor();

            foreach (Caixas info in repositorioCaixas.GetListaDados())
            {
                TextoZebrado();

                Console.WriteLine(espacamento, info.id, info.cor, info.etiqueta);
            }

            Console.ResetColor();
            zebra = true;

            PulaLinha();
        }

        private void AdicionarCadastroCaixa()
        {
            VisualizarCaixas();

            Caixas infoCaixa = ObterCadastroCaixa();

            repositorioCaixas.Adicionar(infoCaixa);

            VisualizarCaixas();

            MensagemColor("\nCaixa adicionada com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        private void EditarCadastroCaixa()
        {
            VisualizarCaixas();

            if (ValidaListaVazia(repositorioCaixas.listaDados))
            {
                Caixas idSelecionado; bool idValido;
                do
                {
                    idSelecionado = (Caixas)repositorioCaixas.SelecionarId(ObterIdEscolhido("Digite o ID da Caixa que deseja editar: "));

                    idSelecionado = (Caixas)ValidaId(idSelecionado);

                    idValido = idSelecionado != null;

                } while (!idValido);

                Caixas infoCaixaAtualizado = ObterCadastroCaixa();

                repositorioCaixas.Editar(idSelecionado, infoCaixaAtualizado);

                VisualizarCaixas();

                MensagemColor($"\nCaixa editada com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        private void ExcluirCadastroCaixa()
        {
            VisualizarCaixas();

            if (ValidaListaVazia(repositorioCaixas.listaDados))
            {
                Caixas idSelecionado; bool idValido;
                do
                {
                    idSelecionado = (Caixas)repositorioCaixas.SelecionarId(ObterIdEscolhido("Digite o ID da Caixa que deseja excluir: "));

                    idSelecionado = (Caixas)ValidaId(idSelecionado);

                    idValido = idSelecionado != null;

                } while (!idValido);

                repositorioCaixas.Excluir(idSelecionado);

                VisualizarCaixas();

                MensagemColor("\nCaixa excluída com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
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

        private Caixas ObterCadastroCaixa()
        {
            Caixas infoCaixa = new()
            {
                etiqueta = ObterEtiqueta(),
                cor = ObterCor(),
            };

            return infoCaixa;
        }

        private string ObterEtiqueta()
        {
            Console.Write("Escreva o nome da Etiqueta: ");
            string etiqueta = Console.ReadLine();
            return etiqueta;
        }

        private string ObterCor()
        {
            Console.Write("Escreva a Cor da Caixa: ");
            string cor = Console.ReadLine();
            return cor;
        }
    }
}
