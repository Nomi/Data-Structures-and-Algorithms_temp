using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T01_ArraysAndHashing.P04_GroupAnagrams_LC49;

public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        // return attempt1(strs); //READ COMMENTS FROM THIS!!
        return attempt2(strs);
    }

    // FOR LOWER COMPLEXITY, WE AVOID SORT AND STORE COUNT OF EACH LETTER (joined by ',') AS THE KEY!
    public List<List<string>> attempt1(string[] strs)
    {
        Dictionary<string, List<string>> map = new(); //we try to store sorted string as the key and the list stores that specific anagram instance
        foreach(var str in strs)
        {
            //------------ NO SORT VERSION -------
            int[] count = new int[26]; //because there are 26 letters in the English alphabet! (and we only need the lowercase versions according to the requirement)
            foreach(char c in str)
            {
                count[c-'a']++;
            }
            var key = string.Join(',',count);
            map.TryAdd(key,new());
            map[key].Add(str);

            //------- SORT VERSION: --------
            // var srtdStr = String.Concat(str.OrderBy(c => c)); //nlog(n) where n is AVERAGE length of the strings.
            // map.TryAdd(srtdStr, new List<string>());
            // map[srtdStr].Add(str);
        }
        return map.Values.ToList();
    }

    public List<List<string>> attempt2(string[] strs)
    {
        Dictionary<string,List<string>> map = new();
        foreach(var str in strs)
        {
            int[] charCount = new int[26];//cuz 26 lowerchase alphabet chars
            for(int i=0;i<str.Count();i++)
                charCount[str[i]-'a']++; //by default all values initialized to 0.
            string key = string.Join(',', charCount);
            map.TryAdd(key,new List<string>());
            map[key].Add(str);
        }
        return map.Values.ToList();
    }
}
