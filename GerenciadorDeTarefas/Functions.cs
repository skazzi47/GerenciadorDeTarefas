using System.Reflection.PortableExecutable;
using Layout;



namespace Metodo
{
class Listar
{
    public static List<string> tarefas = new List<string>();
    public static List<bool> concluida = new List<bool>();

    public static void Tarefas()
    {
        int opcao = -1;

        while (opcao != 0)
        {
            // Exibe o menu de opções
            Console.WriteLine("\n    1 - Adicionar Tarefa");
            Console.WriteLine("    2 - Listar Tarefas");
            Console.WriteLine("    3 - Concluir Tarefa");
            Console.WriteLine("    4 - Remover Tarefa");
            Console.WriteLine("    0 - Sair");
            Console.WriteLine("\nEscolha uma opção: ");
            
            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    AdicionarTarefa();
                    break;
                case 2:
                    ListarTarefas();
                    break;
                case 3:
                    ConcluirTarefa();
                    break;
                case 4:
                    RemoverTarefa();
                    break;
                case 0:
                    Console.Write("Saindo");
                    Thread.Sleep(600);
                    Console.Write(".");
                    Thread.Sleep(600);
                    Console.Write(".");
                    Thread.Sleep(600);
                    Console.Write(".");
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }

            if (opcao != 0)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    public static void AdicionarTarefa()
    {
        Console.Clear();
        Console.Write("\nDigite o nome da tarefa: ");
        string tarefa = Console.ReadLine();
        tarefas.Add(tarefa);
        concluida.Add(false);
        Formatacao.Cor($"\nTarefa adicionada com sucesso!", ConsoleColor.Green);
    }

    public static void ListarTarefas()
    {
        Console.Clear();
        if (tarefas.Count == 0)
        {
            Console.WriteLine("\nNenhuma tarefa cadastrada.");
            return;
        }
        
        Formatacao.Cor("\nLista de Tarefas:",ConsoleColor.Yellow);
        //Console.WriteLine("\nLista de Tarefas:");
        for (int i = 0; i < tarefas.Count; i++)
        {
            string status = concluida[i] ? "(Concluída)" : "(Pendente)";
            Formatacao.Cor($"\nID[{i + 1}] - {tarefas[i]} {status}",ConsoleColor.Yellow);
        }
    }

    public static void ConcluirTarefa()
    {
        Console.Clear();
        ListarTarefas();

        Console.Write("\nDigite o número da tarefa que deseja concluir: ");
        int indice;

        try
        {
            indice = int.Parse(Console.ReadLine()) - 1;
            if (indice < 0 || indice >= tarefas.Count)
            {
                Console.WriteLine("Índice inválido.");
                return;
            }
            concluida[indice] = true;
            Console.WriteLine("Tarefa concluída com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida.");
        }
    }

    public static void RemoverTarefa()
    {
        Console.Clear();
        ListarTarefas();

        Console.Write("\nDigite o número da tarefa que deseja remover: ");
        int indice;

        try
        {
            indice = int.Parse(Console.ReadLine()) - 1;
            if (indice < 0 || indice >= tarefas.Count)
            {
                Console.WriteLine("Índice inválido.");
                return;
            }
            tarefas.RemoveAt(indice);
            concluida.RemoveAt(indice);
            Console.WriteLine("Tarefa removida com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida.");
        }
    }
}
}