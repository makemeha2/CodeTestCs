using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestLv2.Study.BFS
{
    public class BFSBasic
    {
        class GraphNode
        {
            public int Data { get; set; }

            public bool Visited { get; set; }

            public List<GraphNode> Edges { get; set; }

            public GraphNode(int data)
            {
                Data = data;
                Edges = new List<GraphNode>();
            }

            public void AddEdge(GraphNode node)
            {
                Edges.Add(node);
            }
        }

        class Graph
        {
            public List<GraphNode> GraphNodes { get; set; }
            private Queue<GraphNode> _queue { get; set; }

            public List<int> Results { get; set; }

            public Graph()
            {
                GraphNodes = new List<GraphNode>();
                Results = new List<int>();
            }

            public void Run()
            {
                _queue = new Queue<GraphNode>();

                var first = GraphNodes.FirstOrDefault();
                first.Visited = true;
                _queue.Enqueue(first);

                while(_queue.Count != 0)
                {
                    var item = _queue.Dequeue();
                    Results.Add(item.Data);

                    foreach(var vertex in item.Edges)
                    {
                        if (!vertex.Visited)
                        {
                            vertex.Visited = true;
                            _queue.Enqueue(vertex);
                        }
                    }
                }
            }
        }

        public List<int> Solution1()
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
            
            g.GraphNodes.Add(n1);
            g.GraphNodes.Add(n2);
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
            var results = Solution1();

            foreach(var s in results)
            {
                Console.WriteLine(s);
            }
        }

    }
}
