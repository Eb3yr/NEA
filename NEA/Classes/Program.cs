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
        private static void OpenForm()
        {
            GUIWindow theForm = new GUIWindow(); //Change later so the generic type can vary between any Value type (microsoft docs it if you forget :) )
            Application.Run(theForm);
        }
        public static void Main(string[] args)
        {
            //To hide Console.WriteLine()s in the complete build, just change the NEA.csproj properties file to a windows application from a console application. No console will open, debug writelines wont be shown

            //Don't need to do this on a new thread as I won't be interacting with the console (it will be disabled entirely)
            //Should just do Application.Run() at end.
            Thread thread2 = new Thread(new ThreadStart(OpenForm));
            thread2.SetApartmentState(ApartmentState.STA); //Needed to be able to use the save as and load thingy
            thread2.Start();
            Console.ReadLine();
        }
    }
}

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
