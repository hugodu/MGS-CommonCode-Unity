/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HelixCurve.cs
 *  Description  :  Define helix curve.
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
    /// Helix curve.
    /// </summary>
    public class HelixCurve : ICurve
    {
        #region Field and Property
        /// <summary>
        /// Top ellipse info of curve.
        /// </summary>
        public EllipseInfo topEllipse = new EllipseInfo();

        /// <summary>
        /// Bottom ellipse info of curve.
        /// </summary>
        public EllipseInfo bottomEllipse = new EllipseInfo();

        public float aroundRadian = 2 * Mathf.PI;

        public float MaxKey { get { return aroundRadian; } }
        #endregion

        #region Public Method
        public HelixCurve(EllipseInfo topEllipse, EllipseInfo bottomEllipse)
        {
            this.topEllipse = topEllipse;
            this.bottomEllipse = bottomEllipse;
        }

        public Vector3 GetPointAt(float radian)
        {
            return GetPointAt(topEllipse, bottomEllipse, MaxKey, radian);
        }
        #endregion

        #region Static Method
        /// <summary>
        /// Get point on ellipse at around radian.
        /// </summary>
        /// <param name="ellipse">Ellipse info of curve.</param>
        /// <param name="radian">Around radian of ellipse.</param>
        /// <returns>The point on ellipse at around radian.</returns>
        public static Vector3 GetPointAt(EllipseInfo topEllipse, EllipseInfo bottomEllipse, float MaxKey, float radian)
        {
            return Vector3.Lerp(EllipseCurve.GetPointAt(topEllipse, radian), EllipseCurve.GetPointAt(bottomEllipse, radian), radian / MaxKey);
        }
        #endregion
    }
}