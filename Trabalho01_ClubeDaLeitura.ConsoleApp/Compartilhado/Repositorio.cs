using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class Repositorio
    {
        public ArrayList listaDados = new();

        public int id = 1;

        public ArrayList GetListaDados()
        {
            return listaDados;
        }

        public void IncrementarId()
        {
            id++;
        }
    }
}
