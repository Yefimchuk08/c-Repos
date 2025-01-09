class Program
{

    //TASK 1
    //interface ICalc
    //{
    //    int Less(int valueToCompare);

    //    int Greater(int valueToCompare);
    //}

    //class CheckInterface : ICalc
    //{

    //    private int[] ints;

    //    public CheckInterface()
    //    {

    //    }
    //    public CheckInterface(int size)
    //    {
    //        ints = new int[size];
    //        Random random = new Random();
    //        for (int i = 0; i < ints.Length; i++)
    //        {
    //            ints[i] = random.Next() % 100;
    //        }
    //    }
    //    public void Show()
    //    {
    //        for (int i = 0; i < ints.Length; i++)
    //        {
    //            Console.WriteLine($"{i + 1}: {ints[i]}");
    //        }
    //    }
    //    public int Greater(int valueToCompare)
    //    {
    //        int countWhichMensh = 0;
    //        for (int i = 0; i < ints.Length; i++)
    //        {
    //            if (ints[i] < valueToCompare)
    //            {
    //                countWhichMensh++;
    //            }
    //        }
    //        return countWhichMensh;
    //    }

    //    public int Less(int valueToCompare)
    //    {
    //        int countWhichBilsh = 0;
    //        for (int i = 0; i < ints.Length; i++)
    //        {
    //            if (ints[i] > valueToCompare)
    //            {
    //                countWhichBilsh++;
    //            }
    //        }
    //        return countWhichBilsh;
    //    }
    //}

    //TASK 2

    //interface IOutput2
    //{
    //    void ShowEvem();
    //    void ShowOdd();
    //}

    //class CheckInterface : IOutput2
    //{
    //    private int[] ints;

    //    public CheckInterface()
    //    {

    //    }
    //    public CheckInterface(int size)
    //    {
    //        ints = new int[size];
    //        Random rnd = new Random();
    //        for (int i = 0; i < ints.Length; i++)
    //        {
    //            ints[i] = rnd.Next() % 100;
    //        }
    //    }
    //    public void Show()
    //    {
    //        for (int i = 0; i < ints.Length; i++)
    //        {
    //            Console.WriteLine($"{i + 1}: {ints[i]}");
    //        }

    //    }
    //    public void ShowEvem()
    //    {
    //        int num = 0;
    //        for (int i = 0; i < ints.Length; i++)
    //        {
    //            if (ints[i] % 2 == 0)
    //            {
    //                Console.WriteLine($"{num + 1}: {ints[i]}");
    //            }
    //            else
    //            {
    //                continue;
    //            }
    //        }
    //    }

    //    public void ShowOdd()
    //    {
    //        int num = 0;
    //        for (int i = 0; i < ints.Length; i++)
    //        {
    //            if (ints[i] % 2 != 0)
    //            {
    //                Console.WriteLine($"{num + 1}: {ints[i]}");
    //            }
    //            else
    //            {
    //                continue;
    //            }
    //        }
    //    }
    //}


    //TASk 3
    //interface ICalc2
    //{
    //    int CountDistinct();
    //    int EquelToValue(int valueToCompare);
    //}

    //class CheckInterface : ICalc2
    //{

    //    private int[] ints;

    //    public CheckInterface()
    //    {

    //    }
    //    public CheckInterface(int size)
    //    {
    //        ints = new int[size];
    //        Random rnd = new Random();
    //        for (int i = 0; i < ints.Length; i++)
    //        {
    //            ints[i] = rnd.Next() % 100;
    //        }
    //    }

    //    public void SHow()
    //    {
    //        for (int i = 0; i < ints.Length; i++)
    //        {
    //            Console.WriteLine($"{i + 1}: {ints[i]}");
    //        }
    //    }
    //    public int CountDistinct()
    //    {
    //        int num = 0;
    //        for (int i = 0; i < ints.Length; i++)
    //        {
    //            for (int j = 0; i < ints.Length; j++)
    //            {
    //                if (ints[i] != ints[j])
    //                {
    //                    num++;
    //                }
    //                else
    //                {
    //                    continue;
    //                }
    //            }
    //        }
    //        return num;
    //    }

    //    public int EquelToValue(int valueToCompare)
    //    {
    //        int num = 0;
    //        for (int i = 0; i < ints.Length; i++)
    //        {
    //            if (ints[i] == valueToCompare)
    //            {
    //                num++;
    //            }

    //        }
    //        return num;
    //    }

    static void Main()
        {
            //TASK 1

            //CheckInterface checkInterface = new CheckInterface(7);
            //checkInterface.Show();
            //Console.WriteLine();
            //Console.WriteLine($"Less: {checkInterface.Less(3)}");
            //Console.WriteLine();
            //Console.WriteLine($"Greater: {checkInterface.Greater(3)}"); 
            
            //TASK 2

            //CheckInterface checkInterface = new CheckInterface(9);
            //checkInterface.Show();
            //Console.WriteLine();
            //checkInterface.ShowEvem();
            //Console.WriteLine();
            //checkInterface.ShowOdd();


            //TASk 3
            //    CheckInterface checkInterface = new CheckInterface(5);
            //    Console.WriteLine($"Equel To Value: {checkInterface.EquelToValue(56)}");
            //    Console.WriteLine($"Count Distinct: {checkInterface.CountDistinct()}");
        }
    }
