using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSA.NeetCode150.Topics.T12_AdvancedGraphs.P02_MinCostToConnectAllPoints_LC1584;

//## Problem statement Breakdown:
//GIVEN: An array of DISTINCT points on a 2D graph
//RESULT: Minimum cost to connect points
//INPUT: int[][] points, representing the graph, where points[i] == [x,y]
//OUTPUT: int
//TO DO: 
//  - Calculate ways to connect all the points such that:
//      - There's EXACTLY 1 path between 2 points.
//      - While keeping the manhattan distance (cost) minimum.
//FACTS: 
//  - cost == |x1 - x2| + |y1 - y2| (maybe this would need to be asked as a clarification in an interview?)
//CLARIFICATIONS:
//CONSTRAINTS:
// * 1 <= points.length <= 1000
// * -1000 <= xi, yi <= 1000
//EXAMPLES:
// - Input: points = [[0,0],[2,2],[3,3],[2,4],[4,2]]
// - Output: 10

public class Solution {
    IMinCostToConnectPointsCalculator soln;
    public int MinCostConnectPoints(int[][] points) {
        //Basically shortest path in an undirected AND weighted graph problem, so I'm thinking Djikstra's algorithm (I remember a little bit about it from a video I watched a long time ago)
        //OKAY, IT MIGHT NOT BE THE CORRECT APPROACH. AT LEAST Neetcodeio solns don't use it.
        
        //OKAY, I WAS DUMB, DJIKSTRA IS LOWEST_COST PATH FROM A NODE TO ANOTHER NODE (or all nodes) IN DIRECTED and WEIGHTED GRAPHS 
        //BUT IT DOESN'T ACCOUNT FOR HAVING TO GO THROUGH ALL NODES!!
        
        // This problem is ACTUALLY more like finding the Minimum Spanning Tree (MST), 
        
        // What is an MST?
        //      - Recall that Trees are Acyclical, Connected, & Undirected graphs (well, technically they are directed from parent to child, but that's besides the point).
        //      - Recall that since a tree are connected and acyclical, for a tree of N nodes, there are N-1 edges (because to connect N points, you need N-1 lines. If you use N lines, you end up with a cycle (e.g. a square has 4 vertices and 4 edges, or two points with two edges between them, or one point with one edge to itself, etc.)).
        //      - MST is the smallest subset of edges from a graph that still connects all of its nodes but also forms a Tree (Acyclical, Connected, & Undirected Graph as discussed in the point above).
        //      - If the edges are weighted, then we minimize the total cost by taking a subset of the edges such that the cost is minimized while still satisfying the other conditions of the MST.
        //          For unweighted, we just assume the weights to be 1 for all edges.
        //      - There CAN be multiple valid solutions/MSTs. We just return 1 of them, like in shortest path algorithms.
        //      - The result will be one of the valid MSTs but in the form of an edge list.
        //      - Unlike for Shortest path (where we start from source node), for MST it doesn't matter which node we start from (because all node need to be included anyway).
        //      - For some Trees (like binary trees) we usually ignore the fact that they're directed (only parent has pointers to its children), but here it is more strict than that. 
        //          Meaning the edges really will not have any direction.

        // Since we want the MST, we can use the following algorithms (read the MST section above first):
        //  * Prim's Algorithm: [for Undirected & Connected Graphs] 
        //      - We start at any edge.
        //
        //              
        //  * Kruskal's Algorithm:
        //          .

        soln = new PrimsAlgo_1();

        return soln.MinCostConnectPoints(points);
    }

}


public interface IMinCostToConnectPointsCalculator
{
    int MinCostConnectPoints(int[][] points);
}

public class PrimsAlgo_1 : IMinCostToConnectPointsCalculator
{
    int Abs(int num) => (int) Math.Abs(num);
    int Cost(int x1, int y1, int x2, int y2) => Abs(x1-x2) + Abs(y1-y2); //returns ManhattanCost

    public int MinCostConnectPoints(int[][] points)
    {

    }
}