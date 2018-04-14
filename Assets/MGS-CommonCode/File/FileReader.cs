/*************************************************************************
 *  Copyright © 2015-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FileReader.cs
 *  Description  :  Reader for file.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/24/2015
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.IO;

namespace Mogoson.IO
{
    /// <summary>
    /// Reader for file.
    /// </summary>
    public static class FileReader
    {
        #region Public Static Method
        /// <summary>
        /// Calculate page count of file.
        /// </summary>
        /// <param name="filePath">Path of target file.</param>
        /// <param name="pageSize">Size of page.</param>
        /// <returns>Page count of file.</returns>
        public static int CalculatePageCount(string filePath, int pageSize = 65536)
        {
            if (!File.Exists(filePath) || pageSize <= 0)
                return 0;

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                return fileStream.Length / pageSize + fileStream.Length % pageSize == 0 ? 0 : 1;
            }
        }

        /// <summary>
        /// Read the index page of file.
        /// </summary>
        /// <param name="filePath">Path of target file.</param>
        /// <param name="pageSize">Size of page.</param>
        /// <param name="pageIndex">Index of page.</param>
        /// <returns>Index page bytes.</returns>
        public static byte[] ReadIndexPageBytes(string filePath, int pageSize = 65536, int pageIndex = 0)
        {
            if (!File.Exists(filePath) || pageSize <= 0 || pageIndex < 0)
                return null;

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                if (!fileStream.CanSeek || !fileStream.CanRead)
                    return null;

                var start = pageSize * pageIndex;
                if (start >= fileStream.Length)
                    return null;

                var count = Math.Min(pageSize, fileStream.Length - start);
                var bytesArray = new byte[count];

                fileStream.Seek(start, SeekOrigin.Begin);
                fileStream.Read(bytesArray, 0, (int)count);
                return bytesArray;
            }
        }
        #endregion
    }
}