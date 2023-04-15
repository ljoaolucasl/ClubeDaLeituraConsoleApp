﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class RepositorioEmprestimos : Repositorio
    {
        public RepositorioAmigos repositorioAmigos = null;

        public RepositorioRevistas repositorioRevistas = null;

        public void Adicionar(Emprestimos infoEmprestimo)
        {
            DefinirId(infoEmprestimo);
            IncrementarId();
            listaDados.Add(infoEmprestimo);
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

        public void Devolver(Emprestimos idCadastroEmprestimoSelecionado)
        {
            idCadastroEmprestimoSelecionado.situacao = "DEVOLVIDO";
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

        public void PreCadastrarEmprestimos()
        {
            Emprestimos emprestimo1 = new();
            emprestimo1.amigo = repositorioAmigos.SelecionarId(1);
            emprestimo1.revista = repositorioRevistas.SelecionarId(1);
            emprestimo1.dataEmprestimo = DateTime.Parse("05/03/2023");
            emprestimo1.dataDevolucao = DateTime.Parse("22/06/2023");

            Adicionar(emprestimo1);

            Emprestimos emprestimo2 = new();
            emprestimo2.amigo = repositorioAmigos.SelecionarId(2);
            emprestimo2.revista = repositorioRevistas.SelecionarId(2);
            emprestimo2.dataEmprestimo = DateTime.Parse("12/02/2023");
            emprestimo2.dataDevolucao = DateTime.Parse("14/08/2023");

            Adicionar(emprestimo2);

            Emprestimos emprestimo3 = new();
            emprestimo3.amigo = repositorioAmigos.SelecionarId(3);
            emprestimo3.revista = repositorioRevistas.SelecionarId(3);
            emprestimo3.dataEmprestimo = DateTime.Parse("08/01/2023");
            emprestimo3.dataDevolucao = DateTime.Parse("09/03/2023");

            Adicionar(emprestimo3);
        }

        private void DefinirId(Emprestimos cadastroEmprestimo)
        {
            cadastroEmprestimo.id = id;
        }
    }
}
