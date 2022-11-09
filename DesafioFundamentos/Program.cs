using DesafioFundamentos.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial;
decimal precoPorHora;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!");
precoInicial = GetDecimalInput("Digite o preço inicial: ", "Valor Inválido, Tente novamente!");

precoPorHora = GetDecimalInput("Agora digite o preço por hora: ", "Valor Inválido, Tente novamente!");

Estacionamento es = new (precoInicial, precoPorHora);

bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}


static decimal GetDecimalInput(string message,string errorMessage)
{
    bool success;
    decimal result;
    do
    {
        Console.Write(message);
        success = decimal.TryParse(Console.ReadLine(), out result);
        if (!success)
        {
            Console.WriteLine(errorMessage);
        }
    } while (!success);
    return result;
}
Console.WriteLine("O programa se encerrou");
