/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  EllipsePath.cs
 *  Description  :  Define path base on ellipse curve.
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
    /// Path base on ellipse curve.
    /// </summary>
    [AddComponentMenu("Mogoson/CurvePath/EllipsePath")]
    public class EllipsePath : MonoCurvePath
    {
        #region Field and Property
        /// <summary>
        /// Ellipse info of path curve.
        /// </summary>
        public EllipseInfo ellipse = new EllipseInfo(Vector3.zero, 1.0f, 1.0f);

        /// <summary>
        /// Max key of path curve.
        /// </summary>
        public override float MaxKey { get { return 2 * Mathf.PI; } }
        #endregion

        #region Public Method
        public override void Rebuild() { }

        /// <summary>
        /// Get point on path curve at radian.
        /// </summary>
        /// <param name="radian">Radian of curve.</param>
        /// <returns>The point on path curve at radian.</returns>
        public override Vector3 GetPointAt(float radian)
        {
            return transform.TransformPoint(EllipseCurve.GetPointAt(ellipse, radian));
        }
        #endregion
    }
}