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
        public void Editar(Amigos idCadastroAmigoSelecionado, Amigos infoAmigoAtualizado)
        {
            idCadastroAmigoSelecionado.nome = infoAmigoAtualizado.nome;
            idCadastroAmigoSelecionado.nomeResponsavel = infoAmigoAtualizado.nomeResponsavel;
            idCadastroAmigoSelecionado.telefone = infoAmigoAtualizado.telefone;
            idCadastroAmigoSelecionado.endereco = infoAmigoAtualizado.endereco;
        }

        public override void ItemRemovido(Entidade idCadastroAmigoSelecionado)
        {
            Amigos amigo = (Amigos)idCadastroAmigoSelecionado;

            amigo.nome += "<Removed>";
        }
             
        public void PreCadastrarAmigos()
        {
            Amigos amigos1 = new();
            amigos1.nome = "José Pereira";
            amigos1.nomeResponsavel = "Maria Pereira";
            amigos1.telefone = 88546236;
            amigos1.endereco = "Rua Peixoto";

            Adicionar(amigos1);

            Amigos amigos2 = new();
            amigos2.nome = "Carlinhos Costa";
            amigos2.nomeResponsavel = "Luíza Costa";
            amigos2.telefone = 98654133;
            amigos2.endereco = "Rua Jaqueline";

            Adicionar(amigos2);

            Amigos amigos3 = new();
            amigos3.nome = "Raimundo Da Silva";
            amigos3.nomeResponsavel = "Paulo Da Silva";
            amigos3.telefone = 99564874;
            amigos3.endereco = "Rua Jaqueline";

            Adicionar(amigos3);
        }
    }
}
