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

namespace NEA.Classes
{
    public partial class GraphWindow<T> : Form
    {
        protected Dictionary<T, Point> nodeDict; //Tested as a list, works as a list, please don't break :)
        protected List<(T root, T destination, double edgeWeight)> currentEdgeList;
        protected SolidBrush nodeBrush, textBrush;
        protected Pen edgePen;
        protected Font textFont;
        protected Graphics g;
        protected int fontSize;
        protected int nodeRadius;
        public GraphWindow()
        {
            InitializeComponent();

            this.Location = new Point(0, 0);
            //this.Size = new Size(1600, 1250);

            //currentEdgeList =; //Need to be able to import this. Maybe through a listener? A shared variable might work - talking about multithreading here
            nodeDict = new Dictionary<T, Point>();
            edgePen = new Pen(Color.Orange, 3); //Edges are orange
            nodeBrush = new SolidBrush(Color.OrangeRed); //Nodes are orange-red
            textBrush = new SolidBrush(Color.Black); //Text is dark gray
            fontSize = 12; //A constant to define the size of node names and edge weights
            textFont = new Font(DefaultFont.Name, fontSize, DefaultFont.Style);
            nodeRadius = 20;
            //Need alternate brushes for nodes and edges when they're selected
        }

        public void UpdateAdjList(AdjacencyList<T> inAdjList) //Overwrites existing information in nodeDict and currentEdgeList
        {
            //Need to fix later

            nodeDict = new Dictionary<T, Point>();
            foreach (T i in inAdjList.adjList.Keys)
            {
                nodeDict.Add(i, new Point());
            }
            currentEdgeList = inAdjList.ToEdgeList();
            this.Refresh();
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

            foreach (var i in currentEdgeList)
            {
                Console.WriteLine("Drawing edge for: " + i);
                Console.WriteLine("nodeDict[i.root] = " + nodeDict[i.root]);
                Console.WriteLine("nodeDict[i.destination] = " + nodeDict[i.destination]);
                DrawEdge(nodeDict[i.root], nodeDict[i.destination], i.edgeWeight); //Draws an edge for every edge in the current edge list
            }

            //Draw nodes after edges
            foreach (var i in nodeDict)
            {
                DrawNode(i.Key.ToString(), i.Value, nodeRadius);
                //Need to draw the name of each node as well in the centre
            }
        }
        private void CalculateNodeCoords() //Turn individual coordinates to a Point struct, or pre-generate a Rectangle struct
        {
            List<Point> nodeCoords = new List<Point>();
            int vertices = nodeDict.Count;
            int buffer = 50; //Use this somewhere :)
            int radius = 260; //Radius of regular shape. Make this dependent on the size of the window - smallest of width or height, then some maths to make it fit
            int xComponent, yComponent;
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

                //Remove DrawNode later, call that in a separate more centralised class, CalculateNodeCoords should exclusively calculate, not cause it to draw
                
                //Assign node coordinates to the nodes, then draw the nodes with a foreach in the paint method

                //Account for the radius of the node! It currently draws between each corner
                nodeCoords.Add(new Point((int)(centrePoint.Width / 1.2) + xComponent, (int)(centrePoint.Height / 1.2) + yComponent));
            }

            for (int i = 0; i < nodeDict.Count; i++)
            {
                try
                {
                    nodeDict[nodeDict.ElementAt(i).Key] = nodeCoords[i]; //Assigns a Point location on the screen to each node, used for drawing stuff later
                }
                catch (Exception ex)
                {
                    //Just in case. Should be impossible as nodeCoords is dependent on nodeDict (int vertices being used for the for loop)
                }
            }

        }
        private void DrawEdge(Point start, Point end)
        {
            g.DrawLine(edgePen, start, end);

            Point midPoint = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);
            //Then offset midPoint depending on the length of the string, and the font size
        }
        private void DrawEdge(Point start, Point end, double value) //Extra parameter for weights on lines. Use if graph is weighted
        {
            g.DrawLine(edgePen, start, end);

            Point midPoint = new Point((start.X + end.X) / 2, (start.Y + end.Y) / 2);
            //Then offset midPoint depending on the length of the string, and the font size
            g.DrawString(value.ToString(), textFont, textBrush, midPoint);
        }
        private void DrawNode(string name, Point coords, int radius)
        {
            Rectangle rect = new Rectangle(coords.X - radius, coords.Y - radius, 2 * radius, 2 * radius);
            
            StringFormat format = new StringFormat(); //Using to centre text over the node
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;
            //Could add a method that automatically scales font size if the rectangle area is exceeded by the node name

            g.FillEllipse(nodeBrush, rect);
            g.DrawString(name, textFont, textBrush, rect, format);
        }
        private void GraphWindow_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
