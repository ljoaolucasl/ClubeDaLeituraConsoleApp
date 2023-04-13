using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo
    {
        public int id;
        public TelaCadastroAmigos amigo;
        public TelaCadastroRevistas revista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
    }
}
