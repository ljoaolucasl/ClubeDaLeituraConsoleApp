using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class Repositorio
    {
        public ArrayList listaDados = new();

        public int id = 1;

        public void Adicionar(Entidade registro)
        {
            DefinirId(registro);
            IncrementarId();
            listaDados.Add(registro);
        }

        public void Excluir(Entidade idCadastroRegistroSelecionado)
        {
            int idEscolhidoIndex = listaDados.IndexOf(idCadastroRegistroSelecionado);

            listaDados.RemoveAt(idEscolhidoIndex);

            ItemRemovido(idCadastroRegistroSelecionado);
        }

        public virtual void ItemRemovido(Entidade idCadastroAmigoSelecionado) { }

        public Entidade SelecionarId(int idEscolhido)
        {
            while (true)
            {
                foreach (Entidade registro in listaDados)
                {
                    if (registro.id == idEscolhido)
                    {
                        return registro;
                    }
                }
                return null;
            }
        }

        public ArrayList GetListaDados()
        {
            return listaDados;
        }

        private void IncrementarId()
        {
            id++;
        }

        private void DefinirId(Entidade dados)
        {
            dados.id = id;
        }
    }
}
