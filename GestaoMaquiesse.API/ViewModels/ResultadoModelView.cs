namespace GestaoMaquiesse.API.ViewModels
{
    public class ResultadoModelView
    {
        public string Mensagem {get; set;}
        public bool Sucesso {get; set;}
        public dynamic Dados {get; set; }
    }
}