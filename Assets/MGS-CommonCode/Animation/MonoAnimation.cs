﻿/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoAnimation.cs
 *  Description  :  Define mono animation.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  6/23/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.UAnimation
{
    /// <summary>
    /// Mono animation.
    /// </summary>
    public abstract class MonoAnimation : MonoBehaviour, IAnimation
    {
        #region Field and Property
        /// <summary>
        /// Speed of animation.
        /// </summary>
        [SerializeField]
        protected float speed = 5;

        /// <summary>
        /// Loop mode of animation.
        /// </summary>
        [SerializeField]
        protected LoopMode loop = LoopMode.Once;

        /// <summary>
        /// Speed of animation.
        /// </summary>
        public virtual float Speed
        {
            set { speed = value; }
            get { return speed; }
        }

        /// <summary>
        /// Loop mode of animation.
        /// </summary>
        public virtual LoopMode LoopMode
        {
            set { loop = value; }
            get { return loop; }
        }

        /// <summary>
        /// Animation is playing?
        /// </summary>
        public virtual bool IsPlaying
        {
            protected set;
            get;
        }
        #endregion

        #region Protected Method
        protected virtual void Awake()
        {
            Init();
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Init animation.
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// Play animation.
        /// </summary>
        public abstract void Play();

        /// <summary>
        /// Play animation.
        /// </summary>
        /// <param name="animation">Animation data.</param>
        public virtual void Play(object animation)
        {
            Refresh(animation);
            Play();
        }

        /// <summary>
        /// Refresh animation.
        /// </summary>
        /// <param name="animation">Animation data.</param>
        public abstract void Refresh(object animation);

        /// <summary>
        /// Pause animation.
        /// </summary>
        public abstract void Pause();

        /// <summary>
        /// Rewind animation.
        /// </summary>
        /// <param name="progress">Progress of animation in the range[0~1]</param>
        public abstract void Rewind(float progress);

        /// <summary>
        /// Stop animation.
        /// </summary>
        public abstract void Stop();
        #endregion
    }
}