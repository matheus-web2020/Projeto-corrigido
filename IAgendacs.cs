using System.Collections.Generic;

namespace Projeto_Whats_Corrigido
{
    public interface IAgendacs
    {
          void Cadastrar(Contato _cont);
         void Excluir(string _contato);
         List<Contato> Listar();
    }
}