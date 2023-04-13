using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigos : Repositorio
    {
        public void Adicionar(Amigos infoAmigo)
        {
            Amigos cadastroAmigo = new();

            DefinirId(cadastroAmigo);
            IncrementarId();
            cadastroAmigo.nome = infoAmigo.nome;
            cadastroAmigo.nomeResponsavel = infoAmigo.nomeResponsavel;
            cadastroAmigo.telefone = infoAmigo.telefone;
            cadastroAmigo.endereco = infoAmigo.endereco;

            listaDados.Add(cadastroAmigo);
        }

        public void Editar(Amigos idCadastroAmigoSelecionado, Amigos infoAmigoAtualizado)
        {
            idCadastroAmigoSelecionado.nome = infoAmigoAtualizado.nome;
            idCadastroAmigoSelecionado.nomeResponsavel = infoAmigoAtualizado.nomeResponsavel;
            idCadastroAmigoSelecionado.telefone = infoAmigoAtualizado.telefone;
            idCadastroAmigoSelecionado.endereco = infoAmigoAtualizado.endereco;
        }

        public void Excluir(Amigos idCadastroAmigoSelecionado)
        {
            int idEscolhidoIndex = listaDados.IndexOf(idCadastroAmigoSelecionado);

            listaDados.RemoveAt(idEscolhidoIndex);
        }

        public Amigos SelecionarId(int idEscolhido)
        {
            while (true)
            {
                foreach (Amigos amigo in listaDados)
                {
                    if (amigo.id == idEscolhido)
                    {
                        return amigo;
                    }
                }
                return null;
            }
        }

        private void DefinirId(Amigos cadastroAmigo)
        {
            cadastroAmigo.id = id;
        }
    }
}
