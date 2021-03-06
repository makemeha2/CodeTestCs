using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestLv2.Study.DFS
{
    public class DFSBasic
    {
        class GraphNode
        {
            public int  Data { get; private set; }

            public bool Visited { get; set; }

            public List<GraphNode> Edges { get; private set; }

            public GraphNode(int data)
            {
                this.Data = data;
                Edges = new List<GraphNode>();
            }

            public void AddEdge(GraphNode to)
            {
                this.Edges.Add(to);
            }
        }

        class Graph
        {
            public List<GraphNode> GraphNodes { get; set; }
            public List<int> Results { get; set; }

            public Graph()
            {
                GraphNodes = new List<GraphNode>();
                Results = new List<int>();
            }

            private void Visit(GraphNode node)
            {
                node.Visited = true;
                Results.Add(node.Data);

                foreach (var v in node.Edges)
                {
                    if (!v.Visited)
                    {
                        Visit(v);
                    }
                }
            }

            public void Run()
            {
                GraphNodes.ForEach(s => s.Visited = false);

                foreach(var v in GraphNodes)
                {
                    if (!v.Visited)
                        Visit(v);
                }
            }
        }

        private List<int> Solution1()
        {
            Graph g = new Graph();

            GraphNode n1 = new GraphNode(1);
            GraphNode n2 = new GraphNode(2);
            GraphNode n3 = new GraphNode(3);
            GraphNode n4 = new GraphNode(4);
            GraphNode n5 = new GraphNode(5);
            GraphNode n6 = new GraphNode(6);
            GraphNode n7 = new GraphNode(7);
            GraphNode n8 = new GraphNode(8);

            n1.AddEdge(n2);
            n1.AddEdge(n3);
            n1.AddEdge(n8);

            n2.AddEdge(n7);

            n3.AddEdge(n4);
            n3.AddEdge(n5);

            n7.AddEdge(n6);
            n7.AddEdge(n8);
            
            n4.AddEdge(n5);

            
            g.GraphNodes.Add(n2);
            g.GraphNodes.Add(n1);
            g.GraphNodes.Add(n3);
            g.GraphNodes.Add(n4);
            g.GraphNodes.Add(n5);
            g.GraphNodes.Add(n6);
            g.GraphNodes.Add(n7);
            g.GraphNodes.Add(n8);

            g.Run();

            return g.Results;
        }

        public void Run()
        {
            var result = Solution1();

            foreach(var s in result)
            {
                Console.WriteLine(s);
            }
        }
    }
}
