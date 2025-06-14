using System.ComponentModel.DataAnnotations;

namespace Fiap.Api.VerdeVolt.ViewModel
{
    public class MatrizEnergeticaCadastroViewModel
    {
        [Required(ErrorMessage = "O campo 'País' é obrigatório.")]
        public string Pais { get; set; }        
        public int Hidroeletrica { get; set; }
        public int GasNatural { get; set; }
        public int Biomassa { get; set; }
        public int Petroleo { get; set; }
        public int Eolica { get; set; }
        public int Solar { get; set; }
        public int Nuclear { get; set; }
    }
}
