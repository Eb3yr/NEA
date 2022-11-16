using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA
{
    public class AdjacencyMatrix<T> //Make it set all edges to false until it adds edges
    {
        public (double weight, bool exists)[,] adjMatrix { get; private set; } //Makes adjMatrix readable from outside of the class but only writable from inside the class
        public T[] nodeNames; //Public to make easier to interact with. Will not be editing, only reading, from outside the class.
        public AdjacencyMatrix(int size)
        {
            adjMatrix = new (double, bool)[size, size];
            nodeNames = new T[size];
        }
        public AdjacencyMatrix((double, bool)[,] inAdjMatrix, T[] inNodeNames) //For converting adjList to adjMatrix
        {
            T[] nodeNames = inNodeNames;
            adjMatrix = inAdjMatrix;
        }

        public void WriteAdjMatrix((double, bool)[,] inAdjMatrix)
        {
            adjMatrix = inAdjMatrix;
        }
        public void WriteNodeNames(T[] inNodeNames)
        {
            nodeNames = inNodeNames;
        }
        public void AddNode(T inNode)
        {
            T[] newNodeNames = new T[nodeNames.Length + 1];

            for (int i = 0; i < nodeNames.Length; i++)
            {
                newNodeNames[i] = nodeNames[i];
            }
            newNodeNames[nodeNames.Length] = inNode;

            (double weight, bool exists)[,] newAdjMatrix = new (double weight, bool exists)[adjMatrix.Length + 1, adjMatrix.Length + 1];

            for (int i = 0; i < nodeNames.Length; i++)
            {
                for (int f = 0; f < nodeNames.Length; f++)
                {
                    newAdjMatrix[i, f] = adjMatrix[i, f];
                }
                newAdjMatrix[i, nodeNames.Length] = (-1, false);
                newAdjMatrix[nodeNames.Length, i] = (-1, false);
            }

            nodeNames = newNodeNames;
            adjMatrix = newAdjMatrix;
        }

        public void AddEdge(T inRoot, T inDestination, double weight)
        {
            adjMatrix[Array.IndexOf(nodeNames, inRoot), Array.IndexOf(nodeNames, inDestination)] = (weight, true);
        }
        public void RemoveNode()
        {

        }
        public void RemoveEdge(T inRoot, T inDestination)
        {
            adjMatrix[Array.IndexOf(nodeNames, inRoot), Array.IndexOf(nodeNames, inDestination)].exists = false;
        }

        public (int x, int y) GetSmallestEdge(ref bool found)
        {
            (int x, int y) smallestNode = (0, 0);
            double smallestWeight = double.MaxValue; //An edge weight should never be able to exceed this. Makes it easier to prevent the search from breaking

            if (adjMatrix[smallestNode.x, smallestNode.y].exists == true) //Necessary for if the node actually exists
            {
                smallestWeight = adjMatrix[smallestNode.x, smallestNode.y].weight;
            }

            for (int i = 0; i < nodeNames.Length; i++)
            {
                for (int f = 0; f < nodeNames.Length; f++)
                {
                    if (adjMatrix[i, f].weight < smallestWeight && adjMatrix[i, f].exists == true)
                    {
                        smallestNode = (i, f);
                        smallestWeight = adjMatrix[smallestNode.x, smallestNode.y].weight;
                        found = true;
                    }
                }
            }
            return smallestNode;
        }
        //Make more methods
    }
}
