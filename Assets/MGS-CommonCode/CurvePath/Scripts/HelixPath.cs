/*************************************************************************
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
        /// Bottom ellipse info of curve.
        /// </summary>
        public EllipseInfo bottomEllipse = new EllipseInfo(Vector3.zero, 1.0f, 1.0f);

        /// <summary>
        /// Top ellipse info of curve.
        /// </summary>
        public EllipseInfo topEllipse = new EllipseInfo(Vector3.up, 1.0f, 1.0f);

        public float aroundRadian = 4 * Mathf.PI;

        public override float MaxKey { get { return aroundRadian; } }
        #endregion

        #region Public Method
        public override void Rebuild() { }

        public override Vector3 GetPointAt(float key)
        {
            return transform.TransformPoint(HelixCurve.GetPointAt(topEllipse, bottomEllipse, MaxKey, key));
        }
        #endregion
    }
}