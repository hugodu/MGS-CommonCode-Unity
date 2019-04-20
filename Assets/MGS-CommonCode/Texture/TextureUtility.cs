/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TextureUtility.cs
 *  Description  :  Utility for texture.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/19/2019
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.DesignPattern;
using Mogoson.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using UnityEngine;

namespace Mogoson.UTexture
{
    /// <summary>
    /// Utility for texture.
    /// </summary>
    public static class TextureUtility
    {
        #region Public Method
        /// <summary>
        /// Convert gif image to frames textures.
        /// </summary>
        /// <param name="filePath">Path of gif file.</param>
        /// <param name="onLoaded">On loaded callback.</param>
        public static void GifToFrames(string filePath, Action<List<Texture2D>> onLoaded)
        {
            if (onLoaded == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                LogUtility.LogError("[TextureUtility] GifToFrames error: file path can not be null.");
                onLoaded.Invoke(null);
                return;
            }

            if (!File.Exists(filePath))
            {
                LogUtility.LogError("[TextureUtility] GifToFrames error: can not find the file {0}.", filePath);
                onLoaded.Invoke(null);
                return;
            }

            Image gif = null;
            try
            {
                gif = Image.FromFile(filePath);
                SingleBehaviour.Instance.StartCoroutine(GifToFrames(gif, onLoaded));
            }
            catch (Exception ex)
            {
                LogUtility.LogError("[TextureUtility] GifToFrames error: {0}.", ex.Message);
                onLoaded.Invoke(null);
                return;
            }
        }

        /// <summary>
        /// Convert gif image to frames textures.
        /// </summary>
        /// <param name="gif">Gif image.</param>
        /// <param name="onLoaded">On loaded callback.</param>
        /// <returns>IEnumerator.</returns>
        public static IEnumerator GifToFrames(Image gif, Action<List<Texture2D>> onLoaded)
        {
            if (onLoaded == null)
            {
                yield break;
            }

            var dimension = new FrameDimension(gif.FrameDimensionsList[0]);
            var framesCount = gif.GetFrameCount(dimension);

            var frames = new List<Texture2D>();
            for (int i = 0; i < framesCount; i++)
            {
                var bitmap = new Bitmap(gif.Width, gif.Height);
                var graphics = System.Drawing.Graphics.FromImage(bitmap);

                gif.SelectActiveFrame(dimension, i);
                graphics.DrawImage(gif, Point.Empty);

                var frame = new Texture2D(bitmap.Width, bitmap.Height);
                frame.LoadImage(BitmapToBytes(bitmap));

                frame.Apply();
                frames.Add(frame);
                yield return null;
            }
            onLoaded.Invoke(frames);
        }

        /// <summary>
        /// Convert bitmap to bytes data.
        /// </summary>
        /// <param name="bitmap">Bitmap to convert.</param>
        /// <returns>Bytes data of bitmap.</returns>
        public static byte[] BitmapToBytes(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                return null;
            }

            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                return stream.GetBuffer();
            }
        }
        #endregion
    }
}