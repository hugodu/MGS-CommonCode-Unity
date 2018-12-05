﻿/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HermiteCurve.cs
 *  Description  :  Define piecewise three hermite spline curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/26/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;

namespace Mogoson.Mathematics
{
    /// <summary>
    /// Key frame base on time and value.
    /// </summary>
    [Serializable]
    public struct KeyFrame
    {
        #region Field and Property
        /// <summary>
        /// Time of key frame.
        /// </summary>
        public double time;

        /// <summary>
        /// Value of key frame.
        /// </summary>
        public double value;

        /// <summary>
        /// In tangent of key frame.
        /// </summary>
        public double inTangent;

        /// <summary>
        /// Out tangent of key frame.
        /// </summary>
        public double outTangent;
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="time">Time of key frame.</param>
        /// <param name="value">Value of key frame.</param>
        public KeyFrame(double time, double value)
        {
            this.time = time;
            this.value = value;
            inTangent = 0;
            outTangent = 0;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="time">Time of key frame.</param>
        /// <param name="value">Value of key frame.</param>
        /// <param name="inTangent">In tangent of key frame.</param>
        /// <param name="outTangent">Out tangent of key frame.</param>
        public KeyFrame(double time, double value, double inTangent, double outTangent)
        {
            this.time = time;
            this.value = value;
            this.inTangent = inTangent;
            this.outTangent = outTangent;
        }
        #endregion
    }

    /// <summary>
    /// Piecewise three hermite spline curve.
    /// </summary>
    public class HermiteCurve
    {
        #region Indexer
        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="index">Index of key frame.</param>
        /// <returns>The key frame at index.</returns>
        public KeyFrame this[int index]
        {
            get { return frames[index]; }
        }
        #endregion

        #region Field and Property
        /// <summary>
        /// Key frames of curve.
        /// </summary>
        protected List<KeyFrame> frames = new List<KeyFrame>();

        /// <summary>
        /// Count of key frames.
        /// </summary>
        public int KeyFramesCount { get { return frames.Count; } }
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        public HermiteCurve() { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="frames">Key frames of curve.</param>
        public HermiteCurve(KeyFrame[] frames)
        {
            this.frames.AddRange(frames);
        }

        /// <summary>
        /// Evaluate the value of hermite curve at time.
        /// </summary>
        /// <param name="t">Time of curve to evaluate value.</param>
        /// <returns>The value of hermite curve at time.</returns>
        public double Evaluate(double t)
        {
            return Evaluate(frames.ToArray(), t);
        }

        /// <summary>
        /// Add key frame to curve.
        /// </summary>
        /// <param name="time">Time of key frame.</param>
        /// <param name="value">Value of key frame.</param>
        public void AddKeyFrame(double time, double value)
        {
            frames.Add(new KeyFrame(time, value));
        }

        /// <summary>
        /// Add key frame to curve.
        /// </summary>
        /// <param name="keyFrame">Key frame to add.</param>
        public void AddKeyFrame(KeyFrame keyFrame)
        {
            frames.Add(keyFrame);
        }

        /// <summary>
        /// Remove key frame at index.
        /// </summary>
        /// <param name="index">Index of key frame.</param>
        public void RemoveKeyFrameAt(int index)
        {
            frames.RemoveAt(index);
        }
        #endregion

        #region Static Method
        /// <summary>
        /// Evaluate the value of hermite curve at time on the range from start key frame to end key frame.
        /// </summary>
        /// <param name="start">Start key frame of hermite curve.</param>
        /// <param name="end">End key frame of hermite curve.</param>
        /// <param name="t">Time of curve to evaluate value.</param>
        /// <returns>The value of hermite curve at time on the range from start key frame to end key frame.</returns>
        public static double Evaluate(KeyFrame start, KeyFrame end, double t)
        {
            return Hermite.Evaluate(start.time, end.time, start.value, end.value, start.outTangent, end.inTangent, t);
        }

        /// <summary>
        /// Evaluate the value of hermite curve at time.
        /// </summary>
        /// <param name="frames">Key frames of hermite curve.</param>
        /// <param name="t"></param>
        /// <returns>The value of hermite curve at time.</returns>
        public static double Evaluate(KeyFrame[] frames, double t)
        {
            if (frames == null || frames.Length == 0)
                return 0;
            else if (frames.Length == 1)
                return frames[0].value;
            else
            {
                if (t <= frames[0].time)
                {
                    return frames[0].value;
                }
                else if (t >= frames[frames.Length - 1].time)
                {
                    return frames[frames.Length - 1].value;
                }
                else
                {
                    var near = 0;
                    for (int i = 0; i < frames.Length; i++)
                    {
                        if (i == frames[i].time)
                            return frames[i].value;

                        if (t > frames[i].time && t < frames[i + 1].time)
                        {
                            near = i;
                            break;
                        }
                    }
                    return Evaluate(frames[near], frames[near + 1], t);
                }
            }
        }
        #endregion
    }
}