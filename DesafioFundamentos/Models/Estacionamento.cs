namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Placa> veiculos = new List<Placa>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string entradaPlaca = Console.ReadLine();

            try
            {                
                Placa novaPlaca = new Placa(entradaPlaca);
                veiculos.Add(novaPlaca);
                Console.WriteLine($"O veículo com a placa {novaPlaca} foi adicionado com sucesso!");
            }
            catch (ArgumentException ex)
            {                
                Console.WriteLine($"Erro: {ex.Message}");
                Console.WriteLine("Por favor, digite uma placa válida.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string entradaPlaca = Console.ReadLine();

            try
            {
                Placa placaParaRemover = new Placa(entradaPlaca);

                if (veiculos.Any(p => p.Valor == placaParaRemover.Valor))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    if (int.TryParse(Console.ReadLine(), out int horas))
                    {
                        decimal valorTotal = precoInicial + (precoPorHora * horas); 

                        veiculos.RemoveAll(p => p.Valor == placaParaRemover.Valor);

                        Console.WriteLine($"O veículo {placaParaRemover.Valor} foi removido e o preço total foi de: R$ {valorTotal}");
                    }
                    else
                    {
                        Console.WriteLine("Valor de horas inválido.");
                    }
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("A placa dos veículos estacionados são:");
                foreach (var placa in veiculos)
                {
                    Console.WriteLine(placa.Valor);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}