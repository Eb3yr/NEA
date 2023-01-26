using NEA.Classes.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace NEA.Classes
{
    internal static class Program //Go through every class and tidy up, move declaring vars to start etc etc.
    {
        [STAThread]
        public static void Main(string[] args)
        {
            //To hide Console.WriteLine()s in the complete build, just change the NEA.csproj properties file to a windows application from a console application. No console will open, debug writelines wont be shown
            
            GUIWindow theForm = new GUIWindow(); //Change later so the generic type can vary between any Value type (microsoft docs it if you forget :) )
            Application.Run(theForm);
        }
    }
}
