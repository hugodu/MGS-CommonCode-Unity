/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  EllipseHelixCurve.cs
 *  Description  :  Define ellipse helix curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/14/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Curve
{
    /// <summary>
    /// Ellipse helix curve.
    /// </summary>
    public class EllipseHelixCurve : EllipseCurve
    {
        #region Field and Property
        /// <summary>
        /// Around radian of helix.
        /// </summary>
        public float aroundRadian = 2 * Mathf.PI;

        /// <summary>
        /// Max around radian of ellipse.
        /// </summary>
        public override float MaxKey { get { return aroundRadian; } }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="center">Center of external ellipse.</param>
        /// <param name="semiMinorAxis">Semi minor axis of external ellipse.</param>
        /// <param name="semiMajorAxis">Semi major axis of external ellipse.</param>
        /// <param name="aroundRadian">Around radian of helix.</param>
        public EllipseHelixCurve(Vector3 center, float semiMinorAxis, float semiMajorAxis, float aroundRadian) : base(center, semiMinorAxis, semiMajorAxis)
        {
            this.aroundRadian = aroundRadian;
        }

        /// <summary>
        /// Get point on helix at around radian.
        /// </summary>
        /// <param name="radian">Around radian of helix.</param>
        /// <returns>The point on helix at around radian.</returns>
        public override Vector3 GetPointAt(float radian)
        {
            return center + new Vector3(semiMinorAxis * Mathf.Cos(radian), 0, semiMajorAxis * Mathf.Sin(radian)) * radian / MaxKey;
        }
        #endregion
    }
}