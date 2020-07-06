using System;
using System.Collections.Generic;

namespace Projeto_Whats_Corrigido
{
    class Program
    {
        static void Main(string[] args)
        {
            Contato agenda = new Contato();
           agenda.Nome = "Andrea";
           agenda.Numero = 123456789;
           agenda.Status = "Indisponível";
           

           Agenda agenda1 = new Agenda();

           agenda1.Cadastrar(agenda);

           agenda1.Excluir("Vitor");

           List<Contato> agenda2 = new List<Contato>();
           agenda2 = agenda1.Listar();

           foreach(Contato item in agenda2){
               Console.WriteLine($"{item.Nome} - {item.Numero} - {item.Status}");
           }

           Mensagem mens = new Mensagem();
           mens.destinatario = agenda;
           mens.Texto = "Olá" + mens.destinatario.Nome + "!";
           System.Console.WriteLine(mens.Enviar(mens.destinatario));

           

        }
    }
}
