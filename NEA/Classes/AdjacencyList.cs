using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NEA.Classes
{
    public class AdjacencyList<T>
    {
        public Dictionary<T, Dictionary<T, double>> adjList; //need to make this protected later and sort out all of that
        bool isDirected;
        public AdjacencyList()
        {
            adjList = new Dictionary<T, Dictionary<T, double>>();
            isDirected = false;
        }

        #region Adding, Editing and Removing Nodes and Edges

        //public void AddNode() //Make a new node from scratch with a simple UI. Obselete with the new GUI
        //{
        //    bool exit = false;
        //    T nodeKey = default(T); //Prevents it from breaking if nodeKey is empty
        //    Dictionary<T, double> adjacentNodes = new Dictionary<T, double>();
        //    adjacentNodes = new Dictionary<T, double>();
        //    do
        //    {
        //        Console.Clear();
        //        Console.WriteLine("1. Set name of new node\n2. Alter the list of neighbouring nodes\n3. Add the node with the set name and list of neighbours\n9. Exit without adding a node");
        //        switch (int.Parse(Console.ReadLine()))
        //        {
        //            case 1:
        //                while (true)
        //                {
        //                    try
        //                    {
        //                        Console.WriteLine("Please enter a name for the new node: ");
        //                        nodeKey = (T)Convert.ChangeType(Console.ReadLine(), typeof(T)); //Converts the input to the variable type of nodeKey
        //                        break;
        //                    }
        //                    catch (Exception)
        //                    {
        //                        Console.WriteLine("That input was invalid! The data type of node names is " + typeof(T).Name + ".\n");
        //                        //Thread.Sleep(2500);
        //                        //Console.Clear();
        //                    }
        //                }
        //                break;

        //            case 2:

        //                try
        //                {
        //                    Console.WriteLine("\n1. Add a neighbouring node\n2. Remove a neighbouring node\n3. View a list of neighbouring nodes\n9. Go back");
        //                    int choice = int.Parse(Console.ReadLine());
        //                    switch (choice)
        //                    {
        //                        case 1:
        //                            Console.WriteLine("Please enter the name of the neighbouring node: ");
        //                            T adjNode = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

        //                            Console.WriteLine("Please enter the weight of the connecting edge: ");
        //                            double edgeWeight = double.Parse(Console.ReadLine());

        //                            adjacentNodes.Add(adjNode, edgeWeight);
        //                            break;

        //                        case 2:
        //                            Console.WriteLine("please enter the name of the neighbouring node to remove: ");
        //                            adjNode = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

        //                            adjacentNodes.Remove(adjNode);
        //                            break;

        //                        case 3:
        //                            Console.WriteLine("List of neighbouring nodes: ");
        //                            foreach (KeyValuePair<T, double> i in adjacentNodes)
        //                            {
        //                                Console.WriteLine(i.Key + ", " + i.Value);
        //                            }
        //                            Console.WriteLine();
        //                            break;

        //                        case 9:
        //                            break;

        //                    }

        //                }
        //                catch (Exception)
        //                {
        //                    Console.WriteLine("Invalid input.\n");
        //                }
        //                break;

        //            case 3:
        //                adjList.Add(nodeKey, adjacentNodes);
        //                Console.WriteLine("The new node has been added!\n");
        //                Thread.Sleep(1000);
        //                exit = true;
        //                break;

        //            case 9:
        //                exit = true;
        //                break;

        //        }

        //        Console.Clear();
        //    } while (exit == false);
        //}
        public void AddNode(T nodeKey) //Generates a new node from the input and an empty list of adjacent nodes
        {
            adjList.Add(nodeKey, new Dictionary<T, double>());
        }
        //public void AddEdge() //Obsolete with new GUI
        //{
        //    Console.WriteLine("Input source node: ");
        //    T srcNode = (T)Convert.ChangeType(Console.ReadLine(), typeof(T)); //Converts input to var type T
        //    Console.WriteLine("Input destination node: ");
        //    T destNode = (T)Convert.ChangeType(Console.ReadLine(), typeof(T)); //Converts input to var type T
        //    Console.WriteLine("Input edge weight: ");
        //    double edgeWeight = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Is the edge directed? Y/N"); //Make arrow key menu maybe? Unless figure out forms
        //    bool hasDirection;
        //    if (Console.ReadLine().ToUpper() == "Y")
        //    {
        //        hasDirection = true;
        //    }
        //    else
        //    {
        //        hasDirection = false;
        //    }
        //    AddEdge(srcNode, destNode, edgeWeight, hasDirection);
        //}
        public void AddEdge(T nodeKey, T destinationNode, double weight, bool hasDirection)
        {
            adjList[nodeKey].Add(destinationNode, weight);
            if (hasDirection == false)
            {
                adjList[destinationNode].Add(nodeKey, weight);
            }
            else
            {
                isDirected = true;
            }
        }
        public bool EditNode(T nodeKey, T newNodeName)
        {
            //Copied with slight modifications from RemoveNode() class
            //Should remove each entry with references to the old node name, and add new ones

            //'in adjList.ToList()' instead of just 'in adjList' otherwise the collection is modified, which cannot happen in a foreach, and throws an exception
            bool found = false;
            foreach (KeyValuePair<T, Dictionary<T, double>> i in adjList.ToList())
            {
                foreach (T f in i.Value.Keys) //Checking each list of adjacent nodes in adjacency list
                {
                    if (f.Equals(nodeKey))
                    {
                        adjList[i.Key].Add(newNodeName, adjList[i.Key][f]);
                        adjList[i.Key].Remove(f); //Removes any references to the node to be removed in the neighbouring nodes list of other nodes
                        
                    }
                }
                if (i.Key.Equals(nodeKey)) //Checking each key in adjacency list
                {
                    adjList.Add(newNodeName, i.Value); //Adds the new node with the old node's data
                    adjList.Remove(i.Key); //Removes the old node in the adjacency list
                    found = true;
                }
            }
            return found; //Essentially just returning whether or not the swap took place - eg if the specified node does not exist
        }
        public void EditEdge(T srcNode, T destNode, double newWeight)
        {
            adjList[srcNode][destNode] = newWeight;
        }
        public void RemoveNode(T nodeKey) //I can't even remember if this works, check it lol
        {
            foreach (KeyValuePair<T, Dictionary<T, double>> i in adjList)
            {
                foreach (T f in i.Value.Keys) //Checking each list of adjacent nodes in adjacency list
                {
                    if (f.Equals(nodeKey))
                    {
                        adjList[i.Key].Remove(f); //Removes any references to the node to be removed in the neighbouring nodes list of other nodes
                    }
                }
                if (i.Key.Equals(nodeKey)) //Checking each key in adjacency list
                {
                    adjList.Remove(i.Key); //Removes the node in the adjacency list
                }
            }
        }
        public void RemoveEdge(T nodeKey, T destinationNode) //Add error handling
        {
            adjList[nodeKey].Remove(destinationNode);
        }
        public void RemoveEdge(T nodeKey, T destinationNode, bool isDirected) //Add error handling
        {
            adjList[nodeKey].Remove(destinationNode);
            if (isDirected == false)
            {
                adjList[destinationNode].Remove(nodeKey);
            }
        }

        #endregion

        #region Manipulation of AdjList

        public void MakeUndirected() //May result in a loss of data in graphs where there are connections from A -> B and B -> A with different weights. Add a disclaimer!
        {
            //Not yet implemented
        }
        public List<(T root, T destination, double edgeWeight)> ToEdgeList() //Converts the adjacency list of this instance of the class into a list of edges. 
        {
            var edgeList = new List<(T root, T destination, double edgeWeight)>();
            (T root, T destination, double edgeWeight) tempEdge;
            foreach (var i in adjList)
            {
                for (int f = 0; f < i.Value.Count; f++)
                {
                    tempEdge.root = i.Key;
                    tempEdge.destination = i.Value.ElementAt(f).Key;
                    tempEdge.edgeWeight = i.Value.ElementAt(f).Value;
                    edgeList.Add(tempEdge);
                }
            }
            return edgeList;
        }
        public AdjacencyList<T> ToAdjList(List<(T root, T destination, double edgeWeight)> edgeList) //Converting inputted edge list into an adjacency list
        {
            //Is there any point doing this? It's stupid inefficient for Kruskals
            //Treating this as a placeholder until it shows a use or gets deleted
            return (default);
        }
        public AdjacencyMatrix<T> toAdjMatrix() //ToEdgeList is managed by the AdjacencyMatrix class
        {
            var adjMatrix = new (double, bool)[adjList.Count, adjList.Count];
            var everything = new List<(int x, int y)>(); //Using this to fill the gaps in the adjMatrix
            AdjacencyMatrix<T> adjMatrixReal;
            var nodeNames = new T[adjList.Count];

            for (int i = 0; i < adjList.Count; i++) //Populate nodeNames
            {
                nodeNames[i] = adjList.ElementAt(i).Key;
            }

            for (int i = 0; i < adjList.Count; i++) //Populate everything with every item in 2D array
            {
                for (int f = 0; f < adjList.Count; f++)
                {
                    everything.Add((i, f));
                }
            }

            for (int i = 0; i < nodeNames.Length; i++) //"From" along y axis
            {
                foreach (var f in adjList.ElementAt(i).Value) //"To" along x axis
                {
                    adjMatrix[i, Array.IndexOf(nodeNames, f.Key)] = (f.Value, true);
                    everything.Remove((Array.IndexOf(nodeNames, f.Key), i));
                }
            }

            foreach (var i in everything) //Everything that wasn't a part of the adjList is set to a value of -1 weight and false for "exists"
            {
                adjMatrix[i.y, i.x] = (-1, false); //As it goes from y TO x in an adjMatrix. This tripped me up for a while!

            }

            adjMatrixReal = new AdjacencyMatrix<T>(nodeNames.Length);
            adjMatrixReal.WriteToNodeNames(nodeNames);
            adjMatrixReal.WriteToAdjMatrix(adjMatrix);

            return adjMatrixReal;
        }
        private void SortAdjList()
        {
            //Should sort so that all source nodes are in alphabetical order, and the dictionary of edges should be in alphabetical order in respect to destination nodes
            //May not be implemented, hence private. 
        }
        public List<(T root, T destination, double edgeWeight)> BubbleSortEdgeList() //Bubble sorts an edge list and returns a List of edges, moved from the Kruskal class 
        {
            var listOfEdges = ToEdgeList();
            int swapsPerIteration;
            (T root, T destination, double edgeWeight) tempEdge;
            do
            {
                swapsPerIteration = 0;
                for (int i = 0; i < listOfEdges.Count() - 1; i++) //-1 so bubble sort doesn't outOfIndex error
                {
                    if (listOfEdges[i].edgeWeight > listOfEdges[i + 1].edgeWeight)
                    {
                        tempEdge = listOfEdges[i + 1];
                        listOfEdges[i + 1] = listOfEdges[i];
                        listOfEdges[i] = tempEdge;
                        swapsPerIteration++;
                    }
                }
            } while (swapsPerIteration != 0);

            return listOfEdges;
        }

        #endregion

        public bool IsConnected()
        {
            return default;
        }
        public bool IsDirected() //To prevent accidental manipulation of isDirected from breaking things. Use this to block algorithms from running if isDirected = true. Not implemented to algorithms yet!
        {
            return isDirected;
        }
        public bool AreCycles() //Doing a depth first search that returns true if it detects a cycle
        {
            //PROBLEM FOUND!
            //Any use case will be using bidirectional edges, so I can assume every edge is bidirectional
            //The source node is set to visited, then it finds an adjacent node. That adjacent node has an edge connection to the source node, sees it is visited,
            //and will detect a cycle.
            //Solution? Remove half of the edges, so that there is only one edge referring to each edge, instead of one for each direction.
            //Solution worked!

            var nodes = new Dictionary<T, bool>(); //Dictionary of all nodes and boolean flag visited

            var dfsStack = new Stack<T>();
            T poppedNode;
            bool cycleDetected = false;

            foreach (T i in adjList.Keys) //Populate list of nodes with boolean flag visited attached
            {
                Console.WriteLine("adjlist has a key");
                nodes.Add(i, false);
            }



            //Delete half of nodes: with adj lists say nodes can only be described in alphabetical order? Eg A->D but not D->A?
            //Make this into an independent protected method later

            T srcNode, destNode;
            List<T> nodeList = nodes.Keys.ToList(); //Using exclusively for comparing indexes of nodes 
            for (int i = 0; i < nodes.Count; i++)
            {
                srcNode = adjList.ElementAt(i).Key; //Source node of edge
                for (int j = 0; j < adjList[srcNode].Count; j++) //Count number of edges
                {
                    destNode = adjList[srcNode].ElementAt(j).Key; //Destination node of edge
                    if (nodeList.IndexOf(srcNode) > nodeList.IndexOf(destNode))
                    {
                        adjList[srcNode].Remove(destNode); //Removes duplicate edge
                    }
                }
            }
            //Works at removing duplicates, fixes the problem!


            dfsStack.Push(nodes.ElementAt(0).Key); //Pushing first element to stack

            Console.WriteLine("Printing current MST:"); //Debugging purpose
            foreach (var i in ToEdgeList())
            {
                Console.WriteLine(i);
            }

            do
            {
                poppedNode = dfsStack.Pop();
                Console.WriteLine("\nPopping " + poppedNode + ", setting visited = true");
                nodes[poppedNode] = true; //Set as visited 

                foreach (T i in adjList[poppedNode].Keys)
                {
                    Console.WriteLine("i = " + i + ", nodes[i] = " + nodes[i]);
                    Console.WriteLine("Checking " + i);
                    if (nodes[i] == false)
                    {
                        Console.WriteLine(i + " is unvisited. Pushing now: ");
                        dfsStack.Push(i);
                        nodes[i] = true;
                    }
                    else
                    {
                        Console.WriteLine(i + " has already been visited.");
                        Console.WriteLine("No unfound node found");
                        cycleDetected = true;
                    }
                }
            } while (dfsStack.Count() != 0);
            return cycleDetected;
        }      
        public void PrintAdjList()
        {
            Console.WriteLine("Printing adjacency list: ");
            foreach (var i in adjList)
            {
                foreach (var j in i.Value)
                {
                    Console.WriteLine(i.Key + " -> " + j.Key + " : " + j.Value);
                }

            }
        }  
        private void ViewNodeInfo() { }//Placeholder, likely won't be used, hence private
        
        /////////////// SORT OUT ERROR HANDLING FOR ALL METHODS IN THIS CLASS LATER, DONT REMOVE UNTIL DONE (　o=^•ェ•)o　┏━┓
    }
}
