using System.ComponentModel.DataAnnotations;

namespace GestaoMaquiesse.API.ViewModels
{
    public class ViewModelCriarUsuario
    {
      [Required(ErrorMessage = "O nome não pode ser vazio")]
      [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 Caracteres")]
      [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 Caracteres")]
      public string Nome { get; set; }

      [Required(ErrorMessage = "O Email não Pode ser Vazio")]
      [MinLength(10, ErrorMessage = "O email deve ter no mínimo 10 caracteres")]
      [MaxLength(180, ErrorMessage = "O email deve ter no máximo 180 caracteres")]
      public string Email { get; set; }

      [Required(ErrorMessage = "A senha não pode ser vazio")]
      [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 Caracteres")]
      [MaxLength(30, ErrorMessage = "A senha deve ter no máximo 30 Caracteres")]
      public string PalavraPasse { get; set; }
    }
}