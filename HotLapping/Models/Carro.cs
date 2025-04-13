using System.ComponentModel.DataAnnotations;

namespace Circuitos.Models
{
    public class Carro
    {
        public int CarroID { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }
    
        public int Potencia { get; set; }
        public double Peso { get; set; }

        public double RelacaoPesoPotencia => Peso / Potencia;

        public string Tracao { get; set; }
        public int AnoFabricacao { get; set; }

        // Relacionamento
        public ICollection<Volta> Voltas { get; set; } = new List<Volta>();
    }
}