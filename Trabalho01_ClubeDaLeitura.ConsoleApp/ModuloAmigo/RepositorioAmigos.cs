using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigos
    {
        private static ArrayList listaAmigos = new();

        private static int id = 1;

        public static ArrayList GetListaAmigos()
        {
            return listaAmigos;
        }

        public static void Adicionar(Amigos infoAmigo)
        {
            Amigos cadastroAmigo = new();

            IncrementarEDefinirID(cadastroAmigo);
            cadastroAmigo.nome = infoAmigo.nome;
            cadastroAmigo.nomeResponsavel = infoAmigo.nomeResponsavel;
            cadastroAmigo.telefone = infoAmigo.telefone;
            cadastroAmigo.endereco = infoAmigo.endereco;

            listaAmigos.Add(cadastroAmigo);
        }

        public static void Editar(Amigos idCadastroAmigoSelecionado, Amigos infoAmigoAtualizado)
        {
            idCadastroAmigoSelecionado.nome = infoAmigoAtualizado.nome;
            idCadastroAmigoSelecionado.nomeResponsavel = infoAmigoAtualizado.nomeResponsavel;
            idCadastroAmigoSelecionado.telefone = infoAmigoAtualizado.telefone;
            idCadastroAmigoSelecionado.endereco = infoAmigoAtualizado.endereco;
        }

        public static void Excluir(Amigos idCadastroAmigoSelecionado)
        {
            int idEscolhidoIndex = listaAmigos.IndexOf(idCadastroAmigoSelecionado);

            listaAmigos.RemoveAt(idEscolhidoIndex);
        }

        public static Amigos SelecionarId(int idEscolhido)
        {
            while (true)
            {
                foreach (Amigos amigo in listaAmigos)
                {
                    if (amigo.id == idEscolhido)
                    {
                        return amigo;
                    }
                }
                return null;
            }
        }

        #region private

        private static void IncrementarEDefinirID(Amigos cadastroAmigo)
        {
            cadastroAmigo.id = id;
            id++;
        }

        #endregion
    }
}
