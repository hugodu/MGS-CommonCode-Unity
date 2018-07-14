/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HelixCurve.cs
 *  Description  :  Define helix curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/14/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Curve
{
    /// <summary>
    /// Helix curve.
    /// </summary>
    public class HelixCurve : ICurve
    {
        #region Field and Property
        public float MaxKey { get { return 0; } }
        #endregion

        #region Public Method
        public Vector3 GetPointAt(float key)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}