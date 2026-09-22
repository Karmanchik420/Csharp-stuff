namespace Lab2
{
    internal class AverageGrade
    {
        public double StreamAverage(int[][] groupGrades)
        {
            int sum = 0;
            int index = 0;
            for (int i = 0; i < groupGrades.Length; i++)
            {
                for (int j = 0; j < groupGrades[i].Length; j++)
                {
                    sum += groupGrades[i][j];
                    index++;
                }
            }
            return Math.Round(((double)sum / index), 2);
        }
        public double GroupAverage(int[] groupGrades)
        {
            int sum = 0;
            int index = 0;
            for (int j = 0; j < groupGrades.Length; j++)
            {
                sum += groupGrades[j];
                index++;
            }
            return Math.Round(((double)sum / index), 2);
        }
    }
}
