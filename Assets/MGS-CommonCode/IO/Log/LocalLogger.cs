/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LocalLogger.cs
 *  Description  :  Local logger of system.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/19/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.IO;
using UnityEngine;

namespace Mogoson.IO
{
    /// <summary>
    /// Local logger of system.
    /// </summary>
    public static class LocalLogger
    {
        #region Field and Property
        /// <summary>
        /// Path of log file.
        /// </summary>
        public static readonly string logPath = Application.persistentDataPath + "/Log.txt";
        #endregion

        #region Public Method
        /// <summary>
        /// Log content to local file.
        /// </summary>
        /// <param name="content">Log content.</param>
        public static void Log(string content)
        {
            var formatLog = string.Format("[{0}]-{1}\r\n", DateTime.Now, content);
            try
            {
                File.AppendAllText(logPath, formatLog);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
        #endregion
    }
}