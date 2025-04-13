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

        [Required]
        public string Recorde { get; set; }

        [Required]
        public string RecordePiloto { get; set; }

        [Required]
        public string RecordeCarro { get; set; }

        [Required]
        public string Imagem { get; set; }

        public ICollection<Volta> Voltas { get; set; } = new List<Volta>();

        public Circuito()
        {
            CircuitoID = 0;
            Nome = "Interlagois";
            Pais = "Brasil";
            Cidade = "São Paulo";
            Tamanho = "4,309";
            NumeroCurvas = "15";
            Recorde = "Teste";
            RecordePiloto = "Teste";
            RecordeCarro = "Teste";
            Imagem = "string.Empty";
            Voltas = new List<Volta>();
        }
    }
}