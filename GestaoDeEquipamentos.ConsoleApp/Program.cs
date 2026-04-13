using GestaoDeEquipamentos.ConsoleApp.Dominio;
//using GestaoDeEquipamentos.ConsoleApp.Infra;
using GestaoDeEquipamentos.ConsoleApp.Interface;

Equipamento?[] equipamentos = new Equipamento[100];
TelaEquipamento telaEquipamento = new TelaEquipamento();

while (true)
{
    string? opcaoMenu = telaEquipamento.EscolherOpcaoMenu();

    if (opcaoMenu == "S")
    {
        Console.Clear();
        break;
    }

    if (opcaoMenu == "1")
    {
        telaEquipamento.Cadastrar(equipamentos);
    }

    else if (opcaoMenu == "2")
    {
        telaEquipamento.Editar(equipamentos);
    }
    else if (opcaoMenu == "3")
    {
        telaEquipamento.Excluir(equipamentos);
    }

    else if (opcaoMenu == "4")
    {
        telaEquipamento.Visualizar(equipamentos);
    }
}