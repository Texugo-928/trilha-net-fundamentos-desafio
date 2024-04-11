namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            bool validadorPlaca = true;

            while (validadorPlaca)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string placa = Console.ReadLine().ToUpper();

                if (placa.Length == 7)
                {
                    veiculos.add(placa);
                    validadorPlaca = false;
                }
                else
                {
                    Console.WriteLine($"ERRO: A placa deve possuir 7 digitos e foi informado {placa.Length}. Tente Novamente!\n");
                }
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = "";
            placa = Console.ReadLine().ToUpper(); 

            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa))
            {
                int horas = 0;
                decimal valorTotal = 0;
                bool validadorConversao = true;

                while (validadorConversao)
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    string console = Console.ReadLine();
                    
                    bool retorno = int.TryParse(console, out horas);
                    
                    validadorConversao = !retorno;

                    if (validadorConversao)
                    {
                        Console.WriteLine($"ERRO: Não foi possivel converter o valor {console} para inteiro. Tente Novamente! \n");
                    }
                }

                valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.Write($"  {(i + 1)} - {veiculos[i]} \n");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
