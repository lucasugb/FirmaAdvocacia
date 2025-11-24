namespace FirmaAdvocacia.Models
{
    public class ClienteProcesso
    {
        public int ClienteId { get; set; }
        public Cliente ClienteOrigem { get; set; }
        public int ProcessoId { get; set; }
        public Processo ProcessoOrigem { get; set; }
    }
}
