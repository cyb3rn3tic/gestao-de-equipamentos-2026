using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp;

Equipamento?[] equipamentos = new Equipamento[100];

while (true)
{
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Cadastrar equipamento");
    Console.WriteLine("2 - Editar equipamento");
    Console.WriteLine("3 - Excluir equipamento");
    Console.WriteLine("4 - Visualizar equipamentos");
    Console.WriteLine("S - Sair");
    Console.WriteLine("---------------------------------");
    Console.Write("> ");

    string? opcaoMenu = Console.ReadLine()?.ToUpper();

    if (opcaoMenu == "S")
    {
        Console.Clear();
        break;
    }

    if (opcaoMenu == "1")
    {
        /*
        Requisito 1.1: Como funcionário, Junior quer ter a possibilidade de registrar equipamentos
            • Deve ter identificador único (id)
            • Deve ter um nome com no mínimo 6 caracteres;
            • Deve ter um preço de aquisição;
            • Deve ter uma fabricante;
            • Deve ter uma data de fabricação;
        */
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Cadastro de equipamento");
        Console.WriteLine("---------------------------------");

        string? nome;
        do
        {
            Console.Write("Digite o nome do equipamento: ");
            nome = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(nome));

        decimal preco;
        bool precoValido;
        do
        {
            Console.Write("Digite o preço do equipamento: ");
            precoValido = !decimal.TryParse(Console.ReadLine(), out preco);
        } while (!precoValido);

        string? fabricante;
        do
        {
            Console.Write("Digite o nome do fabricante do equipamento: ");
            fabricante = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(fabricante));

        DateTime dataFabricacao;
        bool dataValida;
        do
        {
            Console.Write("Digite a data da fabricação do equipamento (dd/mm/yyyy): ");
            dataValida = DateTime.TryParse(Console.ReadLine(), out dataFabricacao);
        } while (!dataValida);

        string id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7);

        Equipamento equipamento = new Equipamento();
        equipamento.id= id;
        equipamento.nome = nome;
        equipamento.preco = preco;
        equipamento.fabricante = fabricante;
        equipamento.dataFabricacao = dataFabricacao;

        
    }

    else if (opcaoMenu == "2")
    {
        /*
        Como funcionário, Junior quer ter a possibilidade de editar um equipamento, sendo que ele possa editar todos os campos.

        Deve ter os mesmos critérios que o Requisito 1.1.
        */



        
    }

    else if (opcaoMenu == "3")
    {
        /*
        Como funcionário, Junior quer ter a possibilidade de excluir um equipamento que esteja registrado.

        A lista de equipamentos deve ser atualizada
        */
    }

    else if (opcaoMenu == "4")
    {
        /*
        Como funcionário, Junior quer ter a possibilidade de visualizar todos os equipamentos registrados em seu inventário.

        Deve mostrar o id;
        Deve mostrar o nome;
        Deve mostrar o preço de aquisição;
        Deve mostrar a fabricante;
        Deve mostrar a data de fabricação;
        */

        //Console.WriteLine(id);
        //Console.WriteLine(nome);
        //Console.WriteLine(preco);
        //Console.WriteLine(fabricante);
        //Console.WriteLine(data);
    }
}