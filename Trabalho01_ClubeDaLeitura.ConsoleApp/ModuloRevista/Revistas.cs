using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class Revistas : Entidade
    {
        public string titulo;
        public string colecao;
        public int edicao;
        public int ano;
        public Caixas caixa;
    }
}
