using System.Data;
using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class TelaCadastroEmprestimos : Tela
    {
        public RepositorioAmigos repositorioAmigos = null;
        public RepositorioRevistas repositorioRevistas = null;
        public RepositorioEmprestimos repositorioEmprestimos = null;
        public TelaCadastroAmigos telaCadastroAmigos = null;
        public TelaCadastroRevistas telaCadastroRevistas = null;

        public void EscolherOpcaoMenu()
        {
            bool continuar = true;

            while (continuar)
            {
                MostrarMenu("Empréstimo", ConsoleColor.DarkCyan);

                continuar = InicializarOpcaoEscolhida();
            }
        }

        public void VisualizarEmprestimos()
        {
            Console.Clear();

            ConsoleColor cor;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("╔" + "".PadRight(127, '═') + "╗");
            Console.WriteLine("║                                                          Emprétimos                                                           ║");
            Console.WriteLine("╚" + "".PadRight(127, '═') + "╝");
            PulaLinha();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string espacamento = "{0, -5} │ {1, -30} │ {2, -30} │ {3, -17} │ {4, -17} │ ";
            Console.Write(espacamento, "ID", "Amigo", "Revista", "Data Empréstimo", "Data Devolução");
            Console.WriteLine("{0, -15}", "Situação");
            Console.WriteLine("".PadRight(129, '―'));
            Console.ResetColor();

            foreach (Emprestimos info in repositorioEmprestimos.GetListaDados())
            {
                TextoZebrado();

                if (info.situacao == "DEVOLVIDO")
                    cor = ConsoleColor.Green;

                else if (DateTime.Now < info.dataDevolucao)
                { info.situacao = "ABERTO"; cor = ConsoleColor.White; }

                else
                { info.situacao = "ATRASADO"; cor = ConsoleColor.DarkRed; }

                Console.Write(espacamento, info.id, info.amigo == null ? "<Desconhecido>" : info.amigo.nome, info.revista == null ? "<Desconhecido>" : info.revista.titulo, info.dataEmprestimo.ToString("d"), info.dataDevolucao.ToString("d"));
                Console.ForegroundColor = cor;
                Console.WriteLine("{0, -15}", info.situacao);
                Console.ResetColor();
            }

            Console.ResetColor();
            zebra = true;

            PulaLinha();
        }

        private void AdicionarCadastroEmprestimo()
        {
            VisualizarEmprestimos();

            Emprestimos infoEmprestimo = ObterCadastroEmprestimo();

            if(infoEmprestimo == null)
            {
                MensagemColor("Esse Amigo ainda não devolveu a Revista!", ConsoleColor.Red);
                Console.ReadLine();
                return;
            }

            repositorioEmprestimos.Adicionar(infoEmprestimo);

            VisualizarEmprestimos();

            MensagemColor("\nEmpréstimo adicionado com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        private void EditarCadastroEmprestimo()
        {
            VisualizarEmprestimos();

            if (ValidaListaVazia(repositorioEmprestimos.listaDados))
            {
                Emprestimos idSelecionado; bool idValido;
                do
                {
                    idSelecionado = (Emprestimos)repositorioEmprestimos.SelecionarId(ObterIdEscolhido("Digite o ID do Empréstimo que deseja editar: "));

                    idSelecionado = (Emprestimos)ValidaId(idSelecionado);

                    idValido = idSelecionado != null;

                } while (!idValido);

                Emprestimos infoEmprestimoAtualizado = ObterCadastroEmprestimo();

                if (infoEmprestimoAtualizado == null)
                {
                    MensagemColor("Esse Amigo ainda não devolveu a Revista!", ConsoleColor.Red);
                    Console.ReadLine();
                    return;
                }

                repositorioEmprestimos.Editar(idSelecionado, infoEmprestimoAtualizado);

                VisualizarEmprestimos();

                MensagemColor("\nEmpréstimo editado com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        private void ExcluirCadastroEmprestimo()
        {
            VisualizarEmprestimos();

            if (ValidaListaVazia(repositorioEmprestimos.listaDados))
            {
                Emprestimos idSelecionado; bool idValido;
                do
                {
                    idSelecionado = (Emprestimos)repositorioEmprestimos.SelecionarId(ObterIdEscolhido("Digite o ID do Empréstimo que deseja excluir: "));

                    idSelecionado = (Emprestimos)ValidaId(idSelecionado);

                    idValido = idSelecionado != null;

                } while (!idValido);

                repositorioEmprestimos.Excluir(idSelecionado);

                VisualizarEmprestimos();

                MensagemColor("\nEmprestimo excluído com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        private void ConfirmarDevolucoes()
        {
            VisualizarEmprestimos();

            if (ValidaListaVazia(repositorioEmprestimos.listaDados))
            {
                Emprestimos idSelecionado; bool idValido;
                do
                {
                    idSelecionado = (Emprestimos)repositorioEmprestimos.SelecionarId(ObterIdEscolhido("Digite o ID para confirmar a Devolução da Revista: "));

                    idSelecionado = (Emprestimos)ValidaId(idSelecionado);

                    idValido = idSelecionado != null;

                } while (!idValido);

                repositorioEmprestimos.Devolver(idSelecionado);

                VisualizarEmprestimos();

                MensagemColor($"\nA Revista foi devolvida!", ConsoleColor.Green);
            }

            Console.ReadLine();
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
                case "5": ConfirmarDevolucoes(); break;
                case "S": return false; break;
                default: break;
            }
            return true;
        }

        private Emprestimos ObterCadastroEmprestimo()
        {
            Emprestimos infoEmprestimo = new();

            infoEmprestimo.amigo = ObterAmigo();
            if (infoEmprestimo.amigo == null)
                return null;

            infoEmprestimo.revista = ObterRevista();
            infoEmprestimo.dataEmprestimo = ObterDataEmprestimo();
            infoEmprestimo.dataDevolucao = ObterDataDevolucao();

            return infoEmprestimo;
        }

        private Amigos ObterAmigo()
        {
            telaCadastroAmigos.VisualizarAmigos();

            if (ValidaListaVazia(repositorioAmigos.listaDados))
            {
                Amigos amigo; bool idValido;
                do
                {
                    amigo = (Amigos)repositorioAmigos.SelecionarId(ObterIdEscolhido("Digite o ID do Amigo que deseja o empréstimo: "));

                    amigo = (Amigos)ValidaId(amigo);

                    idValido = amigo != null;

                } while (!idValido);

                foreach (Emprestimos info in repositorioEmprestimos.GetListaDados())
                {
                    if (info.amigo.id == amigo.id && info.situacao != "DEVOLVIDO")
                        return null;
                }

                return amigo;
            }
            Console.ReadLine();
            return null;
        }

        private Revistas ObterRevista()
        {
            telaCadastroRevistas.VisualizarRevistas();

            if (ValidaListaVazia(repositorioRevistas.listaDados))
            {
                Revistas revista; bool idValido;
                do
                {
                    revista = (Revistas)repositorioRevistas.SelecionarId(ObterIdEscolhido("Digite o ID da Revista que deseja emprestar: "));

                    revista = (Revistas)ValidaId(revista);

                    idValido = revista != null;

                } while (!idValido);

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
