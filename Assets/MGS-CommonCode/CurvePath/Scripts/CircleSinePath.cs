/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CircleSinePath.cs
 *  Description  :  Define path base on circle and sine curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/21/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.Curve;
using Mogoson.Mathematics;
using UnityEngine;

namespace Mogoson.CurvePath
{
    /// <summary>
    /// Path base on circle and sine curve.
    /// </summary>
    [AddComponentMenu("Mogoson/CurvePath/CircleSinePath")]
    public class CircleSinePath : MonoCurvePath
    {
        #region Field and Property
        /// <summary>
        /// Radius of circle curve.
        /// </summary>
        public float radius = 1.0f;

        public SinArgs sine = new SinArgs(1, 1, 0, 0);

        public float maxKey = Mathf.PI * 2;

        /// <summary>
        /// Curve for path.
        /// </summary>
        protected override ICurve Curve { get { return curve; } }

        /// <summary>
        /// Curve of path.
        /// </summary>
        protected EllipseSineCurve curve = new EllipseSineCurve();
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild path.
        /// </summary>
        public override void Rebuild()
        {
            curve.ellipse.semiMinorAxis = curve.ellipse.semiMajorAxis = radius;
            curve.sine = sine;
            curve.MaxKey = maxKey;
        }
        #endregion
    }
}