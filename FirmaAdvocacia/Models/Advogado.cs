namespace FirmaAdvocacia.Models
{
    public class Advogado
    {
        public int AdvogadoId { get; set; }
        public string Nome { get; set; }
        public string OAB { get; set; }
        public string Especialidade { get; set; }
        public ICollection<AdvogadoProcesso> AdvogadosProcessos { get; set; } = new List<AdvogadoProcesso>();
    }
}
