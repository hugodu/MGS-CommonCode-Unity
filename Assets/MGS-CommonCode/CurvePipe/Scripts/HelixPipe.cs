/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HelixPipe.cs
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
    [AddComponentMenu("Mogoson/CurvePipe/HelixPipe")]
    public class HelixPipe : MonoCurvePipe
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
        /// Max around radian of curve.
        /// </summary>
        public override float MaxKey { get { return maxRadian; } }
        #endregion

        #region Public Method
        protected override Vector3 GetLocalPointAt(float time)
        {
            return HelixCurve.GetPointAt(topEllipse, bottomEllipse, MaxKey, time);
        }
        #endregion
    }
}