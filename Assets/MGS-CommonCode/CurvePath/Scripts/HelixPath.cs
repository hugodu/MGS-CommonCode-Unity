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
        [SerializeField]
        protected float maxRadian = 6 * Mathf.PI;

        /// <summary>
        /// Max around radian of helix.
        /// </summary>
        public float MaxRadian
        {
            set { maxRadian = value; }
            get { return maxRadian; }
        }

        /// <summary>
        /// Max around radian of helix.
        /// </summary>
        public override float MaxKey { get { return maxRadian; } }
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
            return transform.TransformPoint(HelixCurve.GetPointAt(topEllipse, bottomEllipse, MaxKey, radian));
        }
        #endregion
    }
}