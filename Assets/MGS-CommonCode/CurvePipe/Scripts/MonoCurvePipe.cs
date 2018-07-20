/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurvePipe.cs
 *  Description  :  Define MonoCurvePipe to render dynamic pipe mesh base
 *                  on center curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/20/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.Curve;
using Mogoson.Skin;
using System.Collections.Generic;
using UnityEngine;

namespace Mogoson.CurvePipe
{
    /// <summary>
    /// Render dynamic pipe mesh base on center curve.
    /// </summary>
    public abstract class MonoCurvePipe : MonoSkin, ICurvePipe
    {
        #region Field and Property
        /// <summary>
        /// Segment of around pipe.
        /// </summary>
        [SerializeField]
        protected int around = 8;

        /// <summary>
        /// Length of subdivide pipe.
        /// </summary>
        [SerializeField]
        protected float subdivide = 1;

        /// <summary>
        /// Radius of pipe mesh.
        /// </summary>
        [SerializeField]
        protected float radius = 0.1f;

        /// <summary>
        /// Is seal at both ends of pipe?
        /// </summary>
        [SerializeField]
        protected bool seal = false;

        /// <summary>
        /// Segment of around pipe.
        /// </summary>
        public int AroundSegment
        {
            set { around = value; }
            get { return around; }
        }

        /// <summary>
        ///  Length of subdivide pipe.
        /// </summary>
        public float SubdivideLength
        {
            set { subdivide = value; }
            get { return subdivide; }
        }

        /// <summary>
        /// Radius of pipe mesh.
        /// </summary>
        public float Radius
        {
            set { radius = value; }
            get { return radius; }
        }

        /// <summary>
        /// Is seal at both ends of pipe?
        /// </summary>
        public bool Seal
        {
            set { seal = value; }
            get { return seal; }
        }

        /// <summary>
        /// Max key of pipe center curve.
        /// </summary>
        public virtual float MaxKey { get { return Curve.MaxKey; } }

        /// <summary>
        /// Length of path center curve.
        /// </summary>
        public virtual float Length { get { return Curve.Length; } }

        /// <summary>
        /// Curve for path.
        /// </summary>
        protected abstract ICurve Curve { get; }

        /// <summary>
        /// Radian of circle.
        /// </summary>
        protected const float CircleRadian = Mathf.PI * 2;

        /// <summary>
        /// Delta to calculate tangent.
        /// </summary>
        protected const float Delta = 0.001f;

        protected int extend = 0;
        #endregion

        #region Protected Method
        /// <summary>
        /// Create the vertices of pipe mesh.
        /// </summary>
        /// <returns>Vertices of pipe mesh.</returns>
        protected override Vector3[] CreateVertices()
        {
            var vertices = new List<Vector3>();
            var space = MaxKey / extend;
            for (int i = 0; i < extend; i++)
            {
                var t = i * space;
                var center = Curve.GetPointAt(t);
                var tangent = (Curve.GetPointAt(t + Delta) - center).normalized;
                vertices.AddRange(CreateSegmentVertices(center, Quaternion.LookRotation(tangent)));
            }

            var lastCenter = Curve.GetPointAt(MaxKey);
            var lastTangent = (lastCenter - Curve.GetPointAt(MaxKey - Delta)).normalized;
            vertices.AddRange(CreateSegmentVertices(lastCenter, Quaternion.LookRotation(lastTangent)));

            if (seal && around > 2)
            {
                vertices.Add(Curve.GetPointAt(0));
                vertices.Add(Curve.GetPointAt(MaxKey));
            }
            return vertices.ToArray();
        }

        /// <summary>
        /// Create triangles of pipe mesh.
        /// </summary>
        /// <returns>Triangles array.</returns>
        protected override int[] CreateTriangles()
        {
            var triangles = new List<int>();
            for (int i = 0; i < extend; i++)
            {
                for (int j = 0; j < around - 1; j++)
                {
                    triangles.Add(around * i + j);
                    triangles.Add(around * i + j + 1);
                    triangles.Add(around * (i + 1) + j + 1);

                    triangles.Add(around * i + j);
                    triangles.Add(around * (i + 1) + j + 1);
                    triangles.Add(around * (i + 1) + j);
                }

                triangles.Add(around * i);
                triangles.Add(around * (i + 1));
                triangles.Add(around * (i + 2) - 1);

                triangles.Add(around * i);
                triangles.Add(around * (i + 2) - 1);
                triangles.Add(around * (i + 1) - 1);
            }

            if (seal && around > 2)
            {
                for (int i = 0; i < around - 1; i++)
                {
                    triangles.Add(around * (extend + 1));
                    triangles.Add(i + 1);
                    triangles.Add(i);

                    triangles.Add(around * (extend + 1) + 1);
                    triangles.Add(around * extend + i);
                    triangles.Add(around * extend + i + 1);
                }

                triangles.Add(around * (extend + 1));
                triangles.Add(0);
                triangles.Add(around - 1);

                triangles.Add(around * (extend + 1) + 1);
                triangles.Add(around * (extend + 1) - 1);
                triangles.Add(around * extend);
            }
            return triangles.ToArray();
        }

        /// <summary>
        /// Create vertices of current segment base pipe.
        /// </summary>
        /// <param name="center">Center point of segment.</param>
        /// <param name="rotation">Rotation of segment vertices.</param>
        /// <returns>Segment vertices.</returns>
        protected virtual Vector3[] CreateSegmentVertices(Vector3 center, Quaternion rotation)
        {
            var vertices = new Vector3[around];
            for (int i = 0; i < around; i++)
            {
                var angle = CircleRadian / around * i;
                var vertice = center + rotation * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
                vertices[i] = vertice;
            }
            return vertices;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild the mesh of pipe.
        /// </summary>
        public override void Rebuild()
        {
            extend = (int)(Length / subdivide);
            base.Rebuild();
        }

        /// <summary>
        /// Get point from center curve of pipe at key.
        /// </summary>
        /// <param name="key">Key of pipe center curve.</param>
        /// <returns>Point on pipe curve at key.</returns>
        public Vector3 GetPointAt(float key)
        {
            return transform.TransformPoint(Curve.GetPointAt(key));
        }
        #endregion
    }
}