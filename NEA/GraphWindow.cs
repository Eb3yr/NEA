using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace NEA
{
    public partial class GraphWindow<T> : Form
    {
        Dictionary<T, NodeCoords> NodeDict;
        public struct NodeCoords
        {
            public int centreX;
            public int centreY;
            public NodeCoords(int inCentreX, int inCentreY)
            {
                centreX = inCentreX;
                centreY = inCentreY;
            }
        }
        public GraphWindow()
        {
            InitializeComponent();
            NodeDict = new Dictionary<T, NodeCoords>();
        }

        private void GraphWindow_Load(object sender, EventArgs e)
        {

        }
        private void GraphWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red, 5);
            CalculateNodeCoords(g, p);

        }
        private void CalculateNodeCoords(Graphics g, Pen p) //Change name
        {
            
            this.Location = new Point(0, 0);
            this.Size = new Size(1600, 1250);
            int vertices = 36;
            int buffer = 50;
            int radius = 360; //make this dependent on the size of the window - smallest of width or height, then some maths to make it fit
            int nodeRadius = 40;
            int xComponent = 0, yComponent = 0;
            double angle = (2 * Math.PI) / vertices; //angle between neighbouring vertices of a regular shape, in radians, of a given number of vertices

            Size centrePoint = new Size(Size.Width / 2, Size.Height / 2);

            for (double i = 0; i < 2 * Math.PI; i += angle) // i / angle gives number of iterations starting from 0
            {
                //Iterating round the circle to generate each node
                Console.WriteLine("\n\nProgression around circle = " + i * 180 / Math.PI);
                xComponent = Convert.ToInt32(radius * Math.Cos(i));
                Console.WriteLine("xComponent = " + xComponent);
                yComponent = Convert.ToInt32(radius * Math.Sin(i));
                Console.WriteLine("yComponent = " + yComponent);
                DrawNode((int)(centrePoint.Width / 1.2) + xComponent, (int)(centrePoint.Height / 1.2) + yComponent, nodeRadius, g, p); //Maths hard, make use of buffer to find borders


                
            
            }

           
        }
        private void DrawNode(int xCoord, int yCoord, int radius, Graphics g, Pen p)
        {
            Rectangle rect = new Rectangle(xCoord - radius, yCoord - radius, radius, radius);
            g.DrawEllipse(p, rect);

            //Calculate the rectangle the contains the circle of centre xCoord, yCoord, and specified radius

            //Make a dictionary of nodes for this graph which gets refreshed every time there's a change in the number of nodes in the graph (updating only when the form is used)
            //Then I can draw the name of each node in the circles
        }
        private void GraphWindow_Resize(object sender, EventArgs e)
        {
            this.Invalidate(); //Sends a thingy that calls a paint event, basically just redraws everything when you resize the window (good) (we like that) 
        }
    }
}
