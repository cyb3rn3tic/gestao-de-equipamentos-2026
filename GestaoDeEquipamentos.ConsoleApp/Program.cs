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

        string id;
        string nome;
        
    }

    else if (opcaoMenu == "2")
    {

    }

    else if (opcaoMenu == "3")
    {

    }

    else if (opcaoMenu == "4")
    {

    }
}