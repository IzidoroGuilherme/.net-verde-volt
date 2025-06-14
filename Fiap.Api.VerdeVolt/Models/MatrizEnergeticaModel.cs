namespace Fiap.Api.VerdeVolt.Models
{
    public class MatrizEnergeticaModel
    {
        public long MatrizId { get; set; }
        public string Pais { get; set; }
        public double PorcentagemFonteRenovavel { get; set; }
        public int Hidroeletrica { get; set; }
        public int GasNatural { get; set; }
        public int Biomassa { get; set; }
        public int Petroleo { get; set; }
        public int Eolica { get; set; }
        public int Solar { get; set; }
        public int Nuclear { get; set; }
    }
}
