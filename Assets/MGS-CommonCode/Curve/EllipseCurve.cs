/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  EllipseCurve.cs
 *  Description  :  Define ellipse curve.
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
    /// Ellipse curve.
    /// </summary>
    public class EllipseCurve : ICurve
    {
        #region Field and Property
        /// <summary>
        /// Center of ellipse.
        /// </summary>
        public Vector3 center = Vector3.zero;

        /// <summary>
        /// Semi minor axis of ellipse.
        /// </summary>
        public float semiMinorAxis = 1.0f;

        /// <summary>
        /// Semi major axis of ellipse.
        /// </summary>
        public float semiMajorAxis = 2.0f;

        /// <summary>
        /// Max around radian of ellipse.
        /// </summary>
        public virtual float MaxKey { get { return 2 * Mathf.PI; } }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="center">Center of ellipse.</param>
        /// <param name="semiMinorAxis">Semi minor axis of ellipse.</param>
        /// <param name="semiMajorAxis">Semi major axis of ellipse.</param>
        public EllipseCurve(Vector3 center, float semiMinorAxis, float semiMajorAxis)
        {
            this.center = center;
            this.semiMinorAxis = semiMinorAxis;
            this.semiMajorAxis = semiMajorAxis;
        }

        /// <summary>
        /// Get point on ellipse at around radian.
        /// </summary>
        /// <param name="radian">Around radian of ellipse.</param>
        /// <returns>The point on ellipse at around radian.</returns>
        public virtual Vector3 GetPointAt(float radian)
        {
            return center + new Vector3(semiMinorAxis * Mathf.Cos(radian), 0, semiMajorAxis * Mathf.Sin(radian));
        }
        #endregion
    }
}