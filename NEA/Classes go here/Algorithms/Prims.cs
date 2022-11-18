using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA.Classes_go_here.Algorithms
{
    public class Prims<T> //Must be undirected, make warnings later and ensure it will ONLY run if undirected!
    {
        //Add another function so that you can return MST length and the MST graph
        AdjacencyMatrix<T> graph;
        AdjacencyList<T> adjList;
        AdjacencyList<T> minSpanTree;
        double MST;
        public Prims(AdjacencyList<T> inAdjList)
        {
            graph = inAdjList.toAdjMatrix();
            adjList = inAdjList;
            minSpanTree = new AdjacencyList<T>();
            MST = -1;
        }
        //public Prims(AdjacencyMatrix<T> inAdjMatrix) //This won't work until the comment on AdjacencyMatrix is addressed. For now use adjLists
        //{
        //    graph = inAdjMatrix;
        //    foreach (T i in graph.nodeNames)
        //    {
        //        minSpanTree.AddNode(i);
        //    }
        //    MST = -1;
        //}
        public void SetAdjList(AdjacencyList<T> inAdjList)
        {
            adjList = inAdjList;
            graph = inAdjList.toAdjMatrix();
        }
        public double FindMST()
        {
            double MSTVal = 0;
            int rowToCross = 0;
            bool found = false, breakFlag = false;
            List<(int x, int y)> validNodes = new List<(int x, int y)>();
            (int x, int y) smallestNode = default;

            do
            {
                //Line through the row to cross:
                for (int i = 0; i < graph.nodeNames.Length; i++)
                {
                    graph.adjMatrix[rowToCross, i].exists = false;
                    validNodes.Remove((rowToCross, i));
                }

                //Sausage: 
                for (int i = 0; i < graph.nodeNames.Length; i++)
                {
                    if (graph.adjMatrix[i, rowToCross].exists == true) //Iterates down the column of the previously selected node. At start this is 0, or 'A'
                    {
                        validNodes.Add((i, rowToCross));
                    }
                }

                //Circle:
                smallestNode = graph.GetSmallestEdge(ref found);
                //Console.WriteLine("Smallest edge found is " + found + " & the coordinates are " + smallestNode); //Used for debugging
                if (found == true)
                {
                    MSTVal += graph.adjMatrix[smallestNode.x, smallestNode.y].weight;
                    graph.adjMatrix[smallestNode.x, smallestNode.y].exists = false; //Do this with a RemoveEdge method later in AdjacencyMatrix, but should remove the smallest node from the table
                    graph.adjMatrix[smallestNode.y, smallestNode.x].exists = false;
                    rowToCross = smallestNode.x;
                    found = false;
                }
                else
                {
                    breakFlag = true;
                }


            } while (!breakFlag); //Break to exit only when no more valid edges exist (when GetSmallestEdge's ref found comes back as false)

            MST = MSTVal;
            return MSTVal; //IT WORKS!!!!!
        }
        public double GetMST() //In case the MST is needed again and not saved to another variable, call this instea of running the algorithm again
        {
            return MST;
        }
        public AdjacencyList<T> GetMSTAdjList() //Only call AFTER calculating MST
        {
            return minSpanTree;
        }
        public AdjacencyMatrix<T> GetMSTAdjMatrix() //Only call AFTER calculating MST
        {
            return minSpanTree.toAdjMatrix();
        }
    }
}
