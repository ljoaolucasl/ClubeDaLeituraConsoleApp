using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class RepositorioEmprestimos : Repositorio
    {
        public void Adicionar(Emprestimos infoEmprestimo)
        {
            Emprestimos cadastroEmprestimo = new();

            DefinirId(cadastroEmprestimo);
            IncrementarId();
            cadastroEmprestimo.amigo = infoEmprestimo.amigo;
            cadastroEmprestimo.revista = infoEmprestimo.revista;
            cadastroEmprestimo.dataEmprestimo = infoEmprestimo.dataEmprestimo;
            cadastroEmprestimo.dataDevolucao = infoEmprestimo.dataDevolucao;

            listaDados.Add(cadastroEmprestimo);
        }

        public void Editar(Emprestimos idCadastroEmprestimoSelecionado, Emprestimos infoEmprestimoAtualizado)
        {
            idCadastroEmprestimoSelecionado.amigo = infoEmprestimoAtualizado.amigo;
            idCadastroEmprestimoSelecionado.revista = infoEmprestimoAtualizado.revista;
            idCadastroEmprestimoSelecionado.dataEmprestimo = infoEmprestimoAtualizado.dataEmprestimo;
            idCadastroEmprestimoSelecionado.dataDevolucao = infoEmprestimoAtualizado.dataDevolucao;
        }

        public void Excluir(Emprestimos idCadastroEmprestimoSelecionado)
        {
            int idEscolhidoIndex = listaDados.IndexOf(idCadastroEmprestimoSelecionado);

            listaDados.RemoveAt(idEscolhidoIndex);
        }

        public Emprestimos SelecionarId(int idEscolhido)
        {
            while (true)
            {
                foreach (Emprestimos Emprestimo in listaDados)
                {
                    if (Emprestimo.id == idEscolhido)
                    {
                        return Emprestimo;
                    }
                }
                return null;
            }
        }

        private void DefinirId(Emprestimos cadastroEmprestimo)
        {
            cadastroEmprestimo.id = id;
        }
    }
}
