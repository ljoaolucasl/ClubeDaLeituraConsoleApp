using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevistas : Repositorio
    {
        public RepositorioCaixas repositorioCaixas = null;

        public void Adicionar(Revistas infoRevista)
        {
            DefinirId(infoRevista);
            IncrementarId();
            listaDados.Add(infoRevista);
        }

        public void Editar(Revistas idCadastroRevistaSelecionado, Revistas infoRevistaAtualizado)
        {
            idCadastroRevistaSelecionado.titulo = infoRevistaAtualizado.titulo;
            idCadastroRevistaSelecionado.colecao = infoRevistaAtualizado.colecao;
            idCadastroRevistaSelecionado.edicao = infoRevistaAtualizado.edicao;
            idCadastroRevistaSelecionado.ano = infoRevistaAtualizado.ano;
            idCadastroRevistaSelecionado.caixa = infoRevistaAtualizado.caixa;
        }

        public void Excluir(Revistas idCadastroRevistaSelecionado)
        {
            int idEscolhidoIndex = listaDados.IndexOf(idCadastroRevistaSelecionado);

            idCadastroRevistaSelecionado.titulo += "<Removed>";

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

        public void PreCadastrarRevistas()
        {
            Revistas revista1 = new();
            revista1.titulo = "Superman e a Rocha Inquebrável";
            revista1.colecao = "Superman";
            revista1.edicao = 5487;
            revista1.ano = 2020;
            revista1.caixa = repositorioCaixas.SelecionarId(1);

            Adicionar(revista1);

            Revistas revista2 = new();
            revista2.titulo = "Capitão América: Guerra Civil";
            revista2.colecao = "Os Vingadores";
            revista2.edicao = 4782;
            revista2.ano = 2015;
            revista2.caixa = repositorioCaixas.SelecionarId(2);

            Adicionar(revista2);

            Revistas revista3 = new();
            revista3.titulo = "Cebolinha e o Sorvete Gigante";
            revista3.colecao = "Turma da Mônica Jovem";
            revista3.edicao = 3324;
            revista3.ano = 2018;
            revista3.caixa = repositorioCaixas.SelecionarId(3);

            Adicionar(revista3);
        }

        private void DefinirId(Revistas cadastroRevista)
        {
            cadastroRevista.id = id;
        }
    }
}
