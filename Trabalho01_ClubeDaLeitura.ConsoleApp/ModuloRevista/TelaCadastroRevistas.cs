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

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class TelaCadastroRevistas : Tela
    {
        public void EscolherOpcaoMenu()
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenu("Revista");

                continuar = InicializarOpcaoEscolhida();
            }
        }

        public void AdicionarCadastroRevista()
        {
            VisualizarRevistas();

            Revistas infoRevista = ObterCadastroRevista();

            repositorioRevistas.Adicionar(infoRevista);

            VisualizarRevistas();

            MensagemColor("\nRevista adicionada com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public void EditarCadastroRevista()
        {
            VisualizarRevistas();

            if (ValidaListaVazia(repositorioRevistas.listaDados))
            {
                Revistas idCadastroRevistaSelecionado = ValidaIdRevistas("editar");

                Revistas infoRevistaAtualizado = ObterCadastroRevista();

                repositorioRevistas.Editar(idCadastroRevistaSelecionado, infoRevistaAtualizado);

                VisualizarRevistas();

                MensagemColor("\nRevista editada com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        public void ExcluirCadastroRevista()
        {
            VisualizarRevistas();

            if (ValidaListaVazia(repositorioRevistas.listaDados))
            {
                Revistas idCadastroRevistaSelecionado = ValidaIdRevistas("excluir");

                repositorioRevistas.Excluir(idCadastroRevistaSelecionado);

                VisualizarRevistas();

                MensagemColor("\nRevista excluída com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        public void VisualizarRevistas()
        {
            Console.Clear();

            Console.WriteLine("╔══════════════════╗");
            Console.WriteLine("║     Revistas     ║");
            Console.WriteLine("╚══════════════════╝");
            PulaLinha();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0, -10} │ {1, -20} │ {2, -15} │ {3, -15} │ {4, -15}", "ID", "Tipo de Coleção", "N°Edição", "Ano", "Caixa");
            Console.WriteLine("".PadRight(87, '―'));
            Console.ResetColor();

            foreach (Revistas info in repositorioRevistas.GetListaDados())
            {
                TextoZebrado();

                Console.WriteLine("{0, -10} │ {1, -20} │ {2, -15} │ {3, -15} │ {4, -15}", info.id, info.colecao, info.edicao, info.ano, info.caixa == null ? "<Sem Caixa>" : info.caixa.etiqueta);
            }

            Console.ResetColor();

            PulaLinha();
        }

        private bool InicializarOpcaoEscolhida()
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

        private Revistas ObterCadastroRevista()
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

        private static string ObterColecao()
        {
            Console.Write("Escreva o Tipo de Coleção: ");
            string colecao = Console.ReadLine();
            return colecao;
        }

        private int ObterEdicao()
        {
            int edicao = ValidaNumero("Escreva o Número da Edição: ");
            return edicao;
        }

        private int ObterAno()
        {
            int ano = ValidaNumero("Escreva o Ano da Revista: ");
            return ano;
        }

        private Caixas ObterCaixa()
        {
            telaCadastroCaixa.VisualizarCaixas();
            if (ValidaListaVazia(repositorioCaixas.listaDados))
            {
                Caixas caixa = telaCadastroCaixa.ValidaIdCaixas("guardar a Revista: ");
                return caixa;
            }
            Console.ReadLine();
            return null;
        }

        public Revistas ValidaIdRevistas(string tipo)
        {
            Revistas caixa;

            do
            {
                caixa = repositorioRevistas.SelecionarId(ObterIdEscolhido(tipo));

                if (caixa == null)
                {
                    MensagemColor("Atenção, apenas ID`s existentes\n", ConsoleColor.Red);
                }

            } while (caixa == null);

            return caixa;
        }
    }
}
