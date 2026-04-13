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
        } while (string.IsNullOrWhiteSpace(nome) || nome.Length < 3);

        decimal preco;
        bool precoValido;
        do
        {
            Console.Write("Digite o preço do equipamento: ");
            precoValido = decimal.TryParse(Console.ReadLine(), out preco);
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
        equipamento.id = id;
        equipamento.nome = nome;
        equipamento.preco = preco;
        equipamento.fabricante = fabricante;
        equipamento.dataFabricacao = dataFabricacao;

        bool cadastrou = false;
        for (int i = 0; i < equipamentos.Length; i++)
        {
            if (equipamentos[i] == null)
            {
                equipamentos[i] = equipamento;
                cadastrou = true;
                break;
            }
        }

        if (!cadastrou)
        {
            Console.WriteLine("Erro: Sem espaço para armazenar novos equipamentos!");
        }
        else
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O registro \"{equipamento.id}\" foi cadastrado com sucesso.");
            Console.WriteLine("---------------------------------");
            Console.Write($"Aperte ENTER para continuar...");
            Console.ReadLine();
        }
    }

    else if (opcaoMenu == "2")
    {
        /*
        Como funcionário, Junior quer ter a possibilidade de editar um equipamento, sendo que ele possa editar todos os campos.

        Deve ter os mesmos critérios que o Requisito 1.1.
        */

        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Edição de equipamento");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
           "{0, -7} | {1, -15} | {2, -22} | {3, -15} | {4, -10}",
           "Id", "Nome", "Preço ", "Fabricante", "Data de Fabricação"
       );

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -22:c2} | {3, -15} | {4, -10:dd/mm/yyyy}",
            e.id, e.nome, e.preco, e.fabricante, e.dataFabricacao);
        }

        Console.WriteLine("---------------------------------");

        string? idSelecionado;
        do
        {
            Console.Write("Digite o id do equipamento que deseja editar: ");
            idSelecionado = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(idSelecionado));

        Console.WriteLine("---------------------------------");

        string? nome;
        do
        {
            Console.Write("Digite o novo nome do equipamento: ");
            nome = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(nome) || nome.Length < 3);

        decimal preco;
        bool precoValido;
        do
        {
            Console.Write("Digite o novo preço do equipamento: ");
            precoValido = decimal.TryParse(Console.ReadLine(), out preco);
        } while (!precoValido);

        string? fabricante;
        do
        {
            Console.Write("Digite o novo nome do fabricante do equipamento: ");
            fabricante = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(fabricante));

        DateTime dataFabricacao;
        bool dataValida;
        do
        {
            Console.Write("Digite a nova data da fabricação do equipamento (dd/mm/yyyy): ");
            dataValida = DateTime.TryParse(Console.ReadLine(), out dataFabricacao);
        } while (!dataValida);

        Equipamento? equipamentoDeletado = null;

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
                continue;

            if (e.id == idSelecionado)
            {
                equipamentoDeletado = e;
                break;
            }
        }

        if (equipamentoDeletado == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Não foi possível encontrar o equipamento informado.");
            Console.WriteLine("---------------------------------");
            Console.Write("Aperte ENTER para continuar...");
            continue;
        }
        else
        {
            equipamentoDeletado.nome = nome;
            equipamentoDeletado.preco = preco;
            equipamentoDeletado.fabricante = fabricante;
            equipamentoDeletado.dataFabricacao = dataFabricacao;

            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O registro \"{idSelecionado}\" foi editado com sucesso.");
            Console.WriteLine("---------------------------------");
            Console.Write($"Aperte ENTER para continuar...");
            Console.ReadLine();
        }
    }
    else if (opcaoMenu == "3")
    {
        /*
        Como funcionário, Junior quer ter a possibilidade de excluir um equipamento que esteja registrado.

        A lista de equipamentos deve ser atualizada
        */

        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Exclusão de equipamento");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
           "{0, -7} | {1, -15} | {2, -22} | {3, -15} | {4, -10}",
           "Id", "Nome", "Preço ", "Fabricante", "Data de Fabricação"
       );

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -22:c2} | {3, -15} | {4, -10:dd/mm/yyyy}",
            e.id, e.nome, e.preco, e.fabricante, e.dataFabricacao);
        }

        Console.WriteLine("---------------------------------");

        string? idSelecionado;
        do
        {
            Console.Write("Digite o id do equipamento que deseja excluir: ");
            idSelecionado = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(idSelecionado));

        Console.WriteLine("---------------------------------");

        bool equipamentoDeletado = false;

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
                continue;

            if (e.id == idSelecionado)
            {
                equipamentos[i] = null;
                equipamentoDeletado = true;
                break;
            }
        }

        if (!equipamentoDeletado)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Não foi possível encontrar o equipamento informado.");
            Console.WriteLine("---------------------------------");
            Console.Write("Aperte ENTER para continuar...");
            continue;
        }
        else
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"O registro \"{idSelecionado}\" foi excluido com sucesso.");
            Console.WriteLine("---------------------------------");
            Console.Write($"Aperte ENTER para continuar...");
            Console.ReadLine();
        }

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

        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Visualização de equipamentos");
        Console.WriteLine("---------------------------------");

        Console.WriteLine(
           "{0, -7} | {1, -15} | {2, -22} | {3, -15} | {4, -10}",
           "Id", "Nome", "Preço ", "Fabricante", "Data de Fabricação"
       );

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento? e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -15} | {2, -22:c2} | {3, -15} | {4, -10:dd/mm/yyyy}",
            e.id, e.nome, e.preco, e.fabricante, e.dataFabricacao);
        }
        
        Console.WriteLine("---------------------------------");      
        Console.WriteLine("Aperte ENTER para continuar...");
        Console.WriteLine("---------------------------------");
        Console.ReadLine();
    }
}