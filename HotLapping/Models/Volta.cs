using System.ComponentModel.DataAnnotations;

namespace Circuitos.Models
{
    public class Volta
    {
        public int VoltaID { get; set; }

        [Required]
        public int CarroID { get; set; }
        public Carro? Carro { get; set; }

        [Required]
        public int CircuitoID { get; set; }
        public Circuito? Circuito { get; set; }

        [Required]
        [Display(Name = "Tempo da volta (segundos)")]
        public double Tempo { get; set; }

        public DateTime DataHora { get; set; } = DateTime.Now;
    }
}
