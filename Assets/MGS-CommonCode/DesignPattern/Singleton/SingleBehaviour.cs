﻿/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SingleBehaviour.cs
 *  Description  :  Define the base of single MonoBehaviour.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/12/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.IO;
using UnityEngine;

namespace Mogoson.DesignPattern
{
    /// <summary>
    /// MonoBehaviour with a single instance.
    /// </summary>
    /// <typeparam name="T">Specified type.</typeparam>
    [DisallowMultipleComponent]
    public abstract class SingleBehaviour<T> : MonoBehaviour where T : SingleBehaviour<T>
    {
        #region Field and Property
        /// <summary>
        /// Sync root of single behaviour.
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// Instance of this MonoBehaviour.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        //Active MonoBehaviour in scene.
                        instance = FindObjectOfType<T>();
                        if (instance == null)
                        {
                            //Create agent to attach MonoBehaviour.
                            instance = new GameObject(typeof(T).Name).AddComponent<T>();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Instance of this MonoBehaviour.
        /// </summary>
        private static T instance = null;
        #endregion

        #region Protected Method
        protected void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
            }
            else
            {
                if (instance != this)
                {
                    Destroy(this);
                    LogUtility.LogWarning("Destroy the redundant instance of {0} component form {1}: " +
                        "Multi instances of {0} component in a scene is violat singleton design.", typeof(T).Name, name);
                    return;
                }
            }
            SingleAwake();
        }

        protected virtual void SingleAwake() { }
        #endregion
    }
}