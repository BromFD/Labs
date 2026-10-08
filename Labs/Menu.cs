namespace Labs;

public class Menu
{
    private string _greeting;
    private TaskManager _taskManager;

    public Menu(string greeting, TaskManager taskManager)
    {
        _greeting = greeting;
        _taskManager = taskManager;
    }

    public void Run()
    {
        int part;
        int task;
        string continueOption;
        bool exit = false;
        TaskManager tm = _taskManager;
        Console.WriteLine(_greeting);
        do
        {
            Console.Write("Введите номер задания: ");
            bool check1 = int.TryParse(Console.ReadLine()!, out part);
            Console.Write("Введите номер задачи: ");
            bool check2 = int.TryParse(Console.ReadLine()!, out task);
            if (!check1 || !check2)
            {
                Console.WriteLine("Введено не число");
                Console.Write("Продолжить? (y/n default: y): ");
                continueOption = Console.ReadLine()!;
                if (continueOption == "n")
                {
                    break;
                }
                Console.Clear();
                continue;
            }
            Console.Clear();
            tm.Call(part, task);
            Console.Write("Продолжить? (y/n default: y): ");
            continueOption = Console.ReadLine()!;
            if (continueOption == "n")
            {
                exit = true;
            }
            Console.Clear();
        } while (!exit);
    }
}