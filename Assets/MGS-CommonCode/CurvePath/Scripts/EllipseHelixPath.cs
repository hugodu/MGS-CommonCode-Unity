/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  EllipseHelixPath.cs
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
    [AddComponentMenu("Mogoson/CurvePath/EllipseHelixPath")]
    public class EllipseHelixPath : EllipsePath
    {
        #region Field and Property
        /// <summary>
        /// 
        /// </summary>
        public override float MaxKey { get { return curve.MaxKey; } }
        
        /// <summary>
        /// 
        /// </summary>
        protected new EllipseHelixCurve curve  = new EllipseHelixCurve(Vector3.zero, 1.0f, 2.0f, 12*Mathf.PI);
        #endregion

        #region Public Method
        public override void Rebuild() { }

        /// <summary>
        /// Get point on path curve at time.
        /// </summary>
        /// <param name="time">Time of curve.</param>
        /// <returns>The point on path curve at time.</returns>
        public override Vector3 GetPointAt(float time)
        {
            return transform.TransformPoint(curve.GetPointAt(time));
        }
        #endregion
    }
}