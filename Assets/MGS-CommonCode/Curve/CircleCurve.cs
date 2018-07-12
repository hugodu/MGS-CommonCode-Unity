/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CircleCurve.cs
 *  Description  :  Define circle curve.
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
    /// Circle curve.
    /// </summary>
    public class CircleCurve : ICurve
    {
        #region Field and Property
        /// <summary>
        /// Center of circle.
        /// </summary>
        public Vector3 center = Vector3.zero;

        /// <summary>
        /// Radius of circle.
        /// </summary>
        public float radius = 1.0f;

        /// <summary>
        /// 
        /// </summary>
        public float MaxKey { get { return 2 * Mathf.PI; } }
        #endregion

        #region Public Method
        public CircleCurve(Vector3 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Vector3 GetPointAt(float key)
        {
            return center + new Vector3(Mathf.Cos(key), 0, Mathf.Sin(key)) * radius;
        }
        #endregion
    }
}