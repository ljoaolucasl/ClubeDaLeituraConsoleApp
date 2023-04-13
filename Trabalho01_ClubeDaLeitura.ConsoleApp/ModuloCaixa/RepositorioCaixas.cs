using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixas
    {
        private static ArrayList listaCaixa = new();

        private static int id = 1;

        public static ArrayList GetListaCaixas()
        {
            return listaCaixa;
        }

        public static void Adicionar(Caixas infoCaixa)
        {
            Caixas cadastroCaixa = new();

            IncrementarEDefinirID(cadastroCaixa);
            cadastroCaixa.etiqueta = infoCaixa.etiqueta;
            cadastroCaixa.cor = infoCaixa.cor;

            listaCaixa.Add(cadastroCaixa);
        }

        public static void Editar(Caixas idCadastroCaixaSelecionado, Caixas infoCaixaAtualizado)
        {
            idCadastroCaixaSelecionado.etiqueta = infoCaixaAtualizado.etiqueta;
            idCadastroCaixaSelecionado.cor = infoCaixaAtualizado.cor;
        }

        public static void Excluir(Caixas idCadastroCaixaSelecionado)
        {
            int idEscolhidoIndex = listaCaixa.IndexOf(idCadastroCaixaSelecionado);

            idCadastroCaixaSelecionado.etiqueta += "<Removed>";

            listaCaixa.RemoveAt(idEscolhidoIndex);
        }

        public static Caixas SelecionarId(int idEscolhido)
        {
            while (true)
            {
                foreach (Caixas Caixa in listaCaixa)
                {
                    if (Caixa.id == idEscolhido)
                    {
                        return Caixa;
                    }
                }
                return null;
            }
        }

        #region private

        private static void IncrementarEDefinirID(Caixas cadastroCaixa)
        {
            cadastroCaixa.id = id;
            id++;
        }

        #endregion
    }
}
