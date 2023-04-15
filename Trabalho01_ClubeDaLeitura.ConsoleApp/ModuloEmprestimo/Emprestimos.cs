using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimos : Entidade
    {
        public Amigos amigo;
        public Revistas revista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public string situacao;
    }
}
