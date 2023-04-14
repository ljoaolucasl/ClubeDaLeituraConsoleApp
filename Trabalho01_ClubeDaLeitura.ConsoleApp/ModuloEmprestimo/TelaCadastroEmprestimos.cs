using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class TelaCadastroEmprestimos : Tela
    {
        public void EscolherOpcaoMenu()
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenu("Empréstimo");

                continuar = InicializarOpcaoEscolhida();
            }
        }

        public void AdicionarCadastroEmprestimo()
        {
            VisualizarEmprestimos();

            Emprestimos infoEmprestimo = ObterCadastroEmprestimo();

            repositorioEmprestimos.Adicionar(infoEmprestimo);

            VisualizarEmprestimos();

            MensagemColor("\nEmprestimo adicionada com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public void EditarCadastroEmprestimo()
        {
            VisualizarEmprestimos();

            if (ValidaListaVazia(repositorioEmprestimos.listaDados))
            {
                Emprestimos idCadastroEmprestimoSelecionado = ValidaIdEmprestimos("editar");

                Emprestimos infoEmprestimoAtualizado = ObterCadastroEmprestimo();

                repositorioEmprestimos.Editar(idCadastroEmprestimoSelecionado, infoEmprestimoAtualizado);

                VisualizarEmprestimos();

                MensagemColor("\nEmprestimo editada com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        public void ExcluirCadastroEmprestimo()
        {
            VisualizarEmprestimos();

            if (ValidaListaVazia(repositorioEmprestimos.listaDados))
            {
                Emprestimos idCadastroEmprestimoSelecionado = ValidaIdEmprestimos("excluir");

                repositorioEmprestimos.Excluir(idCadastroEmprestimoSelecionado);

                VisualizarEmprestimos();

                MensagemColor("\nEmprestimo excluída com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        public void VisualizarEmprestimos()
        {
            Console.Clear();

            Console.WriteLine("╔══════════════════╗");
            Console.WriteLine("║   Empréstimos    ║");
            Console.WriteLine("╚══════════════════╝");
            PulaLinha();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0, -10} | {1, -25} | {2, -15} | {3, -15} | {4, -15}", "ID", "Amigo", "Revista", "Emprestimo", "Data Devolução");
            Console.WriteLine("".PadRight(92, '―'));
            Console.ResetColor();

            foreach (Emprestimos info in repositorioEmprestimos.GetListaDados())
            {
                TextoZebrado();

                Console.WriteLine("{0, -10} | {1, -25} | {2, -15} | {3, -15} | {4, -15}", info.id, info.amigo == null ? "<Desconhecido>" : info.amigo.nome, info.revista == null ? "<Desconhecido>" : info.revista.edicao, info.dataEmprestimo.ToString("d"), info.dataDevolucao.ToString("d"));
            }

            Console.ResetColor();

            PulaLinha();
        }

        private bool InicializarOpcaoEscolhida()
        {
            string entrada = Console.ReadLine();

            switch (entrada.ToUpper())
            {
                case "1": VisualizarEmprestimos(); Console.ReadLine(); break;
                case "2": AdicionarCadastroEmprestimo(); break;
                case "3": EditarCadastroEmprestimo(); break;
                case "4": ExcluirCadastroEmprestimo(); break;
                case "S": return false; break;
                default: break;
            }
            return true;
        }

        private Emprestimos ObterCadastroEmprestimo()
        {
            Emprestimos infoEmprestimo = new()
            {
                amigo = ObterAmigo(),
                revista = ObterRevista(),
                dataEmprestimo = ObterDataEmprestimo(),
                dataDevolucao = ObterDataDevolucao()
            };

            return infoEmprestimo;
        }

        private Amigos ObterAmigo()
        {
            telaCadastroAmigos.VisualizarAmigos();

            if (ValidaListaVazia(repositorioCaixas.listaDados))
            {
                Amigos amigo = telaCadastroAmigos.ValidaIdAmigos("fazer o emprestimo: ");
                return amigo;
            }
            Console.ReadLine();
            return null;
        }

        private Revistas ObterRevista()
        {
            telaCadastroRevistas.VisualizarRevistas();

            if (ValidaListaVazia(repositorioCaixas.listaDados))
            {
                Revistas revista = telaCadastroRevistas.ValidaIdRevistas("emprestar: ");
                return revista;
            }
            Console.ReadLine();
            return null;
        }

        private DateTime ObterDataEmprestimo()
        {
            DateTime dataEmprestimo = ValidaData("Escreva a Data do Empréstimo: ");
            return dataEmprestimo;
        }

        private DateTime ObterDataDevolucao()
        {
            DateTime dataDevolucao = ValidaData("Escreva a Data da Devolução: ");
            return dataDevolucao;
        }

        private Emprestimos ValidaIdEmprestimos(string tipo)
        {
            Emprestimos dataDevolucao;

            do
            {
                dataDevolucao = repositorioEmprestimos.SelecionarId(ObterIdEscolhido(tipo));

                if (dataDevolucao == null)
                {
                    MensagemColor("Atenção, apenas ID`s existentes\n", ConsoleColor.Red);
                }

            } while (dataDevolucao == null);

            return dataDevolucao;
        }

        private DateTime ValidaData(string mensagem)
        {
            bool validaData;
            string entrada;
            DateTime dataAbertura;

            do
            {
                Console.Write(mensagem);

                entrada = Console.ReadLine();

                validaData = DateTime.TryParse(entrada, out dataAbertura);

                if (!validaData)
                {
                    MensagemColor("Atenção, escreva uma data válida\n", ConsoleColor.Red);
                }

            } while (!validaData);

            return dataAbertura;
        }
    }
}
