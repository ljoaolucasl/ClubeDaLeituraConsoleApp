using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho01_ClubeDaLeitura.ConsoleApp.Compartilhado;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace Trabalho01_ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixas : Repositorio
    {
        public void Editar(Caixas idCadastroCaixaSelecionado, Caixas infoCaixaAtualizado)
        {
            idCadastroCaixaSelecionado.etiqueta = infoCaixaAtualizado.etiqueta;
            idCadastroCaixaSelecionado.cor = infoCaixaAtualizado.cor;
        }

        public override void ItemRemovido(Entidade idCadastroCaixaSelecionado)
        {
            Caixas caixa = (Caixas)idCadastroCaixaSelecionado;

            caixa.etiqueta += "<Removed>";
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
    }
}
