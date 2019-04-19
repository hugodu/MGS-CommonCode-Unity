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

using Mogoson.IO;
using System;
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
        /// <returns></returns>
        public static List<Texture2D> GifToFrames(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            if (!File.Exists(filePath))
            {
                LogUtility.LogError("[TextureUtility] GifToFrames error: can not find the file {0}.", filePath);
                return null;
            }

            try
            {
                var gif = Image.FromFile(filePath);
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
                    for (int u = 0; u < bitmap.Width; u++)
                    {
                        for (int v = 0; v < bitmap.Height; v++)
                        {
                            var color = bitmap.GetPixel(u, v);
                            var newColor = new Color32(color.R, color.G, color.B, color.A);
                            frame.SetPixel(u, bitmap.Height - (v + 1), newColor);
                        }
                    }
                    frame.Apply();
                    frames.Add(frame);
                }
                return frames;
            }
            catch (Exception ex)
            {
                LogUtility.LogError("[TextureUtility] GifToFrames error: {0}.", ex.Message);
                return null;
            }
        }
        #endregion
    }
}