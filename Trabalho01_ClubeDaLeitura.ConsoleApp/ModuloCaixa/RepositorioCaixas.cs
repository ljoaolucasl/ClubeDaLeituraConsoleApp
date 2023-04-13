using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixas : Repositorio
    {
        public void Adicionar(Caixas infoCaixa)
        {
            Caixas cadastroCaixa = new();

            DefinirId(cadastroCaixa);
            IncrementarId();
            cadastroCaixa.etiqueta = infoCaixa.etiqueta;
            cadastroCaixa.cor = infoCaixa.cor;

            listaDados.Add(cadastroCaixa);
        }

        public void Editar(Caixas idCadastroCaixaSelecionado, Caixas infoCaixaAtualizado)
        {
            idCadastroCaixaSelecionado.etiqueta = infoCaixaAtualizado.etiqueta;
            idCadastroCaixaSelecionado.cor = infoCaixaAtualizado.cor;
        }

        public void Excluir(Caixas idCadastroCaixaSelecionado)
        {
            int idEscolhidoIndex = listaDados.IndexOf(idCadastroCaixaSelecionado);

            idCadastroCaixaSelecionado.etiqueta += "<Removed>";

            listaDados.RemoveAt(idEscolhidoIndex);
        }

        public Caixas SelecionarId(int idEscolhido)
        {
            while (true)
            {
                foreach (Caixas Caixa in listaDados)
                {
                    if (Caixa.id == idEscolhido)
                    {
                        return Caixa;
                    }
                }
                return null;
            }
        }

        private void DefinirId(Caixas cadastroCaixa)
        {
            cadastroCaixa.id = id;
        }
    }
}
