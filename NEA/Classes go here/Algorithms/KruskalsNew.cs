using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA.Classes_go_here.Algorithms
{
    public class KruskalsNew<T>
    {
        AdjacencyList<T> graph;
        public AdjacencyList<T> minSpanTree { get; protected set; } //Can be read but not written to from outside of the class
        public KruskalsNew(AdjacencyList<T> inAdjList)
        {
            graph = inAdjList;
            minSpanTree = new AdjacencyList<T>();
        }

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

        public double FindMST() //GLHF
        {














            return default;
        }




    }
}
