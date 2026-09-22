namespace Lab2
{
    internal class MaxGrade
    {
        public int GroupMax(int[] groupGrades)
        {
            int max = groupGrades[0];
            for (int j = 0; j < groupGrades.Length; j++)
            {
                if (groupGrades[j] > max)
                    max = groupGrades[j];
            }
            return max;
        }
        public int StreamMax(int[][] groupGrades)
        {
            int min = GroupMax(groupGrades[0]);
            for (int j = 1; j < groupGrades.Length; j++)
            {
                if (GroupMax(groupGrades[j]) < min)
                    min = GroupMax(groupGrades[j]);
            }
            return min;
        }
    }
}
