/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MeshUtility.cs
 *  Description  :  Utility for mesh.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/26/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace Mogoson.UMesh
{
    /// <summary>
    /// Utility for mesh.
    /// </summary>
    public static class MeshUtility
    {
        #region Public Method
        /// <summary>
        /// Create vertices base on polygon.
        /// </summary>
        /// <param name="edge">Edge count of polygon.</param>
        /// <param name="radius">Radius of polygon.</param>
        /// <param name="center">Center of polygon.</param>
        /// <param name="rotation">Rotation of polygon.</param>
        /// <returns>Vertices base on polygon.</returns>
        public static List<Vector3> CreateVerticesBasePolygon(int edge, float radius, Vector3 center, Quaternion rotation)
        {
            var vertices = new List<Vector3>();
            var sector = 2 * Mathf.PI / edge;
            var radian = 0f;
            for (int i = 0; i <= edge; i++)
            {
                radian = sector * i;
                vertices.Add(center + rotation * new Vector3(Mathf.Cos(radian), Mathf.Sin(radian)) * radius);
            }
            return vertices;
        }

        /// <summary>
        /// Create triangles index base on polygon and center vertice.
        /// </summary>
        /// <param name="edge">Edge count of polygon.</param>
        /// <param name="center">Index of center vertice.</param>
        /// <param name="start">Index of start vertice.</param>
        /// <returns>Triangles base on polygon.</returns>
        public static List<int> CreateTrianglesBasePolygon(int edge, int center, int start)
        {
            var triangles = new List<int>();
            for (int i = 0; i < edge; i++)
            {
                triangles.Add(i);
                triangles.Add(i + 1);
                triangles.Add(center);
            }
            return triangles;
        }

        /// <summary>
        /// Create triangles index base on prism.
        /// </summary>
        /// <param name="polygon">Edge count of prism polygon.</param>
        /// <param name="segment">Segment of prism vertical division.</param>
        /// <param name="start">Start index of prism vertice.</param>
        /// <returns>Triangles index base on prism.</returns>
        public static List<int> CreateTrianglesBasePrism(int polygon, int segment, int start)
        {
            var triangles = new List<int>();
            var vertices = polygon + 1;
            var currentStart = 0;
            var nextStart = 0;
            for (int s = 0; s < segment; s++)
            {
                // Calculate start index.
                currentStart = vertices * s;
                nextStart = vertices * (s + 1);
                for (int p = 0; p < polygon; p++)
                {
                    // Left-Bottom triangle.
                    triangles.Add(start + currentStart + p);
                    triangles.Add(start + currentStart + p + 1);
                    triangles.Add(start + nextStart + p + 1);

                    // Right-Top triangle.
                    triangles.Add(start + currentStart + p);
                    triangles.Add(start + nextStart + p + 1);
                    triangles.Add(start + nextStart + p);
                }
            }
            return triangles;
        }
        #endregion
    }
}