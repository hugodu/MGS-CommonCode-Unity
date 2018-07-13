/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CircleHelixCurve.cs
 *  Description  :  Define circle helix curve.
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
    /// Circle helix curve.
    /// </summary>
    public class CircleHelixCurve : CircleCurve
    {
        #region Field and Property
        /// <summary>
        /// Around radian of helix.
        /// </summary>
        public float aroundRadian = 2 * Mathf.PI;

        /// <summary>
        /// Max around radian of helix.
        /// </summary>
        public override float MaxKey { get { return aroundRadian; } }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="center">Center of external circle.</param>
        /// <param name="radius">Radius of external circle.</param>
        /// <param name="aroundRadian">Around radian of helix.</param>
        public CircleHelixCurve(Vector3 center, float radius, float aroundRadian) : base(center, radius)
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
            return center + new Vector3(Mathf.Cos(radian), 0, Mathf.Sin(radian)) * radius * radian / MaxKey;
        }
        #endregion
    }
}