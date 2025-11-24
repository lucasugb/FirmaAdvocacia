namespace FirmaAdvocacia.Models
{
    public class AdvogadoProcesso
    {
        public int AdvogadoId { get; set; }
        public Advogado AdvogadoOrigem { get; set; }
        public int ProcessoId { get; set; }
        public Processo ProcessoOrigem { get; set; }
    }
}
