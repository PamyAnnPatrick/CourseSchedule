using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSchedule210
{
    public static class Solution
    {
        //public static int[] FindOrder1(int numCourses, int[][] prerequisites)
        //{
        //    LinkedList<int> courses = new LinkedList<int>();

        //    for (int i = 0; i < numCourses; i++)
        //        courses.AddLast(i);

        //    foreach (var p in prerequisites)
        //    {

        //        courses.Remove(p[1]);
        //        if (!courses.Contains(p[0]))
        //            courses.AddLast(p[0]);

        //        LinkedListNode<int> current = courses.FindLast(p[0]);
        //        courses.AddBefore(current, p[1]);

        //    }
        //    return courses.ToArray();
        //}

        public static int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            List<int> result = new List<int>();
            var flags = new int[numCourses]; 
            //flag=0  is not visited, flag=1 is visited, flag=2 added to result.

            List<int>[] graph = new List<int>[numCourses];

            //Setting default value
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
                flags[i] = 0;
            }
            foreach (var v in prerequisites)
            {
                graph[v[0]].Add(v[1]);
            }

            //Looping through all noded
            for (int i = 0; i < numCourses; i++)
            {
                //if node not visited
                if (flags[i] == 0)
                {
                    if (!dfs(graph, i, result, flags))
                        return new int[0];
                }
            }
            return result.ToArray();
        }

        private static bool dfs(List<int>[] graph, int course, List<int> result, int[] flags)
        {
            //set node as visited
            flags[course] = 1;

            foreach (int v in graph[course])
            {
                //if node not visited
                if (flags[v] == 0)
                {

                    if (!dfs(graph, v, result, flags))
                        return false;
                }
                else if (flags[v] == 1) ////if node is visited, but not added to result.
                {
                    return false;
                }
            }
            //set node as added to result.
            flags[course] = 2;
            result.Add(course);

            return true;
        }
    }
}
