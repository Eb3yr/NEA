using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA.Classes_go_here.Algorithms
{
    public class Dijkstras<T> //Doesn't need to be undirected, just need to be careful
    {
        AdjacencyList<T> adjList;
        AdjacencyList<T> shortestPath;
        double shortestPathLength;

        struct Node
        {
            public int orderLabel;
            public List<double> workLabels;
            public double permaLabel;
        }

        public Dijkstras(AdjacencyList<T> inAdjList)
        {
            adjList = inAdjList;
            shortestPath = new AdjacencyList<T>();

            foreach (T i in inAdjList.adjList.Keys)
            {
                shortestPath.AddNode(i);
            }
        }
        public AdjacencyList<T> FindShortestPathGraph(T src, T sink)
        {
            if (!adjList.IsConnected()) //Add protection against calling whenever it isn't connected later
            {
                Console.WriteLine("Graph must be connected!");
                return shortestPath;
            }
            Dictionary<T, Node> labelledNodes = new Dictionary<T, Node>();
            Node tempNode = new Node();

            foreach (var i in shortestPath.adjList.Keys)
            {
                labelledNodes.Add(i, tempNode);
            }

            int orderCounter = 1;
            tempNode.orderLabel = orderCounter;
            labelledNodes[src] = tempNode;
            tempNode = default; //Resetting to default so that it breaks in a more obvious way if I slip up, delete later

            List<T> nodesToAssignPerma = labelledNodes.Keys.ToList();
            //Running parallel lists instead of 2D because searching one dimension of a 2D list is a pain
            List<T> tempWorkLabelNodes = new List<T>();
            List<double> tempWorkLabels = new List<double>();
            T currentNode = src;
            double tempVal;


            do //I think this should work now?
            {
                orderCounter++;
                foreach (var i in adjList.adjList[currentNode])
                {
                    tempWorkLabelNodes.Add(i.Key);
                    tempWorkLabels.Add(i.Value);
                }
                //Now assign permanent labels and ordering labels
                tempVal = tempWorkLabels.Min();

                currentNode = tempWorkLabelNodes[tempWorkLabels.IndexOf(tempVal)]; //Gets smallest working label
                tempNode = labelledNodes[currentNode];
                tempNode.permaLabel = tempVal;
                tempNode.workLabels = tempWorkLabels;
                tempNode.orderLabel = orderCounter;
                labelledNodes[currentNode] = tempNode;

                nodesToAssignPerma.Remove(currentNode);
                tempWorkLabelNodes = default;
                tempWorkLabels = default; //Resetting after each use
            } while (nodesToAssignPerma.Count != 0);

            //Do debug stuff here to print out every node's deets

            double difference;
            Stack<T> nodesToCheck = new Stack<T>();
            Dictionary<T, bool> discoveredNodes = new Dictionary<T, bool>();
            nodesToCheck.Push(sink);
            do //Use this one to cycle back to find the shortest path
            {
                //Oh god do I have to DFS it
                currentNode = nodesToCheck.Pop();
                foreach (var i in adjList.adjList[currentNode]) //Make sure this doesn't backtrack, though it shouldn't because of the if
                {
                    if (labelledNodes[currentNode].permaLabel - i.Value == labelledNodes[i.Key].permaLabel)
                    {
                        nodesToCheck.Push(i.Key);
                    }
                } //The foreach needs to go otherwise it won't dfs properly, it'll jump dump everything onto the stack and die



            } while (!currentNode.Equals(src));


            return shortestPath;
        }
        public double FindShortestPathLength(T src, T sink)
        {
            FindShortestPathGraph(src, sink);
            double length = 0;
            foreach (var i in shortestPath.adjList.Values)
            {
                foreach (var j in i.Values)
                {
                    length += j;
                }
            }

            shortestPathLength = length; //Just in case it needs to be used again elsewhere
            return shortestPathLength;
        }
        public void NodeArrayToAdjList() { } //For later
        public AdjacencyList<T> ReturnShortestPathGraph() //Only call if there's already one
        {
            return shortestPath;
        }
        public double ReturnShortestPathLength()
        {
            return shortestPathLength;
        }
    }
}
