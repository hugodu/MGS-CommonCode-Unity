/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CirclePipe.cs
 *  Description  :  Render dynamic pipe mesh base on circle curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/18/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.Curve;
using UnityEngine;

namespace Mogoson.CurvePipe
{
    /// <summary>
    /// Render dynamic pipe mesh base on circle curve.
    /// </summary>
    [AddComponentMenu("Mogoson/CurvePipe/CirclePipe")]
    public class CirclePipe : MonoCurvePipe
    {
        #region Field and Property
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
            circle.semiMinorAxis = circle.semiMajorAxis = radius+2;
            base.Rebuild();
        }

        protected override Vector3 GetLocalPointAt(float time)
        {
            return EllipseCurve.GetPointAt(circle, time);
        }
        #endregion
    }
}