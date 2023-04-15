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
            DefinirId(infoCaixa);
            IncrementarId();
            listaDados.Add(infoCaixa);
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

        public void PreCadastrarCaixas()
        {
            Caixas caixa1 = new();
            caixa1.etiqueta = "DC";
            caixa1.cor = "Azul";

            Adicionar(caixa1);

            Caixas caixa2 = new();
            caixa2.etiqueta = "Marvel";
            caixa2.cor = "Vermelha";

            Adicionar(caixa2);

            Caixas caixa3 = new();
            caixa3.etiqueta = "Turma Da Mônica";
            caixa3.cor = "Verde";

            Adicionar(caixa3);
        }

        private void DefinirId(Caixas cadastroCaixa)
        {
            cadastroCaixa.id = id;
        }
    }
}
