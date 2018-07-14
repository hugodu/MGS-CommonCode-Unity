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
        /// Semi Minor Axis of ellipse.
        /// </summary>
        [SerializeField]
        protected float semiMinorAxis = 1.0f;

        /// <summary>
        /// Semi Major Axis of ellipse.
        /// </summary>
        [SerializeField]
        protected float semiMajorAxis = 2.0f;

        /// <summary>
        /// Max key of path curve.
        /// </summary>
        public override float MaxKey { get { return curve.MaxKey; } }

        /// <summary>
        /// 
        /// </summary>
        public float SemiMinorAxis
        {
            set { curve.semiMinorAxis = semiMinorAxis = value; }
            get { return semiMinorAxis; }
        }

        /// <summary>
        /// 
        /// </summary>
        public float SemiMajorAxis
        {
            set { curve.semiMajorAxis = semiMajorAxis = value; }
            get { return semiMajorAxis; }
        }

        /// <summary>
        /// Curve of path.
        /// </summary>
        protected EllipseCurve curve = new EllipseCurve(Vector3.zero, 1.0f, 2.0f);
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild path.
        /// </summary>
        public override void Rebuild()
        {
            curve = new EllipseCurve(Vector3.zero, semiMinorAxis, semiMajorAxis);
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