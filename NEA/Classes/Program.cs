using NEA.Classes.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace NEA.Classes //Split some stuff up into smaller subroutines in any algorithm no matter the class. AQA likes that apparently.
{
    class Program //Go through every class and tidy up, move declaring vars to start etc etc.
    {
        public static Program program { get; protected set; } //Other classes need to be able to do program.mainAdjacencyList, so it's read-only outside of Program()
        //public AdjacencyList<string> mainAdjacencyList { get; protected set; } //Differentiating its name from the adjacency lists in other classes. Can be read by any class but cannot
        //private static void OpenForm()
        //{
        //    GraphWindow<string> theForm = new GraphWindow<string>(); //Change later so the generic type can vary between any Value type (microsoft docs it if you forget :) )
        //    Application.Run(theForm);
        //}
        private static void OpenForm1()
        {
            GUIWindow theForm = new GUIWindow(); //Change later so the generic type can vary between any Value type (microsoft docs it if you forget :) )
            Application.Run(theForm);
        }
        public static void Main(string[] args)
        {
            //To hide Console.WriteLine()s in the complete build, just change the NEA.csproj properties file to a windows application from a console application. No console will open, debug writelines wont be shown



            //A lot of things are about to get made obsolete in this class as I'm in the process of moving to the new GUIWindow.cs

            //Thread thread = new Thread(new ThreadStart(OpenForm));
            //thread.Start(); //Opens the form on a separate thread so that console can be used.
            //Will be removing console and replacing it with a new forms GUI, but this will still apply for opening the GraphWindow from the GUIWindow

            Thread thread2 = new Thread(new ThreadStart(OpenForm1));
            thread2.SetApartmentState(ApartmentState.STA); //Needed to be able to use the save as and load thingy
            thread2.Start();

            AdjacencyList<string> mainAdjacencyList = new AdjacencyList<string>();

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


            //Kruskals<string> kruskals = new Kruskals<string>(mainAdjacencyList);
            //Console.WriteLine("MST = ");
            //Console.WriteLine(kruskals.FindMST());

            Console.ReadLine();
        }
    }
}

//Don't forget to go through and remove joke comments at the end of the project

//This is how a template forms app opens the form, from a Program.cs class:

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace WindowsFormsApp1
//{
//    internal static class Program
//    {
//        /// <summary>
//        /// The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new Form1());
//        }
//    }
//}
