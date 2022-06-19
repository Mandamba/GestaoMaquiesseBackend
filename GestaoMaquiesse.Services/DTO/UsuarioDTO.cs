namespace GestaoMaquiesse.Services.DTO
{
    public class UsuarioDTO
    {

      public long Id { get; set; }
      public string Nome { get; set; }
      public string Email { get; set; }
      public string PalavraPasse { get; set; }

        public UsuarioDTO(){}
        public UsuarioDTO(long id, string nome, string email, string palavraPasse)
        {
            Id = id;
            Nome = nome;
            Email = email;
            PalavraPasse = palavraPasse;
        }
    }
}