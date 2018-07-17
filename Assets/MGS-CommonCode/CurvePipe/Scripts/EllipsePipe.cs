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
                ellipse.semiMinorAxis = semiMinorAxis;
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
                ellipse.semiMajorAxis = semiMajorAxis;
            }
            get { return semiMajorAxis; }
        }

        /// <summary>
        /// Max around radian of curve.
        /// </summary>
        public override float MaxKey { get { return 2 * Mathf.PI; } }

        /// <summary>
        /// Circle info of path curve.
        /// </summary>
        protected EllipseInfo ellipse = new EllipseInfo();
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild path.
        /// </summary>
        public override void Rebuild()
        {
            ellipse.semiMinorAxis = semiMinorAxis;
            ellipse.semiMajorAxis = semiMajorAxis;
            base.Rebuild();
        }

        protected override Vector3 GetLocalPointAt(float time)
        {
            return EllipseCurve.GetPointAt(ellipse, time);
        }
        #endregion
    }
}