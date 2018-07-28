/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  EllipseSineCurve.cs
 *  Description  :  Define ellipse sine curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/21/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Curve
{
    /// <summary>
    /// Ellipse sine curve.
    /// </summary>
    public class EllipseSineCurve : ICurve
    {
        #region Field and Property
        /// <summary>
        /// Ellipse info of curve.
        /// </summary>
        public EllipseInfo ellipse;

        /// <summary>
        /// Sine info of curve.
        /// </summary>
        public SineInfo sine;

        /// <summary>
        /// Length of curve.
        /// </summary>
        public float Length
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Max around radian of ellipse.
        /// </summary>
        public virtual float MaxKey { get; set; }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        public EllipseSineCurve()
        {
            ellipse = new EllipseInfo();
            sine = new SineInfo();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ellipse">Ellipse info of curve.</param>
        public EllipseSineCurve(EllipseInfo ellipse, SineInfo sine)
        {
            this.ellipse = ellipse;
            this.sine = sine;
        }

        /// <summary>
        /// Get point on ellipse at around radian.
        /// </summary>
        /// <param name="radian">Around radian of ellipse.</param>
        /// <returns>The point on ellipse at around radian.</returns>
        public virtual Vector3 GetPointAt(float radian)
        {
            return GetPointAt(ellipse, sine, radian);
        }
        #endregion

        #region Static Method
        /// <summary>
        /// Get point on ellipse at around radian.
        /// </summary>
        /// <param name="ellipse">Ellipse info of curve.</param>
        /// <param name="radian">Around radian of ellipse.</param>
        /// <returns>The point on ellipse at around radian.</returns>
        public static Vector3 GetPointAt(EllipseInfo ellipse, SineInfo sine, float radian)
        {
            var ellipsePos = ellipse.center + new Vector3(0, ellipse.semiMinorAxis * Mathf.Cos(radian), ellipse.semiMajorAxis * Mathf.Sin(radian));
            var sinPos = new Vector3(sine.amplitude * Mathf.Sin(sine.angular * radian + sine.phase) + sine.setover, 0);
            return ellipsePos + sinPos;
        }
        #endregion
    }
}