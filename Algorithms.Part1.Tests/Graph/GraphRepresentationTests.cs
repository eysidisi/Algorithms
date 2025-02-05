﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part1.Tests.Graph
{
    public class GraphRepresentationTests
    {
        // V0-V1
        [Fact]
        public void AddEdge_OneEdge()
        {
            // Arrange
            const int NumberOfVertices = 2;
            var graph = new Part1.Graph.GraphRepresentation(NumberOfVertices);

            // Act
            graph.AddEdge(0, 1);
            var V0 = graph.Vertices[0];
            var V1 = graph.Vertices[1];

            // Assert
            Assert.Contains(V0, graph.Edges[0].Vertices);
            Assert.Contains(V1, graph.Edges[0].Vertices);
        }

        //    V2
        //   / | \
        // V0-V1-V4
        //   \ | /
        //    V3
        [Fact]
        public void AddEdge_EightEdges()
        {
            // Arrange
            const int NumberOfVertices = 5;
            var graph = new Part1.Graph.GraphRepresentation(NumberOfVertices);

            // Act
            #region Add Edges
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);

            graph.AddEdge(0, 3);
            graph.AddEdge(1, 2);

            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);

            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);

            var V0 = graph.Vertices[0];
            var V1 = graph.Vertices[1];
            var V2 = graph.Vertices[2];
            var V3 = graph.Vertices[3];
            var V4 = graph.Vertices[4];
            #endregion

            // Assert
            Assert.Equal(3, V0.Edges.Count);
            Assert.Equal(4, V1.Edges.Count);
            Assert.Equal(3, V2.Edges.Count);
            Assert.Equal(3, V3.Edges.Count);
            Assert.Equal(3, V4.Edges.Count);

            Assert.Contains(V0, graph.Edges[0].Vertices);
            Assert.Contains(V1, graph.Edges[0].Vertices);

            Assert.Contains(V0, graph.Edges[1].Vertices);
            Assert.Contains(V2, graph.Edges[1].Vertices);

            Assert.Contains(V0, graph.Edges[2].Vertices);
            Assert.Contains(V3, graph.Edges[2].Vertices);

            Assert.Contains(V1, graph.Edges[3].Vertices);
            Assert.Contains(V2, graph.Edges[3].Vertices);

            Assert.Contains(V1, graph.Edges[4].Vertices);
            Assert.Contains(V3, graph.Edges[4].Vertices);

            Assert.Contains(V1, graph.Edges[5].Vertices);
            Assert.Contains(V4, graph.Edges[5].Vertices);

            Assert.Contains(V2, graph.Edges[6].Vertices);
            Assert.Contains(V4, graph.Edges[6].Vertices);

            Assert.Contains(V3, graph.Edges[7].Vertices);
            Assert.Contains(V4, graph.Edges[7].Vertices);
        }

        // V0-V1
        [Fact]
        public void Constructor_OneEdgeGraph()
        {
            // Arrange
            var graph = new Part1.Graph.GraphRepresentation(2);
            graph.AddEdge(0, 1);

            // Act
            var newGraph = new Part1.Graph.GraphRepresentation(graph);
            var edge = newGraph.Edges[0];
            var vertex1 = newGraph.Vertices[0];
            var vertex2 = newGraph.Vertices[1];

            // Assert
            Assert.Equal(1, newGraph.Edges.Count);
            Assert.Contains(vertex1, edge.Vertices);
            Assert.Contains(vertex2, edge.Vertices);
        }
        // V0-V1
        [Fact]
        public void ContractEdge_ZeroToOne_TwoVerticesGraph()
        {
            // Arrange
            const int NumberOfVertices = 2;
            var graph = new Part1.Graph.GraphRepresentation(NumberOfVertices);

            graph.AddEdge(0, 1);

            var V0 = graph.Vertices[0];
            var V1 = graph.Vertices[1];

            // Act
            graph.ContractEdge(0);

            // Assert
            Assert.Equal(0, graph.Edges.Count);
            Assert.Empty(V0.Edges);
            Assert.Empty(V1.Edges);
        }

        // V0=V1-V2
        [Fact]
        public void ContractEdge_ZeroToOne_ThreeVertices()
        {
            // Arrange
            const int NumberOfVertices = 3;
            var graph = new Part1.Graph.GraphRepresentation(NumberOfVertices);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);

            var V1 = graph.Vertices[1];
            var V2 = graph.Vertices[2];

            // Act
            graph.ContractEdge(0);

            // Assert
            Assert.Equal(1, graph.Edges.Count);
            Assert.Contains(V1, graph.Edges[0].Vertices);
            Assert.Contains(V2, graph.Edges[0].Vertices);
        }

        //    V2           V2
        //   / | \         || \
        // V0-V1-V4 ---->  V1-V4
        //   \ | /         || /
        //    V3           V3
        [Fact]
        public void ContractEdge_ZeroToOne_EightVerticesGraph()
        {
            #region Arrange
            // Arrange
            const int NumberOfVertices = 5;
            var graph = new Part1.Graph.GraphRepresentation(NumberOfVertices);

            // Act
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);

            graph.AddEdge(0, 3);
            graph.AddEdge(1, 2);

            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);

            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);

            var V0 = graph.Vertices[0];
            var V1 = graph.Vertices[1];
            var V2 = graph.Vertices[2];
            var V3 = graph.Vertices[3];
            var V4 = graph.Vertices[4];
            #endregion

            // Act
            graph.ContractEdge(0);

            // Assert
            Assert.Equal(7, graph.Edges.Count);

            Assert.Equal(5, V1.edges.Count);

            Assert.Contains(V1, V2.edges[0].Vertices);
            Assert.Contains(V1, V2.edges[1].Vertices);

            Assert.Contains(V1, V3.edges[0].Vertices);
            Assert.Contains(V1, V3.edges[1].Vertices);
        }

        //    V2            V2
        //   / | \        / ||
        // V0-V1-V4--->  V0-V4
        //   \ | /        \ ||
        //    V3            V3
        [Fact]
        public void ContractEdge_OneToFour_EightVerticesGraph()
        {
            #region Arrange
            // Arrange
            const int NumberOfVertices = 5;
            var graph = new Part1.Graph.GraphRepresentation(NumberOfVertices);

            // Act
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);

            graph.AddEdge(0, 3);
            graph.AddEdge(1, 2);

            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);

            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);

            var V0 = graph.Vertices[0];
            var V1 = graph.Vertices[1];
            var V2 = graph.Vertices[2];
            var V3 = graph.Vertices[3];
            var V4 = graph.Vertices[4];
            #endregion

            // Act
            graph.ContractEdge(5);

            // Assert
            Assert.Equal(7, graph.Edges.Count);
            Assert.Equal(5, V4.edges.Count);

            Assert.Contains(V4, V0.edges[0].Vertices);
            Assert.Contains(V4, V2.edges[1].Vertices);
            Assert.Contains(V4, V3.edges[1].Vertices);

            Assert.Equal(3, V0.edges.Count);
            Assert.Equal(3, V2.edges.Count);
            Assert.Equal(3, V3.edges.Count);
            Assert.Equal(5, V4.edges.Count);
        }

        //    V2              V2
        //   / | \          / ||           
        // V0-V1-V4 ---->  V0-V4 ---->  V2 -3 V4
        //   \ | /          \ ||           \  ||
        //    V3              V3              V3
        [Fact]
        public void ContractEdge_OneToFour_Then_ZeroToTwo_EightVerticesGraph()
        {
            #region Arrange
            // Arrange
            const int NumberOfVertices = 5;
            var graph = new Part1.Graph.GraphRepresentation(NumberOfVertices);

            // Act
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);

            graph.AddEdge(0, 3);
            graph.AddEdge(1, 2);

            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);

            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);

            var V2 = graph.Vertices[2];
            var V3 = graph.Vertices[3];
            var V4 = graph.Vertices[4];
            #endregion

            // Act
            graph.ContractEdge(5);
            graph.ContractEdge(1);

            // Assert
            Assert.Equal(6, graph.Edges.Count);

            Assert.Equal(4, V2.edges.Count);
            Assert.Equal(3, V3.edges.Count);
            Assert.Equal(5, V4.edges.Count);

            Assert.Contains(V2, graph.Edges.First(e => e.Id == 0).Vertices);
            Assert.Contains(V4, graph.Edges.First(e => e.Id == 0).Vertices);

            Assert.Contains(V2, graph.Edges.First(e => e.Id == 3).Vertices);
            Assert.Contains(V4, graph.Edges.First(e => e.Id == 3).Vertices);

            Assert.Contains(V2, graph.Edges.First(e => e.Id == 6).Vertices);
            Assert.Contains(V4, graph.Edges.First(e => e.Id == 6).Vertices);

            Assert.Contains(V2, graph.Edges.First(e => e.Id == 2).Vertices);
            Assert.Contains(V3, graph.Edges.First(e => e.Id == 2).Vertices);

            Assert.Contains(V3, graph.Edges.First(e => e.Id == 4).Vertices);
            Assert.Contains(V4, graph.Edges.First(e => e.Id == 4).Vertices);

            Assert.Contains(V3, graph.Edges.First(e => e.Id == 7).Vertices);
            Assert.Contains(V4, graph.Edges.First(e => e.Id == 7).Vertices);
        }

        //    V2              V2
        //   / | \          / ||           
        // V0-V1-V4 ---->  V0-V4 ---->  V2 -3 V4 ---->  V2
        //   \ | /          \ ||           \  ||       | | |
        //    V3              V3              V3        V3
        [Fact]
        public void ContractEdge_OneToFour_Then_ZeroToTwo_TwoToFour_EightVerticesGraph()
        {
            #region Arrange
            // Arrange
            const int NumberOfVertices = 5;
            var graph = new Part1.Graph.GraphRepresentation(NumberOfVertices);

            // Act
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);

            graph.AddEdge(0, 3);
            graph.AddEdge(1, 2);

            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);

            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);

            var V2 = graph.Vertices[2];
            var V3 = graph.Vertices[3];
            #endregion

            // Act
            graph.ContractEdge(5);
            graph.ContractEdge(1);
            graph.ContractEdge(0);

            // Assert
            Assert.Equal(3, graph.Edges.Count);
            Assert.Equal(2, graph.Vertices.Count);

            Assert.Contains(V2, graph.Vertices);
            Assert.Contains(V3, graph.Vertices);


            Assert.Equal(3, V2.edges.Count);
            Assert.Equal(3, V3.edges.Count);

            Assert.Contains(V2, graph.Edges.First(e => e.Id == 4).Vertices);
            Assert.Contains(V2, graph.Edges.First(e => e.Id == 7).Vertices);
            Assert.Contains(V2, graph.Edges.First(e => e.Id == 2).Vertices);

            Assert.Contains(V3, graph.Edges.First(e => e.Id == 4).Vertices);
            Assert.Contains(V3, graph.Edges.First(e => e.Id == 7).Vertices);
            Assert.Contains(V3, graph.Edges.First(e => e.Id == 2).Vertices);
        }

        [Fact]
        public void Equals_SameGraphs()
        {
            // Arrange
            var graph1 = new Part1.Graph.GraphRepresentation(3);
            var graph2 = new Part1.Graph.GraphRepresentation(3);

            graph1.AddEdge(0, 1);
            graph1.AddEdge(0, 2);
            graph1.AddEdge(1, 2);

            graph2.AddEdge(0, 1);
            graph2.AddEdge(0, 2);
            graph2.AddEdge(1, 2);

            // Act


            // Assert
            Assert.Equal(graph1, graph2);
        }

        [Fact]
        public void Equals_SameSize_DifferentGraphs()
        {
            // Arrange
            var graph1 = new Part1.Graph.GraphRepresentation(3);
            var graph2 = new Part1.Graph.GraphRepresentation(3);

            graph1.AddEdge(0, 1);
            graph1.AddEdge(0, 2);
            graph2.AddEdge(0, 1);
            graph2.AddEdge(1, 2);

            // Act


            // Assert
            Assert.NotEqual(graph1, graph2);
        }

        [Fact]
        public void Equals_DifferentSize_DifferentGraphs()
        {
            // Arrange
            var graph1 = new Part1.Graph.GraphRepresentation(2);
            var graph2 = new Part1.Graph.GraphRepresentation(3);
            graph1.AddEdge(0, 1);
            graph2.AddEdge(0, 1);
            graph2.AddEdge(0, 2);

            // Act


            // Assert
            Assert.NotEqual(graph1, graph2);
        }
    }
}
