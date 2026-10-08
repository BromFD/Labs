namespace Labs;

class Lab1Methods : LabMethods
{
	public int SumLastNums(int x)
	{
		return int.Abs((x % 100 / 10) + (x % 10));
	}

	public bool IsPositive(int x)
	{
		return x > 0;
	}

	public bool IsUpperCase(char x)
	{
		if (x >= 'A' && x <= 'Z')
		{
			return true;
		}

		return false;
	}

	public bool IsDivisor(int a, int b)
	{
		if (a % b == 0 || b % a == 0)
		{
			return true;
		}
		return false;
	}

	public int LastNumSum(int a, int b)
	{
		return int.Abs(a % 10) + int.Abs(b % 10);
	}

	public double SafeDiv(int x, int y)
	{
		if (y == 0)
		{
			return 0;
		}
		else
		{
			return (double)x / y;
		}
	}

	public string MakeDecision(int x, int y)
	{
		if (x > y)
		{
			return $"{x} > {y}";
		} 
		else if (x < y)
		{
			return $"{x} < {y}";
		}
		else
		{
			return $"{x} == {y}";
		}
	}
	
	public bool Sum3(int x, int y, int z)
	{
		if ((x == y + z) || (y == x + z) || (z == x + y))
		{
			return true;
		};
		return false;
	}

	public string Age(int x)
	{
		if (x % 10 == 1 && x != 11)
		{
			return $"{x} год";
		} 
		else if (x % 10 >= 2 && x % 10 <= 4 && (x < 12 || x > 14))
		{
			return $"{x} года";
		}
		else
		{
			return $"{x} лет";
		}
	}

	public void PrintDays(string x)
	{
		/*
		string[] days = ["понедельник", "вторник", "среда", "четверг", "пятница", "суббота", "воскресенье"];
		int dayIndex = days.IndexOf(x.ToLower());
		if (dayIndex == -1)
		{
			Console.WriteLine("Это не день недели");
			return;
		}
		for (int i = dayIndex; i < days.Length; i++)
		{
			Console.WriteLine(days[i]);
		}
		*/

		switch (x.ToLower())
		{
			case "понедельник":
				Console.WriteLine("понедельник");
				Console.WriteLine("вторник");
				Console.WriteLine("среда");
				Console.WriteLine("четверг");
				Console.WriteLine("пятница");
				Console.WriteLine("суббота");
				Console.WriteLine("воскресенье");
				break;
			case "вторник":
				Console.WriteLine("вторник");
				Console.WriteLine("среда");
				Console.WriteLine("четверг");
				Console.WriteLine("пятница");
				Console.WriteLine("суббота");
				Console.WriteLine("воскресенье");
				break;
			case "среда":
				Console.WriteLine("среда");
				Console.WriteLine("четверг");
				Console.WriteLine("пятница");
				Console.WriteLine("суббота");
				Console.WriteLine("воскресенье");
				break;
			case "четверг":
				Console.WriteLine("четверг");
				Console.WriteLine("пятница");
				Console.WriteLine("суббота");
				Console.WriteLine("воскресенье");
				break;
			case "пятница":
				Console.WriteLine("пятница");
				Console.WriteLine("суббота");
				Console.WriteLine("воскресенье");
				break;
			case "суббота":
				Console.WriteLine("суббота");
				Console.WriteLine("воскресенье");
				break;
			case "воскресенье":
				Console.WriteLine("воскресенье");
				break;
			default:
				Console.WriteLine("Это не день недели");
				break;
		}
	}

	public string ReverseListNums(int x)
	{
		string result = "";
		for (int i = x; i >= 0; i--)
		{
			result += $"{i} ";
		}
		return result;
	}
	
	public int Pow(int x, int y)
	{
		int result = 1;
		for (int i = y; i > 0; i--)
		{
			result *= x;
		}
		return result;
	}

	public bool EqualNum(int x)
	{
		/*
		string strx = x.ToString();
		for (int i = 1; i < strx.Length; i++)
		{
			if (strx[i - 1] != strx[i])
			{
				return false;
			}
		}
		return true;
		*/

		int? lastDigit = null;
		x = int.Abs(x);
		while (x > 0)
		{
			int currentDigit = x % 10;
			if (lastDigit != null && currentDigit != lastDigit)
			{
				return false;
			}
			lastDigit = currentDigit;
			x /= 10;
		}

		return true;
	}

	public void LeftTriangle(int x)
	{
		string currentAsterisks = "";
		for (int i = 0; i < x; i++)
		{
			currentAsterisks += "*";
			Console.WriteLine(currentAsterisks);
		}
	}

	public void GuessGame()
	{
		bool isGuessed;
		int attempts = 1;
		Random rng = new Random();
		int pseudorandomNumber = rng.Next(0, 10);
		do
		{
			Console.Write("Введите число от 0 до 9: ");
			bool check = int.TryParse(
				Console.ReadLine()!, out int userNumber);
			if (!check)
			{
				Console.WriteLine("Введено не число");
				return;
			}
			isGuessed = pseudorandomNumber == userNumber;

			if (isGuessed)
			{
				Console.WriteLine("Вы угадали!");
				Console.WriteLine($"Вы отгадали число " +
				                  $"за {attempts} попыток!");
			}
			else
			{
				Console.WriteLine($"Вы не угадали");
				attempts += 1;
			}

		} while (!isGuessed);
	}

	public int FindLast(int[] arr, int x)
	{
		for (int i = arr.Length - 1; i >= 0; i--)
		{
			if (arr[i] == x)
			{
				return i;
			}
		}
		return -1;
	}

	public int[]? Add(int[] arr, int x, int pos)
	{
		if (pos > arr.Length || pos < 0)
		{
			return null;
		}
		
		int[] result = new int[arr.Length + 1];
		for (int i = 0; i < result.Length; i++)
		{
			if (i < pos)
			{
				result[i] = arr[i];
			}
			else if (i > pos)
			{
				result[i] = arr[i - 1];
			}
			else
			{
				result[i] = x;
			}
		}

		return result;
	}

	public void Reverse(int[] arr)
	{
		for (int i = 0; i < arr.Length / 2; i++)
		{
			(arr[i], arr[arr.Length - 1 - i]) = 
				(arr[arr.Length - 1 - i], arr[i]);
		}
	}

	public int[] Concat(int[] arr1, int[] arr2)
	{
		int[] result = new int[arr1.Length + arr2.Length];
		for (int i = 0; i < result.Length; i++)
		{
			if (i < arr1.Length)
			{
				result[i] = arr1[i];
			}
			else
			{
				result[i] = arr2[i - arr1.Length];
			}
		}
		return result;
	}

	public int[] DeleteNegative(int[] arr)
	{
		int negatives = 0;
		foreach (var digit in arr)
		{
			if (digit < 0)
			{
				negatives += 1;
			}
		}

		int[] result = new int[arr.Length - negatives];
		int resultIndex = 0;
		for (int i = 0; i < arr.Length; i++)
		{
			if (arr[i] >= 0) 
			{
				result[resultIndex] = arr[i];
			}
			else
			{
				resultIndex -= 1;
			}

			resultIndex += 1;
		}
		return result;
	}
}