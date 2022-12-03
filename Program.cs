using System;
using System.Collections.Generic;
using System.Linq;

namespace _205_IsomorphicStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 205");
            Console.WriteLine(IsIsomorphic("egg", "add"));
            Console.WriteLine(IsIsomorphic("foo", "bar"));
            Console.WriteLine(IsIsomorphic("paper", "title"));
            Console.ReadKey();
        }

        // 205. Isomorphic Strings
        // Given two strings s and t, determine if they are isomorphic.
        // Two strings s and t are isomorphic if the characters in s can be replaced to get t.
        // All occurrences of a character must be replaced with another character while preserving the order of characters.
        // No two characters may map to the same character, but a character may map to itself.
        
        //Example 1:
        //Input: s = "egg", t = "add"
        //Output: true

        //Example 2:
        //Input: s = "foo", t = "bar"
        //Output: false

        //Example 3:
        //Input: s = "paper", t = "title"
        //Output: true

        static public bool IsIsomorphic(string s, string t)
        {
            List<char> slist = new List<char>();
            slist.AddRange(s.ToCharArray());
            slist = slist.Distinct().ToList();

            List<char> tlist = new List<char>();
            tlist.AddRange(t.ToCharArray());
            tlist = tlist.Distinct().ToList();

            if (slist.Count != tlist.Count)
                return false;

            List<char> sumlist = new List<char>();
            sumlist.AddRange(slist);
            sumlist.AddRange(tlist);
            sumlist = sumlist.Distinct().ToList();

            int index = 20;
            char[] dic = new char[sumlist.Count];
            for (var i = 0; i < sumlist.Count; i++)
            {
                while (sumlist.Contains((char)index))
                {
                    index++;
                }
                dic[i] = (char)index;
                index++;
            }

            index = 0;
            foreach (var item in slist)
            {
                s = s.Replace(item, dic[index]);
                index++;
            }

            index = 0;
            foreach (var item in tlist)
            {
                t = t.Replace(item, dic[index]);
                index++;
            }

            return s == t;
        }

    }
}
