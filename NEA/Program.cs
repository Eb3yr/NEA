using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace NEA //Split some stuff up into smaller subroutines in any algorithm no matter the class. AQA likes that apparently.
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
    public class AdjacencyList<T>
    {
        public Dictionary<T, Dictionary<T, double>> adjList; //need to make this protected later and sort out all of that
        bool isDirected;
        public AdjacencyList()
        {
            adjList = new Dictionary<T, Dictionary<T, double>>();
            isDirected = true;
        }
        public bool IsConnected()
        {
            return default;
        }
        public bool IsDirected() //To prevent accidental manipulation of isDirected from breaking things. Use this to block algorithms from running is isDirected = true. Not implemented to algorithms yet!
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
        public AdjacencyMatrix<T> toAdjMatrix()
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
            adjMatrixReal.WriteNodeNames(nodeNames);
            adjMatrixReal.WriteAdjMatrix(adjMatrix);

            return adjMatrixReal;
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
        public void AddNode() //Make a new node from scratch with a simple UI
        {
            bool exit = false;
            T nodeKey = default(T); //Prevents it from breaking if nodeKey is empty
            Dictionary<T, double> adjacentNodes = new Dictionary<T, double>();
            adjacentNodes = new Dictionary<T, double>();
            do
            {
                Console.Clear();
                Console.WriteLine("1. Set name of new node\n2. Alter the list of neighbouring nodes\n3. Add the node with the set name and list of neighbours\n9. Exit without adding a node");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Please enter a name for the new node: ");
                                nodeKey = (T)Convert.ChangeType(Console.ReadLine(), typeof(T)); //Converts the input to the variable type of nodeKey
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("That input was invalid! The data type of node names is " + typeof(T).Name + ".\n");
                                //Thread.Sleep(2500);
                                //Console.Clear();
                            }
                        }
                        break;

                    case 2:

                        try
                        {
                            Console.WriteLine("\n1. Add a neighbouring node\n2. Remove a neighbouring node\n3. View a list of neighbouring nodes\n9. Go back");
                            int choice = int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Please enter the name of the neighbouring node: ");
                                    T adjNode = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                                    Console.WriteLine("Please enter the weight of the connecting edge: ");
                                    double edgeWeight = double.Parse(Console.ReadLine());

                                    adjacentNodes.Add(adjNode, edgeWeight);
                                    break;

                                case 2:
                                    Console.WriteLine("please enter the name of the neighbouring node to remove: ");
                                    adjNode = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                                    adjacentNodes.Remove(adjNode);
                                    break;

                                case 3:
                                    Console.WriteLine("List of neighbouring nodes: ");
                                    foreach (KeyValuePair<T, double> i in adjacentNodes)
                                    {
                                        Console.WriteLine(i.Key + ", " + i.Value);
                                    }
                                    Console.WriteLine();
                                    break;

                                case 9:
                                    break;

                            }

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input.\n");
                        }
                        break;

                    case 3:
                        adjList.Add(nodeKey, adjacentNodes);
                        Console.WriteLine("The new node has been added!\n");
                        Thread.Sleep(1000);
                        exit = true;
                        break;

                    case 9:
                        exit = true;
                        break;

                }

                Console.Clear();
            } while (exit == false);
        }
        public void AddNode(T nodeKey) //Generates a new node from the input and an empty list of adjacent nodes
        {
            adjList.Add(nodeKey, new Dictionary<T, double>());
        }
        public void AddEdge() //Primitive, no error handling but WORKS (/▽＼)
        {
            Console.WriteLine("Input source node: ");
            T srcNode = (T)Convert.ChangeType(Console.ReadLine(), typeof(T)); //Converts input to var type T
            Console.WriteLine("Input destination node: ");
            T destNode = (T)Convert.ChangeType(Console.ReadLine(), typeof(T)); //Converts input to var type T
            Console.WriteLine("Input edge weight: ");
            double edgeWeight = int.Parse(Console.ReadLine());
            Console.WriteLine("Is the edge directed? Y/N"); //Make arrow key menu maybe? Unless figure out forms
            bool hasDirection;
            if (Console.ReadLine().ToUpper() == "Y")
            {
                hasDirection = true;
            }
            else
            {
                hasDirection = false;
            }
            AddEdge(srcNode, destNode, edgeWeight, hasDirection);
        }
        public void AddEdge(T nodeKey, T destinationNode, double weight, bool hasDirection)
        {
            adjList[nodeKey].Add(destinationNode, weight);
            if (hasDirection == false)
            {
                adjList[destinationNode].Add(nodeKey, weight);
            }
        }
        public void RemoveNode(T nodeKey) //I can't even remember if this works, check it lol
        {
            foreach (KeyValuePair<T, Dictionary<T, double>> i in adjList)
            {
                {
                    if (i.Key.Equals(nodeKey)) //Checking each key in adjacency list
                        adjList.Remove(i.Key); //Removes the node in the adjacency list
                }
                foreach (T f in i.Value.Keys) //Checking each list of adjacent nodes in adjacency list
                {
                    if (f.Equals(nodeKey))
                    {
                        adjList[i.Key].Remove(f); //Removes any references to the node to be removed in the neighbouring nodes list of other nodes
                    }
                }
            }
        }
        public void RemoveEdge(T nodeKey, T destinationNode)
        {
            adjList[nodeKey].Remove(destinationNode);
        }
        public void ViewNodeInfo()
        {

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

        /////////////// SORT OUT ERROR HANDLING FOR ALL METHODS IN THIS CLASS LATER, DONT REMOVE UNTIL DONE (　o=^•ェ•)o　┏━┓
    }

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


    class Program //Go through every class and tidy up, move declaring vars to start etc etc.
    {
        private static void OpenForm()
        {
            GraphWindow<string> theForm = new GraphWindow<string>(); //Change later so the generic type can vary between any Value type (microsoft docs it if you forget :) )
            Application.Run(theForm);
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(OpenForm));
            thread.Start(); //I feel like GOD

            //https://www.albahari.com/threading/#_Passing_Data_to_a_Thread
            //https://www.albahari.com/threading/part2.aspx#_Locking
            //https://www.codeproject.com/Questions/700159/How-to-pass-data-to-a-thread-on-runtime-in-csharp
            //https://www.codeproject.com/Articles/9836/Managing-shared-resource-access-in-NET-multi-threa amazing guy from India 17 years ago once said

            AdjacencyList<string> adjList = new AdjacencyList<string>();

            adjList.AddNode("A");
            adjList.AddNode("B");
            adjList.AddNode("C");
            adjList.AddNode("D");
            adjList.AddNode("E");
            adjList.AddNode("F");

            adjList.AddEdge("B", "A", 10, false);
            adjList.AddEdge("C", "A", 7, false);
            adjList.AddEdge("C", "B", 4, false);
            adjList.AddEdge("D", "C", 19.7, false); //MST = 30.7
            adjList.AddEdge("E", "F", 8, false);
            adjList.AddEdge("E", "D", 3, false);
            adjList.AddEdge("F", "A", 5, false); //MST = 27 for {A, B, C, D, E, F}




            Kruskals<string> kruskals = new Kruskals<string>(adjList);
            Console.WriteLine("MST = ");
            Console.WriteLine(kruskals.FindMST());

            //Prims<string> prims = new Prims<string>(adjList);

            //prims.CycleTest();

            //Console.WriteLine(prims.FindMST());

            //adjList.toAdjMatrix();

            //bool quit = false;
            //int input;
            //Prims<string> prims = new Prims<string>(adjList);

            //Console.WriteLine("Interact with the menu by entering the number of the option and pressing enter");
            //Thread.Sleep(2000);
            //do //Primitive menu
            //{
            //    Console.Clear();
            //    Console.WriteLine();
            //    Console.WriteLine("1. Add new node\n2. Remove node\n3. Add new edge\n4. Remove edge\n5. Print adjacency list\n6. Do Prims\n\n7. DFS the adjlist\n9. Exit");
            //    input = int.Parse(Console.ReadLine());
            //    Console.WriteLine();

            //    switch (input)
            //    {
            //        case 1:
            //            adjList.AddNode();
            //            break;

            //        case 2:
            //            Console.WriteLine("Which node do you want to remove?");
            //            string nodeToRemove = Console.ReadLine();
            //            try
            //            {
            //                adjList.RemoveNode(nodeToRemove);
            //            }
            //            catch (Exception e)
            //            {
            //                Console.WriteLine("Try removing all edges connected to this node first!");
            //            }
            //            break;

            //        case 3:
            //            adjList.AddEdge();
            //            break;

            //        case 4:
            //            Console.WriteLine("Which edge do you want to remove?");
            //            Console.WriteLine("Source node: ");
            //            string srcNode = Console.ReadLine();
            //            Console.WriteLine("Destination node: ");
            //            string dstNode = Console.ReadLine();
            //            Console.WriteLine("Is bidirectional? Y/N");
            //            adjList.RemoveEdge(srcNode, dstNode);

            //            if (Console.ReadLine().ToUpper() == "Y")
            //            {
            //                try
            //                {
            //                    adjList.RemoveEdge(dstNode, srcNode);
            //                }
            //                catch (Exception e) { };
            //            }
            //            break;

            //        case 5:
            //            adjList.PrintAdjList();
            //            break;

            //        case 6:
            //            prims.SetAdjList(adjList);
            //            Console.WriteLine("MST calculated through Prims algorithm is " + prims.FindMST());
            //            Console.ReadLine();
            //            break;

            //        case 7:
            //            Console.WriteLine("Are cycles: " + adjList.AreCycles());
            //            Console.ReadLine();
            //            break;

            //        case 9:
            //            quit = true;
            //            break;
            //    }

            //} while (quit == false);

            Console.ReadLine();
        }
    }
}

//Don't forget to go through and remove joke comments at the end of the project