/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CirclePath.cs
 *  Description  :  Define path base on circle curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/14/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.Curve;
using UnityEngine;

namespace Mogoson.CurvePath
{
    /// <summary>
    /// Path base on circle curve.
    /// </summary>
    [AddComponentMenu("Mogoson/CurvePath/CirclePath")]
    public class CirclePath : MonoCurvePath
    {
        #region Field and Property
        /// <summary>
        /// Radius of circle.
        /// </summary>
        [SerializeField]
        protected float radius = 1.0f;

        /// <summary>
        /// Max key of path curve.
        /// </summary>
        public override float MaxKey { get { return curve.MaxKey; } }

        /// <summary>
        /// Radius of circle.
        /// </summary>
        public float Radius
        {
            set { curve.semiMinorAxis = curve.semiMajorAxis = radius = value; }
            get { return radius; }
        }

        /// <summary>
        /// Curve of path.
        /// </summary>
        protected EllipseCurve curve = new EllipseCurve(Vector3.zero, 1.0f, 1.0f);
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild path.
        /// </summary>
        public override void Rebuild()
        {
            curve = new EllipseCurve(Vector3.zero, radius, radius);
        }

        /// <summary>
        /// Get point on path curve at radian.
        /// </summary>
        /// <param name="radian">Radian of circle curve.</param>
        /// <returns>The point on path curve at radian.</returns>
        public override Vector3 GetPointAt(float radian)
        {
            return transform.TransformPoint(curve.GetPointAt(radian));
        }
        #endregion
    }
}