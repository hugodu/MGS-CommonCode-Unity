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

        /// <summary>
        /// Max around radian of helix.
        /// </summary>
        public float MaxKey { set; get; }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="topEllipse">Top ellipse info of curve.</param>
        /// <param name="bottomEllipse">Bottom ellipse info of curve.</param>
        public HelixCurve(EllipseInfo topEllipse, EllipseInfo bottomEllipse)
        {
            this.topEllipse = topEllipse;
            this.bottomEllipse = bottomEllipse;
        }

        /// <summary>
        /// Get point on helix at around radian.
        /// </summary>
        /// <param name="radian">Around radian of helix.</param>
        /// <returns>The point on helix at around radian.</returns>
        public Vector3 GetPointAt(float radian)
        {
            return GetPointAt(topEllipse, bottomEllipse, MaxKey, radian);
        }
        #endregion

        #region Static Method
        /// <summary>
        /// Get point on helix at around radian.
        /// </summary>
        /// <param name="topEllipse">Top ellipse info of curve.</param>
        /// <param name="bottomEllipse">Bottom ellipse info of curve.</param>
        /// <param name="maxRadian">Max around radian of helix.</param>
        /// <param name="radian">Around radian of helix.</param>
        /// <returns>The point on helix at around radian.</returns>
        public static Vector3 GetPointAt(EllipseInfo topEllipse, EllipseInfo bottomEllipse, float maxRadian, float radian)
        {
            if (maxRadian == 0)
                maxRadian = Mathf.Epsilon;

            return Vector3.Lerp(EllipseCurve.GetPointAt(topEllipse, radian), EllipseCurve.GetPointAt(bottomEllipse, radian), radian / maxRadian);
        }
        #endregion
    }
}