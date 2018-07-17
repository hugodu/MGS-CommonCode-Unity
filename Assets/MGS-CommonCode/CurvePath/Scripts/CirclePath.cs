/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CirclePath.cs
 *  Description  :  Define path base on circle curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/17/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.Curve;
using UnityEngine;

namespace Mogoson.CurvePath
{
    /// <summary>
    /// Path base on circle curve.
    /// </summary>
    [AddComponentMenu("Mogoson/CurvePath/CirclePath")]
    public class CirclePath : MonoCurvePath
    {
        #region Field and Property
        /// <summary>
        /// Radius of circle curve.
        /// </summary>
        [SerializeField]
        protected float radius = 1.0f;

        /// <summary>
        /// Radius of circle curve.
        /// </summary>
        public float Radius
        {
            set
            {
                radius = value;
                circle.semiMinorAxis = circle.semiMajorAxis = radius;
            }
            get { return radius; }
        }

        /// <summary>
        /// Max around radian of curve.
        /// </summary>
        public override float MaxKey { get { return 2 * Mathf.PI; } }

        /// <summary>
        /// Circle info of path curve.
        /// </summary>
        protected EllipseInfo circle = new EllipseInfo();
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild path.
        /// </summary>
        public override void Rebuild()
        {
            circle.semiMinorAxis = circle.semiMajorAxis = radius;
        }

        /// <summary>
        /// Get point on path curve at radian.
        /// </summary>
        /// <param name="radian">Radian of curve.</param>
        /// <returns>The point on path curve at radian.</returns>
        public override Vector3 GetPointAt(float radian)
        {
            return transform.TransformPoint(EllipseCurve.GetPointAt(circle, radian));
        }
        #endregion
    }
}