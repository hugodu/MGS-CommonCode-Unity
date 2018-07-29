/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SinePath.cs
 *  Description  :  Define path base on sine curve.
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
    /// Path base on sine curve.
    /// </summary>
    [AddComponentMenu("Mogoson/CurvePath/SinePath")]
    public class SinePath : MonoCurvePath
    {
        #region Field and Property
        public SinArgs sine = new SinArgs(1, 1, 0, 0);

        public float maxKey = 1;

        /// <summary>
        /// Curve for path.
        /// </summary>
        protected override ICurve Curve { get { return curve; } }

        /// <summary>
        /// Curve of path.
        /// </summary>
        protected USinCurve curve = new USinCurve();
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild path.
        /// </summary>
        public override void Rebuild()
        {
            curve.args = sine;
            curve.MaxKey = maxKey;
        }
        #endregion
    }
}