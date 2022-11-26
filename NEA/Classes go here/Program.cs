using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace NEA.Classes_go_here.Algorithms //Split some stuff up into smaller subroutines in any algorithm no matter the class.
{
    class Program //Go through every class and tidy up, move declaring vars to start etc etc.
    {
        public Program program { get; protected set; } //Other classes need to be able to do program.mainAdjacencyList, so it's read-only outside of Program()
        
        
        public void Startup()
        {
            
        }
    }
    class Start
    {
        public static AdjacencyList<string> mainAdjacencyList { get; protected set; } //Differentiating its name from the adjacency lists in other classes. Can be read by any class but cannot be written to outside of this class
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

            mainAdjacencyList = new AdjacencyList<string>();

            mainAdjacencyList.AddNode("A");
            mainAdjacencyList.AddNode("B");
            mainAdjacencyList.AddNode("C");
            mainAdjacencyList.AddNode("D");
            mainAdjacencyList.AddNode("E");
            mainAdjacencyList.AddNode("F");

            mainAdjacencyList.AddEdge("B", "A", 10, false);
            mainAdjacencyList.AddEdge("C", "A", 7, false);
            mainAdjacencyList.AddEdge("C", "B", 4, false);
            mainAdjacencyList.AddEdge("D", "C", 19.7, false); //MST = 30.7
            mainAdjacencyList.AddEdge("E", "F", 8, false);
            mainAdjacencyList.AddEdge("E", "D", 3, false);
            mainAdjacencyList.AddEdge("F", "A", 5, false); //MST = 27 for {A, B, C, D, E, F}




            Kruskals<string> kruskals = new Kruskals<string>(mainAdjacencyList);
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