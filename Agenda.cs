using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projeto_Whats_Corrigido
{
    public class Agenda
    {
        List<Contato> contatos = new List<Contato>();
         private const string PATH = "Database/agenda.csv";
         // Criei um método construtor para a classe Agenda
         public Agenda(){

             string pasta = PATH.Split('/')[0];

              if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
         }
         
        /// <summary>
        /// Cadastramos os contatos
        /// </summary>
        /// <param name="cont"></param>
        public void Cadastrar(Contato cont)
        {
           
          var linha = new string[] {PrepararLinha(cont)};
          File.AppendAllLines(PATH, linha);

        }

        /// <summary>
        /// Excluimos os contatos
        /// </summary>
        /// <param name="_contato"></param>
        public void Excluir(string _contato)
        {
            List<string> linhas = new List<string>();

            using(StreamReader info = new StreamReader(PATH)){

                string linha;
                while((linha = info.ReadLine())!=null){
                    linhas.Add(linha);
                }
            }

            linhas.RemoveAll(l => l.Contains(_contato));

            Reescrever(linhas);
        }
        
        /// <summary>
        /// Reescrever as linhas de informações
        /// </summary>
        /// <param name="lin"></param>
        public void Reescrever(List<string> lin){
            using(StreamWriter texto = new StreamWriter(PATH))

            foreach(string _nome in lin){
                texto.Write(_nome + "\n");
            }
            
        }
        /// <summary>
        /// Lista os contatos
        /// </summary>
        /// <returns></returns>
        public List<Contato> Listar()
        {
             List<Contato> contatos = new List<Contato>();

             string[] linhas = File.ReadAllLines(PATH);

             foreach(var linha in linhas){
                 string[] infos = linha.Split("-");

            Contato cont = new Contato();
            cont.Nome = (SepararDados(infos[0]));
            cont.Numero = Int32.Parse(SepararDados(infos[1]));
            cont.Status = SepararDados(infos[2]);

            contatos.Add(cont);
            }

            contatos = contatos.OrderBy(x => x.Nome).ToList();


             return contatos;
        }

        public string SepararDados(string _texto){
            return _texto.Split("=")[0];
        }
        /// <summary>
        /// Fornece as informações
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>

        public string PrepararLinha(Contato c){
            return $"{c.Nome} - {c.Numero} - {c.Status}";
        }
    }
}