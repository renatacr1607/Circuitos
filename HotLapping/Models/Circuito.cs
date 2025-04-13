using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace Circuitos.Models
{
    public class Circuito
    {
        public int CircuitoID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Pais { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Tamanho { get; set; }

        [Required]
        public string NumeroCurvas { get; set; }


        public ICollection<Volta> Voltas { get; set; } = new List<Volta>();

        
    }
}