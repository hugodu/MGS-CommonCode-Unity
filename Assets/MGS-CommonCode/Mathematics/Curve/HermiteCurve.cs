/*************************************************************************
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
        /*  Hermite Polynomial Structure
         *  Base: H(t) = v0a0(t) + v1a1(t) + m0b0(t) + m1b1(t)
         * 
         *                     t-t0    t-t1  2
         *        a0(t) = (1+2------)(------)
         *                     t1-t0   t0-t1
         *                    
         *                     t-t1    t-t0  2
         *        a1(t) = (1+2------)(------)
         *                     t0-t1   t1-t0
         * 
         *                        t-t1  2
         *        b0(t) = (t-t0)(------)
         *                        t0-t1
         * 
         *                        t-t0  2
         *        b1(t) = (t-t1)(------)
         *                        t1-t0
         * 
         *  Let:  d0 = t-t0, d1 = t-t1, d = t0-t1
         * 
         *              d0          d1
         *        q0 = ---- , q1 = ----
         *              d           d
         * 
         *               t-t1  2     d1  2     2          t-t0  2     d0  2     2
         *        p0 = (------)  = (----)  = q1  , p1 = (------)  = (----)  = q0
         *               t0-t1       d                    t1-t0       -d
         * 
         *  Get:  H(t) = (1-2q0)v0p0 + (1+2q1)v1p1 + mod0p0 + m1d1p1
         */

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

        #region Protected Method
        /// <summary>
        /// Evaluate the value of hermite curve at time.
        /// </summary>
        /// <param name="t0">Time of start key frame.</param>
        /// <param name="t1">Time of end key frame.</param>
        /// <param name="v0">Value of start key frame.</param>
        /// <param name="v1">Value of end key frame.</param>
        /// <param name="m0">Micro quotient value of start key frame.</param>
        /// <param name="m1">Micro quotient value of end key frame.</param>
        /// <param name="t">Time of curve to evaluate value.</param>
        /// <returns>The value of hermite curve at time.</returns>
        protected double Evaluate(double t0, double t1, double v0, double v1, double m0, double m1, double t)
        {
            var d0 = t - t0;
            var d1 = t - t1;
            var d = t0 - t1;

            var q0 = d0 / d;
            var q1 = d1 / d;

            var p0 = q1 * q1;
            var p1 = q0 * q0;

            return (1 - 2 * q0) * v0 * p0 + (1 + 2 * q1) * v1 * p1 + m0 * d0 * p0 + m1 * d1 * p1;
        }

        /// <summary>
        /// Evaluate the value of hermite curve at time on the range from start key frame to end key frame.
        /// </summary>
        /// <param name="start">Start key frame of hermite curve.</param>
        /// <param name="end">End key frame of hermite curve.</param>
        /// <param name="t">Time of curve to evaluate value.</param>
        /// <returns>The value of hermite curve at time on the range from start key frame to end key frame.</returns>
        protected double Evaluate(KeyFrame start, KeyFrame end, double t)
        {
            return Evaluate(start.time, end.time, start.value, end.value, start.outTangent, end.inTangent, t);
        }
        #endregion

        #region Public Method
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
            if (frames.Count == 0)
                return 0;
            else if (frames.Count == 1)
                return frames[0].value;
            else
            {
                if (t <= frames[0].time)
                {
                    return frames[0].value;
                }
                else if (t >= frames[frames.Count - 1].time)
                {
                    return frames[frames.Count - 1].value;
                }
                else
                {
                    var near = 0;
                    for (int i = 0; i < frames.Count; i++)
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
    }
}