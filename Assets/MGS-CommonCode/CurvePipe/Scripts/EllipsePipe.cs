/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  EllipsePipe.cs
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
    [AddComponentMenu("Mogoson/CurvePipe/EllipsePipe")]
    public class EllipsePipe : MonoCurvePipe
    {
        #region Field and Property
        /// <summary>
        /// Semi minor axis of ellipse.
        /// </summary>
        [SerializeField]
        protected float semiMinorAxis = 1.0f;

        /// <summary>
        /// Semi minor axis of ellipse.
        /// </summary>
        public float SemiMinorAxis
        {
            set
            {
                semiMinorAxis = value;
            }
            get { return semiMinorAxis; }
        }

        /// <summary>
        /// Semi major axis of ellipse.
        /// </summary>
        [SerializeField]
        protected float semiMajorAxis = 1.5f;

        /// <summary>
        /// Semi major axis of ellipse.
        /// </summary>
        public float SemiMajorAxis
        {
            set
            {
                semiMajorAxis = value;
            }
            get { return semiMajorAxis; }
        }

        /// <summary>
        /// Curve for path.
        /// </summary>
        protected override ICurve Curve { get { return curve; } }

        /// <summary>
        /// Curve of path.
        /// </summary>
        protected EllipseCurve curve = new EllipseCurve();
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild path.
        /// </summary>
        public override void Rebuild()
        {
            curve.ellipse.semiMinorAxis = semiMinorAxis;
            curve.ellipse.semiMajorAxis = semiMajorAxis;
            base.Rebuild();
        }
        #endregion
    }
}