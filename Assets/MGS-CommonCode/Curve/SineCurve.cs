/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SineCurve.cs
 *  Description  :  Define sine curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/21/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace Mogoson.Curve
{
    /// <summary>
    /// Info of sine curve.
    /// </summary>
    [Serializable]
    public struct SineInfo
    {
        #region Field and Property
        /// <summary>
        /// Amplitude of sine curve.
        /// </summary>
        public float amplitude;

        /// <summary>
        /// Angular of sine curve.
        /// </summary>
        public float angular;

        /// <summary>
        /// Initial phase of sine curve.
        /// </summary>
        public float phase;

        /// <summary>
        /// Setover of sine curve.
        /// </summary>
        public float setover;
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="amplitude">Amplitude of sine curve.</param>
        /// <param name="angular">Angular of sine curve.</param>
        /// <param name="phase">Initial phase of sine curve.</param>
        /// <param name="setover">Setover of sine curve.</param>
        public SineInfo(float amplitude, float angular, float phase, float setover)
        {
            this.amplitude = amplitude;
            this.angular = angular;
            this.phase = phase;
            this.setover = setover;
        }
        #endregion
    }

    /// <summary>
    ///  Sine curve.
    /// </summary>
    public class SineCurve : ICurve
    {
        #region Field and Property
        /// <summary>
        /// Sine info of curve.
        /// </summary>
        public SineInfo sine;

        /// <summary>
        /// Length of curve.
        /// </summary>
        public float Length { get { return 1; } }

        /// <summary>
        /// Max radian of sine.
        /// </summary>
        public virtual float MaxKey { set; get; }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        public SineCurve()
        {
            sine = new SineInfo();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sine">Sine info of curve.</param>
        public SineCurve(SineInfo sine)
        {
            this.sine = sine;
        }

        /// <summary>
        /// Get point on ellipse at around radian.
        /// </summary>
        /// <param name="radian">Around radian of ellipse.</param>
        /// <returns>The point on ellipse at around radian.</returns>
        public virtual Vector3 GetPointAt(float radian)
        {
            return GetPointAt(sine, radian);
        }
        #endregion

        #region Static Method
        /// <summary>
        /// Get point on ellipse at around radian.
        /// </summary>
        /// <param name="sine">Ellipse info of curve.</param>
        /// <param name="radian">Around radian of ellipse.</param>
        /// <returns>The point on ellipse at around radian.</returns>
        public static Vector3 GetPointAt(SineInfo sine, float radian)
        {
            return new Vector3(radian, sine.amplitude * Mathf.Sin(sine.angular * radian + sine.phase) + sine.setover);
        }
        #endregion
    }
}