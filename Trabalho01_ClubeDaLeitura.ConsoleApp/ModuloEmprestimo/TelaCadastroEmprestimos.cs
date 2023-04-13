using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
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

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0, -10} | {1, -25} | {2, -15} | {3, -15}", "ID", "Nome", "Emprestimo", "Data Devolução");
            Console.WriteLine("".PadRight(80, '―'));
            Console.ResetColor();

            foreach (Emprestimos info in repositorioEmprestimos.GetListaDados())
            {
                TextoZebrado();

                Console.WriteLine("{0, -10} | {1, -25} | {2, -15} | {3, -15} | {4, -15}", info.id, info.amigo, info.dataEmprestimo, info.dataDevolucao);
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
            Amigos amigo = telaCadastroAmigos.ValidaIdAmigos("fazer o emprestimo: ");
            return amigo;
        }

        private Revistas ObterRevista()
        {
            telaCadastroRevistas.VisualizarRevistas();
            Revistas revista = telaCadastroRevistas.ValidaIdRevistas("emprestar: ");
            return revista;
        }

        private DateTime ObterDataEmprestimo()
        {
            DateTime dataEmprestimo = ValidaData("Escreva a Data do Emprestimo: ");
            return dataEmprestimo;
        }

        private DateTime ObterDataDevolucao()
        {
            DateTime dataDevolucao = ValidaData("Escreva a Data do Emprestimo: ");
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

        //public static ArrayList listaEmprestimo = new();

        //private Emprestimos infoEmprestimo = new();

        //public static int Id { get; private set; } = 1;

        //public void EfetuarCadastroAmigo()
        //{
        //    ObterAmigo();
        //    ObterEmprestimo();
        //    ObterDataEmprestimo();
        //    ObterDataDevolucao();
        //    ObterId();

        //    listaEmprestimo.Add(infoEmprestimo);
        //}

        //public void VisualizarEmprestimo()
        //{
        //    Console.Clear();

        //    Console.ForegroundColor = ConsoleColor.Blue;
        //    Console.WriteLine("{0, -10} | {1, -25} | {2, -15} | {3, -15} | {4, -15}", "ID", "Nome", "Emprestimo", "Data Emprestimo", "Data Devolução");
        //    Console.WriteLine("".PadRight(80, '―'));
        //    Console.ResetColor();

        //    foreach (Emprestimos info in listaEmprestimo)
        //    {
        //        Console.WriteLine("{0, -10} | {1, -25} | {2, -15} | {3, -15} | {4, -15}", info.id, info.amigo, info.Emprestimo, info.dataEmprestimo, info.dataDevolucao);
        //    }
        //}

        //private void ObterId()
        //{
        //    infoEmprestimo.id = Id;
        //    Id++;
        //}

        //private void ObterAmigo()
        //{
        //    Console.Write("Escreva o ID do Amigo: ");
        //    //infoEmprestimo.amigo = Console.ReadLine();
        //}

        //private void ObterEmprestimo()
        //{
        //    Console.Write("Escreva o ID da Emprestimo");
        //    //infoEmprestimo.Emprestimo = Console.ReadLine();
        //}

        //private void ObterDataEmprestimo()
        //{
        //    Console.Write("Escreva a Data do Emprestimo: ");
        //    infoEmprestimo.dataEmprestimo = DateTime.Parse(Console.ReadLine());
        //}

        //private void ObterDataDevolucao()
        //{
        //    Console.Write("Escreva a Data da Devolução: ");
        //    infoEmprestimo.dataDevolucao = DateTime.Parse(Console.ReadLine());
        //}
    }
}
