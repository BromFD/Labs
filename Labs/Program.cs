// See https://aka.ms/new-console-template for more information

namespace Labs;

class Launcher
{
	private static void Main()
	{
		int part;
		int task;
		string continueOption;
		bool exit = false;
		TaskManager tm = new TaskManager();
		Console.WriteLine("===================================================================\n" +
		                  "|                  Лабораторная работа номер 1                    |\n" +
		                  "===================================================================\n" +
		                  "| Введите номер задания и номер задачи.                           |\n" +
		                  "===================================================================");
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



