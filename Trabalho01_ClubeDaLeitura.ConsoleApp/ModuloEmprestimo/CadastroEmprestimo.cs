using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class CadastroEmprestimo
    {
        public static ArrayList listaEmprestimo = new();

        private Emprestimo infoEmprestimo = new();

        public static int Id { get; private set; } = 1;

        public void EfetuarCadastroAmigo()
        {
            ObterAmigo();
            ObterRevista();
            ObterDataEmprestimo();
            ObterDataDevolucao();
            ObterId();

            listaEmprestimo.Add(infoEmprestimo);
        }

        public void VisualizarEmprestimo()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0, -10} | {1, -25} | {2, -15} | {3, -15} | {4, -15}", "ID", "Nome", "Revista", "Data Emprestimo", "Data Devolução");
            Console.WriteLine("".PadRight(80, '―'));
            Console.ResetColor();

            foreach (Emprestimo info in listaEmprestimo)
            {
                Console.WriteLine("{0, -10} | {1, -25} | {2, -15} | {3, -15} | {4, -15}", info.id, info.amigo, info.revista, info.dataEmprestimo, info.dataDevolucao);
            }
        }

        private void ObterId()
        {
            infoEmprestimo.id = Id;
            Id++;
        }

        private void ObterAmigo()
        {
            Console.Write("Escreva o ID do Amigo: ");
            //infoEmprestimo.amigo = Console.ReadLine();
        }

        private void ObterRevista()
        {
            Console.Write("Escreva o ID da Revista");
            //infoEmprestimo.revista = Console.ReadLine();
        }

        private void ObterDataEmprestimo()
        {
            Console.Write("Escreva a Data do Emprestimo: ");
            infoEmprestimo.dataEmprestimo = DateTime.Parse(Console.ReadLine());
        }

        private void ObterDataDevolucao()
        {
            Console.Write("Escreva a Data da Devolução: ");
            infoEmprestimo.dataDevolucao = DateTime.Parse(Console.ReadLine());
        }
    }
}
