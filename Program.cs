using System;
using System.IO;

public class Ar
{
    private int n;
    private int[] a;
    private int k;

    public Ar(int n, int x)
    {
        this.n = n;
        a = new int[n];
        Random o = new Random();
        for (int i = 0; i < n; i++)
            a[i] = o.Next(-x, x);
    }
     public Ar(string s)
    {
        StreamReader f = new StreamReader(s);
        string str = "";
        int k = 0;
        while (f.EndOfStream != true)
        {
            str = f.ReadLine(); k++;
        }
        n = k; a = new int[n];
        f.Close();
        StreamReader f1 = new StreamReader(s);
        for (int i = 0; i < k; i++)
        {
            str = f1.ReadLine();
            a[i] = Convert.ToInt32(str);
        }
        f1.Close();
    }


    public int N
    {
        get { return n; }
    }

    public int K
    {
        get
        {
            k = 0;
            for (int i = 0; i < n; i++)
                if (a[i] < 0) k++;
            return k;
        }
    }

    public void Print()
    {
        Console.WriteLine("Масив:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{a[i]} ");
        }
        Console.WriteLine();
    }

    public int FindLastNegativeIndex()
    {
        for (int i = n - 1; i >= 0; i--)
        {
            if (a[i] < 0)
            {
                return i;
            }
        }

        return -1; // Якщо негативних елементів немає
    }

    public int Sum(int i1, int i2)
    {
        int sum = 0;
        for (int i = i1; i <= i2; i++)
        {
            sum += a[i];
        }
        return sum;
    }
  
static void Main(string[] args)
    {
        Console.Write("Оберiть конструктор (1 або 2): ");
        int choice = int.Parse(Console.ReadLine());

        Ar mas; 

        if (choice == 1)
        {
            Console.Write("Введiть кiлькiсть елементiв масиву: ");
            int n = int.Parse(Console.ReadLine());
            mas = new Ar(n,10);
        }
        else if (choice == 2)
        {
            mas = new Ar("1.txt");
        }
        else
        {
            Console.WriteLine("Невiрний вибiр конструктора.");
            return;
        }

        mas.Print();

        int negativeCount = mas.K;
        Console.WriteLine($"Кiлькiсть негативних елементiв: {negativeCount}");

        int lastIndex = mas.FindLastNegativeIndex();
        if (lastIndex != -1)
        {
            Console.WriteLine($"Iндекс останнього негативного елемента: {lastIndex}");
            int sum = mas.Sum(0, lastIndex);
            Console.WriteLine($"Сума елементiв лiворуч вiд останнього негативного: {sum}");
        }
        else
        {
            Console.WriteLine("Негативних елементiв немає.");
        }
    }
}