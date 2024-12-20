using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSA.NeetCode150.Topics.T07_Trees.Common;

namespace DSA.NeetCode150.Topics.T07_Trees.P14_BinaryTreeMaximumPathSum_LC124;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    public int MaxPathSum(TreeNode root) {
        //YOOOOO!!! DID IT BY MYSELF WITHIN 20 MINTUES (no outside help AT ALL)!!!!

        //!!! MAYBE I shoulde watch a video for this sometime, maybe????
        
        // rec1(root);

        maxSum = int.MinValue; //int.MinValue and NOT 0 because we need to select AT LEAST 1 element in our path, even if it is negative. (or the 1 element, i.e. the max element, even if the whole tree is negative) //If we could select the empty path, we could set it to 0.
        rec1_Simplified(root);
        return maxSum;

        //check neetcodeio soln to see how to do it with ref instead of a member of the class (`maxSum` a.k.a. `res`). //I mean it is simple to do it, especially after having this solution, but I didn't bother writing/changing it.
    }

    int maxSum;
    public int rec1_Simplified(TreeNode root)
    {
        //Clearly we need to do this postorder!
        if(root == null)
            return 0;
        
        int lSum = rec1_Simplified(root.left);
        if(lSum<0) lSum = 0;
        var rSum = rec1_Simplified(root.right);
        if(rSum<0) rSum = 0;

        int maxSumAtCurrNode = lSum+rSum+root.val; //Notice that NONE of these can be negative due to the if conditions above where we set them to 0 in case they're negative (i.e. we ignore the branch(es) that is(are) not helpful).
        //We make sure to add the root.Val because we have already considered each branch without this node already.
        //Also, we would need to include the current one to connect the two branches to form a path.

        // Console.WriteLine($"MS= {maxSum}, CV= {currVal}, MSACN = {maxSumAtCurrNode}");
        if(maxSum<maxSumAtCurrNode)
            maxSum = maxSumAtCurrNode;
        
        return root.val + (int)Math.Max(lSum, rSum);
    }
    
    //int maxSum = int.MinValue; //The FOLLOWING comment is DEPRECATED BECAUSE WHEN READING THE PROBLEM CAREFULLY, YOU'LL SEE THAT YOU CAN'T NOT SELECT! I only realized after failing a test case.://because even if every value is negative, we can select an 0 nodes to get an empty path with the sum 0.
    // public (int lSum, int rSum) rec1(TreeNode root)
    // {
    //     //Clearly we need to do this postorder?
    //     if(root == null)
    //         return (0,0);
        
    //     int currVal = root.val;

    //     (int lLSum, int lRSum) = rec1(root.left);
    //     var (rLSum, rRSum) = rec1(root.right);
        
    //     int lSum = (int) Math.Max(lLSum, lRSum);
    //     if(lSum<0) lSum = 0;
    //     int rSum = (int) Math.Max(rLSum, rRSum);
    //     if(rSum<0) rSum = 0;

    //     // int biggerSum = lSum > rSum ? lSum : rSum;
    //     // biggerSum += currVal;
    //     int maxSumAtCurrNode = lSum+rSum+currVal; //Notice that NONE of these can be negative due to the if conditions above where we set them to 0 in case they're negative (i.e. we ignore the branch(es) that is(are) not helpful).
    //     //We make sure to add the currVal because we have already considered each branch without this node already.
    //     //Also, we would need to include the current one to connect the two branches to form a path.

    //     // Console.WriteLine($"MS= {maxSum}, CV= {currVal}, MSACN = {maxSumAtCurrNode}"); //BS= {biggerSum},
    //     if(maxSum<maxSumAtCurrNode)
    //         maxSum = maxSumAtCurrNode;
        
    //     return ((lSum+currVal), (rSum+currVal));
    // }
}
