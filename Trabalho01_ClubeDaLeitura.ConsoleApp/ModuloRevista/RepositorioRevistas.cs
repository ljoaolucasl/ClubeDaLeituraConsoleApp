using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevistas : Repositorio
    {
        public void Adicionar(Revistas infoRevista)
        {
            Revistas cadastroRevista = new();

            DefinirId(cadastroRevista);
            IncrementarId();
            cadastroRevista.colecao = infoRevista.colecao;
            cadastroRevista.edicao = infoRevista.edicao;
            cadastroRevista.ano = infoRevista.ano;
            cadastroRevista.caixa = infoRevista.caixa;

            listaDados.Add(cadastroRevista);
        }

        public void Editar(Revistas idCadastroRevistaSelecionado, Revistas infoRevistaAtualizado)
        {
            idCadastroRevistaSelecionado.colecao = infoRevistaAtualizado.colecao;
            idCadastroRevistaSelecionado.edicao = infoRevistaAtualizado.edicao;
            idCadastroRevistaSelecionado.ano = infoRevistaAtualizado.ano;
            idCadastroRevistaSelecionado.caixa = infoRevistaAtualizado.caixa;
        }

        public void Excluir(Revistas idCadastroRevistaSelecionado)
        {
            int idEscolhidoIndex = listaDados.IndexOf(idCadastroRevistaSelecionado);

            listaDados.RemoveAt(idEscolhidoIndex);
        }

        public Revistas SelecionarId(int idEscolhido)
        {
            while (true)
            {
                foreach (Revistas Revista in listaDados)
                {
                    if (Revista.id == idEscolhido)
                    {
                        return Revista;
                    }
                }
                return null;
            }
        }

        private void DefinirId(Revistas cadastroRevista)
        {
            cadastroRevista.id = id;
        }
    }
}
