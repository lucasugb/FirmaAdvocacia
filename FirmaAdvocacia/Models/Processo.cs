using System.ComponentModel.DataAnnotations;

namespace FirmaAdvocacia.Models
{
    public class Processo
    {
        public int ProcessoId { get; set; }
        public string Tipo { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Abertura do Processo")]
        public DateTime DataAbertura { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente ClienteOrigem { get; set; }

    }
}
