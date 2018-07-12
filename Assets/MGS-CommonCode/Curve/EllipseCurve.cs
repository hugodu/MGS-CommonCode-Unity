/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  EllipseCurve.cs
 *  Description  :  Define ellipse curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/13/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Curve
{
    /// <summary>
    /// Ellipse curve.
    /// </summary>
    public class EllipseCurve : ICurve
    {
        #region Field and Property
        /// <summary>
        /// Center of circle.
        /// </summary>
        public Vector3 center = Vector3.zero;

        /// <summary>
        /// Semi minor axis of ellipse.
        /// </summary>
        public float semiMinorAxis = 1.0f;

        /// <summary>
        /// Semi major axis of ellipse.
        /// </summary>
        public float semiMajorAxis = 2.0f;

        /// <summary>
        /// 
        /// </summary>
        public float MaxKey { get { return 2 * Mathf.PI; } }
        #endregion

        #region Public Method
        public EllipseCurve(Vector3 center, float semiMinorAxis, float semiMajorAxis)
        {
            this.center = center;
            this.semiMinorAxis = semiMinorAxis;
            this.semiMajorAxis = semiMajorAxis;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Vector3 GetPointAt(float key)
        {
            return center + new Vector3(semiMinorAxis * Mathf.Cos(key), 0, semiMajorAxis * Mathf.Sin(key));
        }
        #endregion
    }
}