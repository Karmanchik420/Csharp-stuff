namespace Lab2
{
    internal class MinGrade
    {
        public int GroupMin(int[] groupGrades)
        {
            int min = groupGrades[0];
            for (int j = 0; j < groupGrades.Length; j++)
            {
                if (groupGrades[j] < min)
                    min = groupGrades[j];
            }
            return min;
        }
        public int StreamMin(int[][] groupGrades)
        {
            int min = GroupMin(groupGrades[0]);
            for (int j = 1; j < groupGrades.Length; j++)
            {
                if (GroupMin(groupGrades[j]) < min)
                    min = GroupMin(groupGrades[j]);
            }
            return min;
        }

    }
}
