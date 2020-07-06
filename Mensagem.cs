namespace Projeto_Whats_Corrigido
{
    public class Mensagem
    {
        public string Texto { get; set; }

        public Contato destinatario { get; set; }

        public string Enviar(Contato contato){
             
            return $"Fulano: Olá {destinatario.Nome}, tudo bem?; mensagem enviada para: {destinatario.Nome}";
        }
    }
}