using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T05_BinarySearch.P07_MedianOfTwoSortedArrays_LC4;

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        //EXTREMELY IMPORANT: Read comments from attempt1,
        //at least for the edgecases.
        //Watching NC's video only comes AFTER that :3.
        //Though the LC solutions might be better!
        
        //My intuition (bruteforce):
        //the bruteforce solution would be O(m+n) with two pointers, one each on nums1 and nums2 which we can use to traverse these as if they were a single sorted array (by checking which pointer is currently at a smaller value and the using that for that iteration)
        //^^This bruteforce might be enough in an interview when followed up with just an explanation of how you would do it in O(log(m+n)) time instead.
        //^^^ ESPECIALLY GIVEN THE EDGECASE CODE (and the code as a whole)
        
        // IMPORTANT NOTES: (try reading the ones with ^ suffix above first!)
        // Just skim through the NeetCode video for a great explanation for the solution!
        //CHECK THESE FOR STUDYING:
        // Editorial part we need: https://leetcode.com/problems/median-of-two-sorted-arrays/editorial/#approach-3-a-better-binary-search
        // C# solution by someone: https://leetcode.com/problems/median-of-two-sorted-arrays/solutions/5783216/median-of-two-sorted-arrays-binary-search-approach-in-c-beginner-friendly/
        return attempt1(nums1, nums2);

        
    }

    public double attempt1(int[] nums1, int[] nums2) 
    {
        var A = nums1;
        var B = nums2;
        
        if (B.Length < A.Length) {
            int[] temp = A;
            A = B;
            B = temp;
        }

        int totalCount = A.Length + B.Length;
        int sizeOfHalves = totalCount/2; //Integer division => decimal is truncated.
        
        //Time complexity: O(log(min(n,m))) //min because we are running binary search on the smaller of the two.
        //We can binary search through B as we can calculate the remaining elements needed for each side after picking both the left and right subarrays for B.
        int l=0, r=A.Length-1;
        while(true) //We can use While True because There's guaranteed to be a median so we can just return from there when we find it!
        {

            //** EXTREMELY IMPORTANT!  [!! EDGE CASES !!] **
            //We want Floor for when the A (the smaller array) is 
            //of length 1 or 0, because that makes mA = -1 when
            //((l+r)/2 == -1/2) (which happens in those cases).
            //NeetCode's YouTube/Python solution uses "//",
            //which, ONLY for positive numbers, is equivalent to int division for postiive numbers
            //For both negative and positive, it is actually equivalent
            //to Math.Floor().
            int mA = (int)Math.Floor((l+r)/2.0); //int division => truncate

            //IMPORTANT: sizeOfHalves - (mA+1) 
            //is the remaining length (of the left subarray
            // of B), then we -1 to get it as the index.
            int idxB = (sizeOfHalves - (mA+1))-1; 
            

            //[VERY IMPORTANT]: HANDLING EDGE CASES
            var Aleft = mA>=0 ? A[mA] : double.MinValue; //right most element of left window of A
            var Aright = mA+1<A.Length ? A[mA+1] : double.MaxValue; //left most element of right window of A
            var Bleft = idxB>=0 ? B[idxB] : double.MinValue; //right most element of left window of B
            var Bright = idxB+1<B.Length ? B[idxB+1] : double.MaxValue; //left most element of right window of B

            //Partition is correct:
            if(Aleft<=Bright && Bleft <= Aright)
            {
                if(totalCount%2!=0) //odd:  //the one on right will be the one actual median because neither window should contain it for odd length, and it is ensured here by calculating half in int/truncating division.
                    return Math.Min(Aright, Bright); //There will never be a case where both will be MaxValue obviously.
                //even:
                return (Math.Max(Aleft,Bleft) + Math.Min(Aright, Bright))/2.0; //Gotta divide by 2.0 (instead of simply 2) to get decimal division
            }
            else if(Aleft>Bright) //the right most element of left window of A is smaller than the leftmost element of right window of B (keep in mind A and B are sorted)! //Aleft is too big, meaning we have too many elements from B on the left side <=> not enough elements in A on the left side!
                r = mA - 1;
            else //Bleft > Aright <=> Aright < Bleft //Aleft is too small, meaning we have at least 1 element smaller than the the last element of B in our A right window! (keep in mind A and B are sorted)
                l = mA + 1;
        }
        return -1;
    }

}
