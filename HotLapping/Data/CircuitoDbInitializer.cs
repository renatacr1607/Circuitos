using Circuitos.Models;

namespace Circuitos.Data
{
    public class CircuitoDbInitializer
    {
        public static void Initialize(CircuitosContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated(); 

          
            if (context.Carros.Any() || context.Circuitos.Any() || context.Voltas.Any())
                return;

         
            var circuitos = new Circuito[]
            {
            new Circuito { Nome = "Interlagos", Pais = "Brasil", Cidade = "São Paulo", Tamanho = "4.309 km", NumeroCurvas = "15" },
            new Circuito { Nome = "Silverstone", Pais = "Reino Unido", Cidade = "Silverstone", Tamanho = "5.891 km", NumeroCurvas = "18" },
            new Circuito { Nome = "Monza", Pais = "Itália", Cidade = "Monza", Tamanho = "5.793 km", NumeroCurvas = "11" },
            new Circuito { Nome = "Suzuka", Pais = "Japão", Cidade = "Suzuka", Tamanho = "5.807 km", NumeroCurvas = "18" },
            new Circuito { Nome = "Spa-Francorchamps", Pais = "Bélgica", Cidade = "Stavelot", Tamanho = "7.004 km", NumeroCurvas = "20" },
            new Circuito { Nome = "Nürburgring GP", Pais = "Alemanha", Cidade = "Nürburg", Tamanho = "5.148 km", NumeroCurvas = "16" },
            new Circuito { Nome = "Red Bull Ring", Pais = "Áustria", Cidade = "Spielberg", Tamanho = "4.318 km", NumeroCurvas = "10" },
            new Circuito { Nome = "Circuit de Monaco", Pais = "Mônaco", Cidade = "Monte Carlo", Tamanho = "3.337 km", NumeroCurvas = "19" },
            new Circuito { Nome = "Laguna Seca", Pais = "EUA", Cidade = "Monterey", Tamanho = "3.602 km", NumeroCurvas = "11" },
            new Circuito { Nome = "Mount Panorama", Pais = "Austrália", Cidade = "Bathurst", Tamanho = "6.213 km", NumeroCurvas = "23" }
            };
            context.Circuitos.AddRange(circuitos);
            context.SaveChanges();


            var carros = new Carro[]
            {
            new Carro { Marca = "Ferrari", Modelo = "488 GTB", Potencia = 670, Peso = 1475, Tracao = "Traseira", AnoFabricacao = 2020 },
            new Carro { Marca = "Porsche", Modelo = "911 GT3", Potencia = 500, Peso = 1430, Tracao = "Traseira", AnoFabricacao = 2019 },
            new Carro { Marca = "Lamborghini", Modelo = "Huracán EVO", Potencia = 640, Peso = 1422, Tracao = "Integral", AnoFabricacao = 2021 },
            new Carro { Marca = "McLaren", Modelo = "720S", Potencia = 720, Peso = 1419, Tracao = "Traseira", AnoFabricacao = 2020 },
            new Carro { Marca = "BMW", Modelo = "M4 GTS", Potencia = 500, Peso = 1510, Tracao = "Traseira", AnoFabricacao = 2018 },
            new Carro { Marca = "Mercedes", Modelo = "AMG GT R", Potencia = 585, Peso = 1555, Tracao = "Traseira", AnoFabricacao = 2019 },
            new Carro { Marca = "Audi", Modelo = "R8 V10", Potencia = 610, Peso = 1595, Tracao = "Integral", AnoFabricacao = 2020 },
            new Carro { Marca = "Chevrolet", Modelo = "Corvette C8", Potencia = 495, Peso = 1530, Tracao = "Traseira", AnoFabricacao = 2021 },
            new Carro { Marca = "Nissan", Modelo = "GT-R", Potencia = 570, Peso = 1720, Tracao = "Integral", AnoFabricacao = 2019 },
            new Carro { Marca = "Dodge", Modelo = "Challenger Hellcat", Potencia = 717, Peso = 1950, Tracao = "Traseira", AnoFabricacao = 2020 },
            new Carro { Marca = "Toyota", Modelo = "Supra GR", Potencia = 340, Peso = 1520, Tracao = "Traseira", AnoFabricacao = 2022 },
            new Carro { Marca = "Mazda", Modelo = "RX-7", Potencia = 280, Peso = 1280, Tracao = "Traseira", AnoFabricacao = 2002 },
            new Carro { Marca = "Subaru", Modelo = "WRX STI", Potencia = 310, Peso = 1540, Tracao = "Integral", AnoFabricacao = 2021 },
            new Carro { Marca = "Ford", Modelo = "Mustang GT", Potencia = 460, Peso = 1650, Tracao = "Traseira", AnoFabricacao = 2018 },
            new Carro { Marca = "Honda", Modelo = "NSX", Potencia = 573, Peso = 1725, Tracao = "Integral", AnoFabricacao = 2020 },
            new Carro { Marca = "Aston Martin", Modelo = "Vantage", Potencia = 510, Peso = 1530, Tracao = "Traseira", AnoFabricacao = 2021 },
            new Carro { Marca = "Koenigsegg", Modelo = "Jesko", Potencia = 1600, Peso = 1320, Tracao = "Traseira", AnoFabricacao = 2023 },
            new Carro { Marca = "Pagani", Modelo = "Huayra", Potencia = 730, Peso = 1350, Tracao = "Traseira", AnoFabricacao = 2020 },
            new Carro { Marca = "Bugatti", Modelo = "Chiron", Potencia = 1500, Peso = 1995, Tracao = "Integral", AnoFabricacao = 2021 },
            new Carro { Marca = "Tesla", Modelo = "Model S Plaid", Potencia = 1020, Peso = 2162, Tracao = "Integral", AnoFabricacao = 2022 }
            };
            context.Carros.AddRange(carros);
            context.SaveChanges();


            var voltas = new Volta[]
            {
            new Volta { CarroID = 1, CircuitoID = 1, Tempo = 95.432 },
            new Volta { CarroID = 2, CircuitoID = 1, Tempo = 92.789 },
            new Volta { CarroID = 3, CircuitoID = 2, Tempo = 88.234 },
            new Volta { CarroID = 4, CircuitoID = 3, Tempo = 103.876 },
            new Volta { CarroID = 5, CircuitoID = 2, Tempo = 97.321 },
            new Volta { CarroID = 6, CircuitoID = 4, Tempo = 90.654 },
            new Volta { CarroID = 7, CircuitoID = 4, Tempo = 93.987 },
            new Volta { CarroID = 8, CircuitoID = 5, Tempo = 85.332 },
            new Volta { CarroID = 9, CircuitoID = 6, Tempo = 89.001 },
            new Volta { CarroID = 10, CircuitoID = 7, Tempo = 91.765 },
            new Volta { CarroID = 11, CircuitoID = 5, Tempo = 87.456 },
            new Volta { CarroID = 12, CircuitoID = 6, Tempo = 92.123 },
            new Volta { CarroID = 13, CircuitoID = 7, Tempo = 88.999 },
            new Volta { CarroID = 14, CircuitoID = 8, Tempo = 100.214 },
            new Volta { CarroID = 15, CircuitoID = 9, Tempo = 96.743 },
            new Volta { CarroID = 16, CircuitoID = 10, Tempo = 101.342 },
            new Volta { CarroID = 17, CircuitoID = 8, Tempo = 98.234 },
            new Volta { CarroID = 18, CircuitoID = 9, Tempo = 94.876 },
            new Volta { CarroID = 19, CircuitoID = 10, Tempo = 99.432 },
            new Volta { CarroID = 20, CircuitoID = 1, Tempo = 95.231 },
            new Volta { CarroID = 1, CircuitoID = 2, Tempo = 96.789 },
            new Volta { CarroID = 2, CircuitoID = 3, Tempo = 92.876 },
            new Volta { CarroID = 3, CircuitoID = 4, Tempo = 90.567 },
            new Volta { CarroID = 4, CircuitoID = 5, Tempo = 94.321 },
            new Volta { CarroID = 5, CircuitoID = 6, Tempo = 91.223 },
            new Volta { CarroID = 6, CircuitoID = 7, Tempo = 89.987 },
            new Volta { CarroID = 7, CircuitoID = 8, Tempo = 93.741 },
            new Volta { CarroID = 8, CircuitoID = 9, Tempo = 87.652 },
            new Volta { CarroID = 9, CircuitoID = 10, Tempo = 90.433 },
            new Volta { CarroID = 10, CircuitoID = 1, Tempo = 88.542 },
            new Volta { CarroID = 11, CircuitoID = 2, Tempo = 86.789 },
            new Volta { CarroID = 12, CircuitoID = 3, Tempo = 95.322 },
            new Volta { CarroID = 13, CircuitoID = 4, Tempo = 92.456 },
            new Volta { CarroID = 14, CircuitoID = 5, Tempo = 89.334 },
            new Volta { CarroID = 15, CircuitoID = 6, Tempo = 91.982 },
            new Volta { CarroID = 16, CircuitoID = 7, Tempo = 88.129 },
            new Volta { CarroID = 17, CircuitoID = 8, Tempo = 90.543 },
            new Volta { CarroID = 18, CircuitoID = 9, Tempo = 94.765 },
            new Volta { CarroID = 19, CircuitoID = 10, Tempo = 96.231 },
            new Volta { CarroID = 20, CircuitoID = 1, Tempo = 93.789 },
            new Volta { CarroID = 1, CircuitoID = 3, Tempo = 90.246 },
            new Volta { CarroID = 2, CircuitoID = 5, Tempo = 88.764 },
            new Volta { CarroID = 3, CircuitoID = 7, Tempo = 91.432 },
            new Volta { CarroID = 4, CircuitoID = 9, Tempo = 87.983 },
            new Volta { CarroID = 5, CircuitoID = 2, Tempo = 93.214 },
            new Volta { CarroID = 6, CircuitoID = 4, Tempo = 90.999 },
            new Volta { CarroID = 7, CircuitoID = 6, Tempo = 89.654 },
            new Volta { CarroID = 8, CircuitoID = 8, Tempo = 92.187 },
            new Volta { CarroID = 9, CircuitoID = 10, Tempo = 90.123 },
            new Volta { CarroID = 10, CircuitoID = 1, Tempo = 94.987 }
};

            context.Voltas.AddRange(voltas);
            context.SaveChanges();
        }
    }
}

