/*************************************************************************
 *  Copyright © 2015-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GameObjectExtention.cs
 *  Description  :  Extention for UnityEngine.GameObject.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2015/09/03
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.Extention
{
    /// <summary>
	/// Extention for UnityEngine.GameObject.
	/// </summary>
	public static class EGameObject
    {
        #region Public Static Method
        /// <summary>
        /// Set layer include it's children.
        /// </summary>
        public static void BroadcastLayer(this GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
            foreach (Transform trans in gameObject.transform)
            {
                BroadcastLayer(trans.gameObject, layer);
            }
        }
        #endregion
    }
}