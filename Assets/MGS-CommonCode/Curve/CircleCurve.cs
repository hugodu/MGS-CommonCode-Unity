/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CircleCurve.cs
 *  Description  :  Define circle curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/13/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Curve
{
    /// <summary>
    /// Circle curve.
    /// </summary>
    public class CircleCurve : ICurve
    {
        #region Field and Property
        /// <summary>
        /// Center of circle.
        /// </summary>
        public Vector3 center = Vector3.zero;

        /// <summary>
        /// Radius of circle.
        /// </summary>
        public float radius = 1.0f;

        /// <summary>
        /// Max around radian of circle.
        /// </summary>
        public virtual float MaxKey { get { return 2 * Mathf.PI; } }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="center">Center of circle.</param>
        /// <param name="radius">Radius of circle.</param>
        public CircleCurve(Vector3 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        /// <summary>
        /// Get point on circle at around radian.
        /// </summary>
        /// <param name="radian">Around radian of circle.</param>
        /// <returns>The point on circle at around radian.</returns>
        public virtual Vector3 GetPointAt(float radian)
        {
            return center + new Vector3(Mathf.Cos(radian), 0, Mathf.Sin(radian)) * radius;
        }
        #endregion
    }
}