using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA.Classes_go_here.Algorithms
{
    public class Kruskals<T> //Everything MUST be undirected, so make the MST tree undirected, and make the class not run if the graph is undirected.
    {
        //Add another function so that you can return MST length and the MST graph
        AdjacencyList<T> graph;
        AdjacencyList<T> minSpanTree;
        public Kruskals(AdjacencyList<T> inAdjList)
        {
            graph = inAdjList;
            minSpanTree = new AdjacencyList<T>();
        }
        //public double FindMST() //As the graph MUST be undirected, I can assume all connections are undirected when designing the algorithm.
        //{
        //    List<T> visitedNodes = new List<T>();
        //    visitedNodes.Add(graph.adjList.ElementAt(0).Key); //Starting with the first node




        //    return SumOfMSTGraph();
        //}
        private void PopulateNodesToVisit(ref List<T> nodesToVisit)
        {
            foreach (var i in graph.adjList.Keys)
            {
                nodesToVisit.Add(i);
            }
        }
        private void PopulateMSTAdjList()
        {
            foreach (var i in graph.adjList.Keys)
            {
                minSpanTree.AddNode(i);
            }
        }
        public double FindMST() //This code is copied from the scuffed Kruskals code from before summer holiday, may or may not work now that cycle detection is fixed
        {
            List<(T root, T destination, double edgeWeight)> listOfEdges = graph.ToEdgeList();
            List<(T root, T destination, double edgeWeight)> tempListOfEdges = listOfEdges;
            List<T> nodesToVisit = new List<T>();
            PopulateNodesToVisit(ref nodesToVisit);
            PopulateMSTAdjList();
            bool isEdgeFoundValid = false;
            tempListOfEdges = graph.BubbleSortEdgeList(); //This is contributing to problem.

            //PROBLEM: finding smallest nodes that are disconnected from visited nodes. FIX. IT. \ڊ^ڊ/
            nodesToVisit.Remove(tempListOfEdges[0].root);
            //Console.WriteLine("Adding edge: " + tempListOfEdges[0]);
            //minSpanTree.adjList[tempListOfEdges[0].root].Add(tempListOfEdges[0].destination, tempListOfEdges[0].edgeWeight);
            while (nodesToVisit.Count != 0)
            {//Cycle detection broken NOT ANYMORE. Also turn dictionary of T, double into T, List<double> because of potential multiple edges between same nodes
                tempListOfEdges = listOfEdges;
                do //If I stab every invalid element and THEN bubble sort it that could work
                {
                    foreach (var i in minSpanTree.adjList) //I don't wanna be starting at a ;-;
                    {
                        Console.WriteLine("Looping for i = " + i.Key);
                        foreach (var f in i.Value.Keys) //If this is empty it will never reach the if statement
                        {
                            Console.WriteLine("Looping for i = " + i.Key + " and f = " + f);
                            if (tempListOfEdges[0].root.Equals(i.Key) || tempListOfEdges[0].root.Equals(f) || tempListOfEdges[0].destination.Equals(i.Key) || tempListOfEdges[0].destination.Equals(f))
                            {
                                isEdgeFoundValid = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Skeetering " + tempListOfEdges[0]);
                                tempListOfEdges.Remove(tempListOfEdges[0]);
                            }
                        }
                        if (tempListOfEdges[0].root.Equals(i.Key) || tempListOfEdges[0].destination.Equals(i.Key))
                        {
                            Console.WriteLine("True!");
                            isEdgeFoundValid = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Skeetering " + tempListOfEdges[0]);
                            tempListOfEdges.Remove(tempListOfEdges[0]);
                        }
                    }

                } while (isEdgeFoundValid == false && tempListOfEdges.Count > 0);
                isEdgeFoundValid = false;

                Console.WriteLine("Adding edge: " + tempListOfEdges[0]);
                minSpanTree.adjList[tempListOfEdges[0].root].Add(tempListOfEdges[0].destination, tempListOfEdges[0].edgeWeight); //Adds smallest edge in list to the adjacency list
                if (minSpanTree.AreCycles() == true) //AreCycles is BROKEN NOT ANYMORE.
                {
                    minSpanTree.adjList[tempListOfEdges[0].root].Remove(tempListOfEdges[0].destination);
                } //Wow this is janky huh, need a better system but it's not too important
                else //The adjlist has a key thing is cycling still when doing the .remove
                {
                    try
                    {
                        nodesToVisit.Remove(tempListOfEdges[0].root);
                        nodesToVisit.Remove(tempListOfEdges[0].destination);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error removing nodes from the list of nodes left to visit: ");
                        Console.WriteLine(e.ToString());
                    }
                }
                tempListOfEdges.RemoveAt(0);
            }

            double MSTLength = 0;
            foreach (var i in minSpanTree.adjList.Values)
            {
                MSTLength += i.Values.Sum();
            }

            Console.WriteLine("The minimum spanning tree is: ");
            var edgeList = minSpanTree.ToEdgeList();

            foreach (var i in edgeList)
            {
                Console.WriteLine(i.root + " ; " + i.destination + " ; " + i.edgeWeight);
            }

            return MSTLength;


        }
        private double SumOfMSTGraph() //Finds the sum of all edges in the MST graph generated by the Kruskals algorithm
        {
            double sum = 0;
            foreach (var i in minSpanTree.adjList)
            {
                foreach (var j in i.Value)
                {
                    sum += j.Value;
                }
            }
            return sum;
        }
    }
}
