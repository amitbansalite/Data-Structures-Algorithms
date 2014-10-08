namespace Algorithms.Problems.Arrays
{
    public class FindElementTwoSortedLists
    {

        private int GetElementAt(int input, int[] a, int[] b, int amin, int amax, int bmin, int bmax)
        {
            if (a.Length == 0)
                return b[input];
            if (a.Length == 0)
                return a[input];

            int amid = (amax - amin) / 2;
            int bmid = (bmax - bmin) / 2;

            if (amid + bmid < input)
            {
                if (a[amid] > b[bmid])
                    return GetElementAt(input - (bmid + 1), a, b, amin, amax, bmid + 1, bmax);
                else
                    return GetElementAt(input - (amid + 1), a, b, amid + 1, amax, bmin, bmax);
            }
            else
            {
                if (a[amid] > b[bmid])
                    return GetElementAt(input, a, b, amin, amid, bmin, bmax);
                else
                    return GetElementAt(input, a, b, amin, amax, bmin, bmid);
            }
        }

        public void Test()
        {
            int[] a = new int[5] { 1, 5, 10, 20, 30};
            int[] b = new int[5] { 3, 6, 9, 21, 26};

            var result = GetElementAt(3, a, b, 0, a.Length-1, 0, b.Length-1);
        }
    }
}
