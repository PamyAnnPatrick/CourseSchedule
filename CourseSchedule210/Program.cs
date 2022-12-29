using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule210
{
    class Program
    {
        static void Main(string[] args)
        {
            var numCourses = 5;
            var prerequisites = new int[][]
            {
                new int[] { 3, 2 },
                new int[] { 3, 0 },
                //new int[] { 2, 0 },
                new int[] { 3,0 },
                new int[] { 1,0 },
                new int[] { 1,4 },
                new int[] { 0,2 }
            };

            // Perform the topological sort
            var result = Solution.FindOrder(numCourses, prerequisites);
            // Print the result
            Console.WriteLine(string.Join(", ", result));
            Console.ReadLine();
        }
    }
}
