using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevistas
    {
        private static ArrayList listaRevistas = new();

        private static int id = 1;

        public static ArrayList GetListaRevistas()
        {
            return listaRevistas;
        }

        public static void Adicionar(Revistas infoRevista)
        {
            Revistas cadastroRevista = new();

            IncrementarEDefinirID(cadastroRevista);
            cadastroRevista.colecao = infoRevista.colecao;
            cadastroRevista.edicao = infoRevista.edicao;
            cadastroRevista.ano = infoRevista.ano;
            cadastroRevista.caixa = infoRevista.caixa;

            listaRevistas.Add(cadastroRevista);
        }

        public static void Editar(Revistas idCadastroRevistaSelecionado, Revistas infoRevistaAtualizado)
        {
            idCadastroRevistaSelecionado.colecao = infoRevistaAtualizado.colecao;
            idCadastroRevistaSelecionado.edicao = infoRevistaAtualizado.edicao;
            idCadastroRevistaSelecionado.ano = infoRevistaAtualizado.ano;
            idCadastroRevistaSelecionado.caixa = infoRevistaAtualizado.caixa;
        }

        public static void Excluir(Revistas idCadastroRevistaSelecionado)
        {
            int idEscolhidoIndex = listaRevistas.IndexOf(idCadastroRevistaSelecionado);

            listaRevistas.RemoveAt(idEscolhidoIndex);
        }

        public static Revistas SelecionarId(int idEscolhido)
        {
            while (true)
            {
                foreach (Revistas Revista in listaRevistas)
                {
                    if (Revista.id == idEscolhido)
                    {
                        return Revista;
                    }
                }
                return null;
            }
        }

        #region private

        private static void IncrementarEDefinirID(Revistas cadastroRevista)
        {
            cadastroRevista.id = id;
            id++;
        }

        #endregion
    }
}
