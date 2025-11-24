using System.ComponentModel.DataAnnotations;

namespace FirmaAdvocacia.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Nome { get; set; }
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        [Display(Name = "e-mail")]
        public string Email { get; set; }

        public ICollection<ClienteProcesso> ClientesProcessos { get; set; } = new List<ClienteProcesso>();
    }
}
