/*************************************************************************
 *  Copyright © 2015-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TextureExtention.cs
 *  Description  :  Extention for UnityEngine.Texture2D.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/24/2015
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.Converter;
using Mogoson.IO;
using UnityEngine;

namespace Mogoson.Extension
{
    /// <summary>
    /// Extention for UnityEngine.Texture2D.
    /// </summary>
    public static class ETexture2D
    {
        #region Public Static Method
        /// <summary>
        /// Update the pixels of Texture2D.
        /// </summary>
        /// <param name="texture2D">Base Texture2D.</param>
        /// <param name="colorArray">Color array for pixels.</param>
        /// <param name="mipLevel">The mip level of the texture to write to.</param>
        /// <param name="updateMipmaps">When set to true, mipmap levels are recalculated.</param>
        /// <param name="makeNointerReadable">When set to true, system memory copy of a texture is released.</param>
        public static void UpdatePixels(this Texture2D texture2D, Color[] colorArray, int mipLevel = 0, bool updateMipmaps = false, bool makeNointerReadable = false)
        {
            if (colorArray == null || colorArray.Length != texture2D.width * texture2D.height)
            {
                Logger.LogError("The color array is null or invalid.");
                return;
            }

            texture2D.SetPixels(colorArray, mipLevel);
            texture2D.Apply(updateMipmaps, makeNointerReadable);
        }

        /// <summary>
        /// Update the pixels of Texture2D.
        /// </summary>
        /// <param name="texture2D">Base Texture2D.</param>
        /// <param name="colorArray">Color array for pixels.</param>
        /// <param name="mipLevel">The mip level of the texture to write to.</param>
        /// <param name="updateMipmaps">When set to true, mipmap levels are recalculated.</param>
        /// <param name="makeNointerReadable">When set to true, system memory copy of a texture is released.</param>
        public static void UpdatePixels(this Texture2D texture2D, Color[,] colorArray, int mipLevel = 0, bool updateMipmaps = false, bool makeNointerReadable = false)
        {
            if (colorArray == null || colorArray.Length != texture2D.width * texture2D.height)
            {
                Logger.LogError("The color array is null or invalid.");
                return;
            }

            Color[] cArray = ArrayConverter.ToOneDimention(colorArray);
            UpdatePixels(texture2D, cArray, mipLevel, updateMipmaps, makeNointerReadable);
        }

        /// <summary>
        /// Update the pixels of Texture2D.
        /// </summary>
        /// <param name="texture2D">Base Texture2D.</param>
        /// <param name="colorArray">Color array for pixels.</param>
        /// <param name="mipLevel">The mip level of the texture to write to.</param>
        /// <param name="updateMipmaps">When set to true, mipmap levels are recalculated.</param>
        /// <param name="makeNointerReadable">When set to true, system memory copy of a texture is released.</param>
        public static void UpdatePixels(this Texture2D texture2D, Color32[] colorArray, int mipLevel = 0, bool updateMipmaps = false, bool makeNointerReadable = false)
        {
            if (colorArray == null || colorArray.Length != texture2D.width * texture2D.height)
            {
                Logger.LogError("The color array is null or invalid.");
                return;
            }

            texture2D.SetPixels32(colorArray, mipLevel);
            texture2D.Apply(updateMipmaps, makeNointerReadable);
        }

        /// <summary>
        /// Update the pixels of Texture2D.
        /// </summary>
        /// <param name="texture2D">Base Texture2D.</param>
        /// <param name="colorArray">Color array for pixels.</param>
        /// <param name="mipLevel">The mip level of the texture to write to.</param>
        /// <param name="updateMipmaps">When set to true, mipmap levels are recalculated.</param>
        /// <param name="makeNointerReadable">When set to true, system memory copy of a texture is released.</param>
        public static void UpdatePixels(this Texture2D texture2D, Color32[,] colorArray, int mipLevel = 0, bool updateMipmaps = false, bool makeNointerReadable = false)
        {
            if (colorArray == null || colorArray.Length != texture2D.width * texture2D.height)
            {
                Logger.LogError("The color array is null or invalid.");
                return;
            }

            Color32[] cArray = ArrayConverter.ToOneDimention(colorArray);
            UpdatePixels(texture2D, cArray, mipLevel, updateMipmaps, makeNointerReadable);
        }
        #endregion
    }
}