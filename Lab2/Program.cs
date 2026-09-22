namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] groupGrades = new int[4][];
            groupGrades[0] = new int[20];
            groupGrades[1] = new int[25];
            groupGrades[2] = new int[27];
            groupGrades[3] = new int[30];

            for (int i = 0; i < groupGrades.Length; i++)
            {
                Console.WriteLine($"Группа {i + 1}: ");
                for (int j = 0; j < groupGrades[i].Length; j++)
                {
                    groupGrades[i][j] = new Random().Next(60, 101);
                    Console.Write(groupGrades[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            AverageGrade avgGrade = new AverageGrade();
            Console.WriteLine("Середнiй бал потоку: " + avgGrade.StreamAverage(groupGrades));
            Console.WriteLine();
            for (int i = 0; i < groupGrades.Length; i++)
                Console.WriteLine($"Середнiй бал групи {i+1}: " + avgGrade.GroupAverage(groupGrades[i]));
            Console.WriteLine();

            MinGrade minGrade = new MinGrade();
            Console.WriteLine("Мінімальний бал потоку: " + minGrade.StreamMin(groupGrades));
            Console.WriteLine();
            for (int i = 0; i < groupGrades.Length; i++)
                Console.WriteLine($"Мінімальний бал групи {i + 1}: " + minGrade.GroupMin(groupGrades[i]));
            Console.WriteLine();

            MaxGrade maxGrade = new MaxGrade();
            Console.WriteLine("Максимальний бал потоку: " + maxGrade.StreamMax(groupGrades));
            Console.WriteLine();
            for (int i = 0; i < groupGrades.Length; i++)
                Console.WriteLine($"Максимальний бал групи {i + 1}: " + maxGrade.GroupMax(groupGrades[i]));
        }
    }
}
