/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HelixCurve.cs
 *  Description  :  Define path base on helix curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/14/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.Curve;
using UnityEngine;

namespace Mogoson.CurvePath
{
    /// <summary>
    /// Path base on helix curve.
    /// </summary>
    [AddComponentMenu("Mogoson/CurvePath/HelixCurve")]
    public class HelixCurve : MonoCurvePath
    {
        #region Field and Property
        public override float MaxKey { get { return 0; } }
        #endregion

        #region Public Method
        public override void Rebuild()
        {
            throw new System.NotImplementedException();
        }

        public override Vector3 GetPointAt(float key)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}