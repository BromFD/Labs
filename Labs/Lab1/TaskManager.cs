namespace Labs.Lab1;

class Lab1Manager : TaskManager
{
	private readonly Lab1Methods _lm = new Lab1Methods();

	public string Rts(
		bool condition, 
		string tString, 
		string fString
		) // ResultToString
	{
		if (condition)
		{
			return tString;
		}

		return fString;
	}
	
	public override void Call(int part, int task)
	{
		int taskNumber = (part - 1) * 10 + task;
		switch (taskNumber)
		{
			case 2:
				Task2();
				break;
			case 4:
				Task4();
				break;
			case 6:
				Task6();
				break;
			case 8:
				Task8();
				break;
			case 10:
				Task10();
				break;
			case 12:
				Task12();
				break;
			case 14:
				Task14();
				break;
			case 16:
				Task16();
				break;
			case 18:
				Task18();
				break;
			case 20:
				Task20();
				break;
			case 22:
				Task22();
				break;
			case 24:
				Task24();
				break;
			case 26:
				Task26();
				break;
			case 28:
				Task28();
				break;
			case 30:
				Task30();
				break;
			case 32:
				Task32();
				break;
			case 34:
				Task34();
				break;
			case 36:
				Task36();
				break;
			case 38:
				Task38();
				break;
			case 40:
				Task40();
				break;
			default:
				Console.WriteLine("Такой задачи нет в менеджере!");
				break;
		}
	}

	private void Task2()
	{
		Console.Write("Введите число для задания 2: ");
		bool check = int.TryParse(
			Console.ReadLine()!, out int p1Task2);
		if (!check)
		{
			Console.WriteLine("Введено не число");
			return;
		}
		Console.WriteLine($"Результат сложения последних" +
		                  $" знаков числа {p1Task2}: " +
		                  $"{_lm.SumLastNums(p1Task2)}");
	}
	
	private void Task4()
	{
		int p1Task4;
		Console.Write("Введите число для задания 4: ");
		bool check = int.TryParse(Console.ReadLine()!,  out p1Task4);
		if (!check)
		{
			Console.WriteLine("Введено не число");
			return;
		}
		string p1Status4 = Rts(_lm.IsPositive(p1Task4), 
			"Положительно", "Не положительно");
		Console.WriteLine($"Число {p1Task4} : {p1Status4}");
	}
	
	private void Task6()
	{
		Console.Write("Введите символ для задания 6: ");
		bool check = char.TryParse(
			Console.ReadLine()!, out char p1Task6);
		if (!check)
		{
			Console.WriteLine("Введено больше 1 символа");
			return;
		}
		string p1Status6 = Rts(_lm.IsUpperCase(p1Task6),
			"Большая", "Маленькая или не буква латинского алфавита");
		Console.WriteLine($"Буква {p1Task6} : {p1Status6}");
	}
	
	private void Task8()
	{
		Console.WriteLine("Введите числа для задания 8: ");
		Console.Write("Введите число a: ");
		bool check1 = int.TryParse(
			Console.ReadLine()!, out int p1Task8A);
		Console.Write("Введите число b: ");
		bool check2 = int.TryParse(
			Console.ReadLine()!, out  int p1Task8B);
		if (!check1 || !check2 )
		{
			Console.WriteLine("Введено не число");
			return;
		}
		if (p1Task8A * p1Task8B == 0)
		{
			Console.WriteLine("Метод не поддерживает число 0");
			return;
		}

		string p1Status8 = Rts(_lm.IsDivisor(
			p1Task8A, p1Task8B), "делит", "не делит");
		Console.WriteLine($"Одно из чисел " +
		                  $"{p1Task8A} или {p1Task8B} " +
		                  $"{p1Status8} другое нацело");
	}
	
	private void Task10()
	{
		int sum = 0;
		for (int i = 1; i < 5; i++)
		{
			int p1Task10A;
			int p1Task10B;
			
			Console.WriteLine($"Сумма номер {i}");
			if (i == 1)
			{
				Console.WriteLine("Введите первые 2 числа: ");
				Console.Write("Введите первое число: ");
				bool check1 = int.TryParse(
					Console.ReadLine()!, out p1Task10A);
				Console.Write("Введите второе число: ");
				bool check2 = int.TryParse(
					Console.ReadLine()!,  out p1Task10B);
				if (!check1 || !check2)
				{
					Console.WriteLine("Введено не число");
					return;
				}
			}
			else
			{
				p1Task10A = sum;
				Console.Write("Введите следующее число: ");
				bool check2 = int.TryParse(
					Console.ReadLine()!,  out p1Task10B);
				if (!check2)
				{
					Console.WriteLine("Введено не число");
					return;
				}
			}
			
			sum = _lm.LastNumSum(p1Task10A, p1Task10B);
			Console.WriteLine($"Cумма цифр " +
			                  $"{p1Task10A} и {p1Task10B} " +
			                  $"из разряда единиц: {sum}");
		}
		Console.WriteLine($"Итого: {sum}");
	}
	
