using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly decimal precoInicial = 0;
        private readonly decimal precoPorHora = 0;
        private readonly List<string> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine().ToUpper();
            string pattern = @"^[A-Z]{3}-\d{4}$";
            if (Regex.IsMatch(placa, pattern) && !veiculos.Contains(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine("Placa adicionada com sucesso");
            }
            else
            {
                Console.WriteLine("Placa não é válida ou já existe no sistema!");
            }
        }

        public void RemoverVeiculo()
        {
            if (!veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            }
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Contains(placa))
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                try
                {

                    int horas = int.Parse(Console.ReadLine());
                    decimal valorTotal = (horas * precoPorHora) + precoInicial;

                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }catch(FormatException)
                {
                    Console.WriteLine("Hora informada incorreta!");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são");
                Console.WriteLine("|--------|");
                veiculos.ForEach(veiculo => Console.WriteLine($"|{veiculo}|"));
                Console.WriteLine("|--------|");
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
