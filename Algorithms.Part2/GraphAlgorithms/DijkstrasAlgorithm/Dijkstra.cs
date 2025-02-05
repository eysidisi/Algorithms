﻿using Priority_Queue;

namespace Algorithms.Part2.GraphAlgorithms.DijkstrasAlgorithm
{
    public class Dijkstra
    {
        public Dijkstra()
        {

        }

        public int[] FindClosestDistances(UndirectedGraph graph, int sourceVertexIndex)
        {
            List<int> accessibleVertices = FindAccessibleVertices(graph, sourceVertexIndex);

            int[] distances = new int[graph.NumOfVertices];

            for (int i = 0; i < distances.Count(); i++)
            {
                distances[i] = 10000;
            }

            distances[sourceVertexIndex] = 0;

            List<int> visitedVertices = new List<int>() { sourceVertexIndex };

            while (visitedVertices.Count != accessibleVertices.Count)
            {
                int minDijkstraDistance = int.MaxValue;
                int nextVertexToVisitIndex = -1;

                for (int i = 0; i < visitedVertices.Count; i++)
                {
                    int vertexIndex = visitedVertices[i];
                    List<Edge> edgesFromVertex = graph.Edges[vertexIndex];

                    foreach (var edge in edgesFromVertex)
                    {
                        if (visitedVertices.Contains(edge.destVertex) == false)
                        {
                            var newDistance = distances[vertexIndex] + edge.weight;

                            if (newDistance < minDijkstraDistance)
                            {
                                nextVertexToVisitIndex = edge.destVertex;
                                minDijkstraDistance = newDistance;
                            }
                        }
                    }
                }

                distances[nextVertexToVisitIndex] = minDijkstraDistance;
                visitedVertices.Add(nextVertexToVisitIndex);
            }

            return distances;
        }

        private List<int> FindAccessibleVertices(UndirectedGraph graph, int vertexIndex)
        {
            List<int> accessibleVertices = new List<int>(graph.NumOfVertices);

            Queue<int> verticesToVisit = new Queue<int>(graph.NumOfVertices);

            verticesToVisit.Enqueue(vertexIndex);

            while (verticesToVisit.Count != 0)
            {
                int currentVertexIndex = verticesToVisit.Dequeue();

                if (accessibleVertices.Contains(currentVertexIndex) == false)
                {
                    accessibleVertices.Add(currentVertexIndex);

                    List<Edge> edges = graph.Edges[currentVertexIndex];

                    List<int> neighbourVertics = edges.Select(e => e.destVertex).ToList();

                    neighbourVertics.ForEach(v => verticesToVisit.Enqueue(v));
                }
            }

            return accessibleVertices;
        }

        public int[] FindClosestDistancesUsingHeap(UndirectedGraph graph, int sourceVertexIndex)
        {
            List<int> accessibleVertices = FindAccessibleVertices(graph, sourceVertexIndex);

            int[] distances = new int[graph.NumOfVertices];
            bool[] isVertexVisited = new bool[graph.NumOfVertices];

            for (int i = 0; i < distances.Count(); i++)
            {
                distances[i] = 10000;
            }

            distances[sourceVertexIndex] = 0;

            int numOfVisitedVertices = 0;

            SimplePriorityQueue<int> indexNDistance = new SimplePriorityQueue<int>();
            indexNDistance.Enqueue(sourceVertexIndex, 0);

            while (numOfVisitedVertices != accessibleVertices.Count)
            {
                // Remove one from priority queue
                int currentVisitedIndex = indexNDistance.Dequeue();

                // If it's not visited visit
                if (isVertexVisited[currentVisitedIndex] == false)
                {
                    isVertexVisited[currentVisitedIndex] = true;
                    numOfVisitedVertices++;

                    List<Edge> edgesFromVertex = graph.Edges[currentVisitedIndex];

                    foreach (var edge in edgesFromVertex)
                    {
                        int currentCalculatedDist = edge.weight + distances[currentVisitedIndex];

                        if (distances[edge.destVertex] > currentCalculatedDist)
                        {
                            distances[edge.destVertex] = currentCalculatedDist;
                            indexNDistance.Enqueue(edge.destVertex, currentCalculatedDist);
                        }
                    }
                }
            }

            return distances;
        }
    }
}