	private void Task12()
	{
		Console.WriteLine("Введите числа для задания 2: ");
		Console.Write("Введите число a: ");
		bool check1 = int.TryParse(
			Console.ReadLine()!, out int p2Task2A);
		Console.Write("Введите число b: ");
		bool check2 = int.TryParse(
			Console.ReadLine()!,  out int p2Task2B);
		if (!check1 || !check2)
		{
			Console.WriteLine("Введено не число");
			return;
		}
		Console.WriteLine($"Результат деления {p2Task2A} на " +
		                  $"{p2Task2B}: " +
		                  $"{_lm.SafeDiv(p2Task2A, p2Task2B)}");
	}
	
	private void Task14()
	{
		Console.WriteLine("Введите числа для задания 4: ");
		Console.Write("Введите число a: ");
		bool check1 = int.TryParse(
			Console.ReadLine()!, out int p2Task4A);
		Console.Write("Введите число b: ");
		bool check2 = int.TryParse(
			Console.ReadLine()!,  out int p2Task4B);
		if (!check1 || !check2)
		{
			Console.WriteLine("Введено не число");
			return;
		}
		Console.WriteLine($"Результат для {p2Task4A} и " +
		                  $"{p2Task4B}: {_lm.MakeDecision(
			                  p2Task4A, p2Task4B)}");
	}
	
	private void Task16()
	{
		Console.WriteLine("Введите числа для задания 6: ");
		Console.Write("Введите число a: ");
		bool check1 = int.TryParse(
			Console.ReadLine()!, out int p2Task6A);
		Console.Write("Введите число b: ");
		bool check2 = int.TryParse(
			Console.ReadLine()!,  out int p2Task6B);
		Console.Write("Введите число c: ");
		bool check3 = int.TryParse(
			Console.ReadLine()!,  out int p2Task6C);
		if (!check1 || !check2 || !check3)
		{
			Console.WriteLine("Введено не число");
			return;
		}

		string p2Status6 = Rts(_lm.Sum3(
			p2Task6A, p2Task6B, p2Task6C),
			"можно", "нельзя");
		Console.WriteLine($"Два любых числа из " +
		                  $"{p2Task6A}, {p2Task6B}, " +
		                  $"{p2Task6C} {p2Status6}" +
		                  $" сложить так чтобы получить третье");
	}
	
	private void Task18()
	{
		Console.Write("Введите число для задания 8: ");
		bool check = int.TryParse(
			Console.ReadLine()!, out int p2Task8);
		if (!check)
		{
			Console.WriteLine("Введено не число");
			return;
		}

		if (p2Task8 < 0)
		{
			Console.WriteLine("Возраст не может" +
			                  " быть отрицательным");
			return;
		}
		Console.WriteLine($"Результат для " +
		                  $"{p2Task8}: {_lm.Age(p2Task8)}");
	}
	
	private void Task20()
	{
		Console.Write("Введите день недели для задания 10: ");
		_lm.PrintDays(Console.ReadLine()!);
	}
	
	private void Task22()
	{
		Console.Write("Введите число для задания 2: ");
		bool check = int.TryParse(
			Console.ReadLine()!, out int p3Task2);
		if (!check)
		{
			Console.WriteLine("Введено не число");
			return;
		}
		Console.WriteLine($"Числа от {p3Task2} до 0: " +
		                  $"{_lm.ReverseListNums(p3Task2)}");
	}
	
	private void Task24()
	{
		Console.WriteLine("Введите числа для задания 4: ");
		Console.Write("Введите число a: ");
		bool check1 = int.TryParse(
			Console.ReadLine()!, out int p3Task4A);
		Console.Write("Введите число b: ");
		bool check2 = int.TryParse(
			Console.ReadLine()!,  out int p3Task4B);
		if (!check1 || !check2)
		{
			Console.WriteLine("Введено не число");
			return;
		}
		if (p3Task4B < 0)
		{
			Console.WriteLine("Отрицательные " +
			                  "степени не поддерживаются");
			return;
		}
		Console.WriteLine($"{p3Task4A} в степени " +
		                  $"{p3Task4B}: " +
		                  $"{_lm.Pow(p3Task4A, p3Task4B)}");
	}
	
	private void Task26()
	{
		Console.Write("Введите число для задания 6: ");
		bool check = int.TryParse(
			Console.ReadLine()!, out int p3Task6);
		if (!check)
		{
			Console.WriteLine("Введено не число");
			return;
		}

		string p3Status6 = Rts(_lm.EqualNum(p3Task6),
			"Все", "Не все");
		Console.WriteLine($"{p3Status6} цифры " +
		                  $"числа {p3Task6} одинаковы");
	}
	
	private void Task28()
	{
		Console.Write("Введите число для задания 8: ");
		bool check = int.TryParse(
			Console.ReadLine()!, out int p3Task8);
		if (!check)
		{
			Console.WriteLine("Введено не число");
			return;
		}
		_lm.LeftTriangle(p3Task8);
	}
	
	private void Task30()
	{
		_lm.GuessGame();
	}
	
	private void Task32()
	{
		Console.Write("Введите массив чисел " +
		              "через пробел для задания 2: ");
		int[]? p4Task2Arr = ArrayHelper.Split<int>(
			Console.ReadLine()!, " ");
		if (p4Task2Arr == null)
		{
			Console.WriteLine("Введено не число");
			return;
		}
		Console.Write("Введите число для задания 2: ");
		bool check = int.TryParse(
			Console.ReadLine()!, out int p4Task2);
		if (!check)
		{
			Console.WriteLine("Введено не число");
			return;
		}
		Console.WriteLine($"Индекс последнего вхождения числа " +
		                  $"{p4Task2} в массив:" +
		                  $" {_lm.FindLast(p4Task2Arr, p4Task2)}");
	}
	
	private void Task34()
	{
		Console.Write("Введите массив чисел " +
		              "через пробел для задания 4: ");
		int[]? p4Task4Arr = ArrayHelper.Split<int>(
			Console.ReadLine()!, " ");
		if (p4Task4Arr == null)
		{
			Console.WriteLine("Введено не число");
			return;
		}
		Console.Write("Введите число которое " +
		              "хотите вставить для задания 4: ");
		bool check1 = int.TryParse(
			Console.ReadLine()!, out int p4Task4A);
		Console.Write("Введите позицию вставки для задания 4: ");
		bool check2 = int.TryParse(
			Console.ReadLine()!, out int p4Task4B);
		if (!check1 || !check2)
		{
			Console.WriteLine("Введено не число");
			return;
		}

		int[]? result = _lm.Add(
			p4Task4Arr, 
			p4Task4A, 
			p4Task4B);
		if (result == null)
		{
			Console.WriteLine("Позиция для вставки " +
			                  "отрицательна или превышает длину списка");
			return;
		}
		Console.WriteLine($"Получившийся массив с " +
		                  $"вставленным числом {p4Task4A} " +
		                  $"на позицию {p4Task4B}: " +
		                  $"{ArrayHelper.ArrayToString(result, " ")}");
	}
	
	private void Task36()
	{
		Console.Write("Введите массив чисел" +
		              " через пробел для задания 6: ");
		int[]? p4Task6Arr = ArrayHelper.Split<int>(
			Console.ReadLine()!, " ");
		if (p4Task6Arr == null)
		{
			Console.WriteLine("Введено не число");
			return;
		}
		_lm.Reverse(p4Task6Arr);
		Console.WriteLine($"Получившийся " +
		                  $"перевёрнутый массив: " +
		                  $"{ArrayHelper.ArrayToString(p4Task6Arr, " ")}");
	}
	
	private void Task38()
	{
		Console.Write("Введите первый массив " +
		              "чисел через пробел " +
		              "для задания 8: ");
		int[]? p4Task8ArrA = ArrayHelper.Split<int>(
			Console.ReadLine()!, " ");
		Console.Write("Введите второй массив чисел через пробел для задания 8: ");
		int[]? p4Task8ArrB = ArrayHelper.Split<int>(
			Console.ReadLine()!, " ");
		if (p4Task8ArrA == null || p4Task8ArrB == null)
		{
			Console.WriteLine("Введено не число");
			return;
		}
		Console.WriteLine($"Получившийся объединённый массив: " +
		                  $"{ArrayHelper.ArrayToString(
			                  _lm.Concat(p4Task8ArrA, p4Task8ArrB), " ")}");
	}
	
	private void Task40()
	{
		Console.Write("Введите массив чисел " +
		              "через пробел для задания 10: ");
		int[]? p4Task10Arr = ArrayHelper.Split<int>(
			Console.ReadLine()!, " ");
		if (p4Task10Arr == null)
		{
			Console.WriteLine("Введено не число");
			return;
		}
		Console.WriteLine($"Получившийся массив без " +
		                  $"отрицательных элементов: {
			                  ArrayHelper.ArrayToString(
				                  _lm.DeleteNegative(p4Task10Arr), " ")}");
	}
}