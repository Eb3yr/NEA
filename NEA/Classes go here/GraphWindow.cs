﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace NEA.Classes_go_here
{
    public partial class GraphWindow<T> : Form
    {
        protected Dictionary<T, Point> nodeDict; //Tested as a list, works as a list, please don't break :)
        protected List<(T root, T destination, double edgeWeight)> currentEdgeList;
        protected SolidBrush nodeBrush, textBrush;
        protected Pen edgePen;
        protected Font textFont; //https://learn.microsoft.com/en-us/dotnet/api/system.drawing.font.-ctor?view=dotnet-plat-ext-7.0#system-drawing-font-ctor(system-string-system-single)
        protected Graphics g;
        protected int fontSize;
        public GraphWindow()
        {
            InitializeComponent();

            this.Location = new Point(0, 0);
            this.Size = new Size(1600, 1250);

            //currentEdgeList =; //Need to be able to import this. Maybe through a listener? A shared variable sounds good.
            nodeDict = new Dictionary<T, Point>();
            edgePen = new Pen(Color.Orange); //Edges are orange
            nodeBrush = new SolidBrush(Color.Red); //Nodes are red
            textBrush = new SolidBrush(Color.DarkGray); //Text is dark gray
            fontSize = 14; //A constant to define the size of node names and edge weights
            //Use an actual Font class for this later
            //Need alternate brushes for nodes and edges when they're selected
        }
        public void InNodeNames(List<T> inNodeNames) //make sure this doesn't break by doing it multiple times
        {                                            //TryAdd isn't in this version so I need to deal with it myself
            foreach (T i in inNodeNames)
            {
                nodeDict.Add(i, new Point());
            }
        }
        private void GraphWindow_Load(object sender, EventArgs e) //Does stuff on loading
        {

        }
        private void GraphWindow_Paint(object sender, PaintEventArgs e) //Keep things centralised around here
        {
            g = e.Graphics;
            CalculateNodeCoords();

            if (nodeDict.Count == 0)
            {
                Console.WriteLine("Error: Add some nodes to the node dictionary in GraphWindow.cs!");
            }
            else //Add some better error handling later, this is all for debugging purposes and this shouldn't be able to trigger in the final program
            {
                DrawEdge(new Point(), new Point());
            }

        }
        private void CalculateNodeCoords() //Turn individual coordinates to a Point struct, or pre-generate a Rectangle struct
        {
            int vertices = nodeDict.Count;
            int buffer = 50; //Use this :)
            int radius = 360; //Radius of regular shape. Make this dependent on the size of the window - smallest of width or height, then some maths to make it fit
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

                //Remove DrawNode, call that in a separate more centralised class, CalculateNodeCoords should exclusively calculate, not cause it to draw
                DrawNode(new Point((int)(centrePoint.Width / 1.2) + xComponent, (int)(centrePoint.Height / 1.2) + yComponent), nodeRadius); //Maths hard, make use of buffer to find borders
                                                                                                                                            //1.2 is an arbitrary number I came up with to make it fit on the screen semi-reasonably. Make the maths work later

            }

        }
        private void DrawEdge(Point start, Point end)
        {
            g.DrawLine(edgePen, start, end);

            Point midPoint = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);
            //Then offset midPoint depending on the length of the string, and the font size
            g.DrawString("test", textFont, textBrush, midPoint);
        }
        private void DrawNode(Point coords, int radius)
        {
            Rectangle rect = new Rectangle(coords.X - radius, coords.Y - radius, radius, radius);
            g.FillEllipse(nodeBrush, rect);

            //Calculate the rectangle the contains the circle of centre xCoord, yCoord, and specified radius

            //Make a dictionary of nodes for this graph which gets refreshed every time there's a change in the number of nodes in the graph (updating only when the form is used)
            //Then I can draw the name of each node in the circles


            //Draw nodes on top of edges and labels on top of both or else things will go funky
        }
        private void GraphWindow_Resize(object sender, EventArgs e)
        {
            this.Invalidate(); //Sends a thingy that calls a paint event, basically just redraws everything when you resize the window (good) (we like that) 
        }
    }
}
