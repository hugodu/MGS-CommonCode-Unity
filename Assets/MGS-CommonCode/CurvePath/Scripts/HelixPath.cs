﻿/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HelixPath.cs
 *  Description  :  Define path base on helix curve.
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
    /// Path base on helix curve.
    /// </summary>
    [AddComponentMenu("Mogoson/CurvePath/HelixPath")]
    public class HelixPath : MonoCurvePath
    {
        #region Field and Property
        /// <summary>
        /// Top ellipse info of curve.
        /// </summary>
        public EllipseInfo topEllipse = new EllipseInfo(Vector3.up, 1.0f, 1.0f);

        /// <summary>
        /// Bottom ellipse info of curve.
        /// </summary>
        public EllipseInfo bottomEllipse = new EllipseInfo(Vector3.zero, 1.0f, 1.0f);

        /// <summary>
        /// Max around radian of helix.
        /// </summary>
        public float maxRadian = 6 * Mathf.PI;

        /// <summary>
        /// Curve for path.
        /// </summary>
        protected override ICurve Curve { get { return curve; } }

        /// <summary>
        /// Curve of path.
        /// </summary>
        protected HelixCurve curve = new HelixCurve();
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild path.
        /// </summary>
        public override void Rebuild()
        {
            curve.topEllipse = topEllipse;
            curve.bottomEllipse = bottomEllipse;
        }

        /// <summary>
        /// Get point on path curve at radian.
        /// </summary>
        /// <param name="radian">Radian of curve.</param>
        /// <returns>The point on path curve at radian.</returns>
        public override Vector3 GetPointAt(float radian)
        {
            return transform.TransformPoint(curve.GetPointAt(radian));
        }
        #endregion
    }
}