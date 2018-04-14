/*************************************************************************
 *  Copyright © 2015-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Converter.cs
 *  Description  :  Converter for byte data, array and structure.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  10/12/2015
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace Mogoson.Converter
{
    /// <summary>
    /// Converter of byte data.
    /// </summary>
    public static class ByteConverter
    {
        #region Public Static Method
        /// <summary>
        /// Byte array to Boolean array.
        /// </summary>
        /// <returns>Convert Boolean array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Boolean count.</param>
        public static bool[] ByteArrayToBooleanArray(byte[] bytes, int start = 0, int count = 1)
        {
            //1(1 byte to a Boolean)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 1)
                return null;

            count = Math.Min(count, bytes.Length - start);
            bool[] booleanArray = new bool[count];
            for (var i = 0; i < count; i++)
            {
                booleanArray[i] = BitConverter.ToBoolean(bytes, start + i);
            }
            return booleanArray;
        }

        /// <summary>
        /// Byte array to Int16 array.
        /// </summary>
        /// <returns>Convert Int16 array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Int16 count.</param>
        public static short[] ByteArrayToInt16Array(byte[] bytes, int start = 0, int count = 1)
        {
            //2(2 bytes to a Int16)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 2)
                return null;

            count = Math.Min(count, (bytes.Length - start) / 2);
            short[] int16Array = new short[count];
            for (var i = 0; i < count; i++)
            {
                int16Array[i] = BitConverter.ToInt16(bytes, start + i * 2);
            }
            return int16Array;
        }

        /// <summary>
        /// Byte array to Int32 array.
        /// </summary>
        /// <returns>Convert Int32 array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Int32 count.</param>
        public static int[] ByteArrayToInt32Array(byte[] bytes, int start = 0, int count = 1)
        {
            //4(4 bytes to a Int32)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 4)
                return null;

            count = Math.Min(count, (bytes.Length - start) / 4);
            int[] int32Array = new int[count];
            for (var i = 0; i < count; i++)
            {
                int32Array[i] = BitConverter.ToInt32(bytes, start + i * 4);
            }
            return int32Array;
        }

        /// <summary>
        /// Byte array to Int64 array.
        /// </summary>
        /// <returns>Convert Int64 array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Int64 count.</param>
        public static long[] ByteArrayToInt64Array(byte[] bytes, int start = 0, int count = 1)
        {
            //8(8 bytes to a Int64)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 8)
                return null;

            count = Math.Min(count, (bytes.Length - start) / 8);
            long[] int64Array = new long[count];
            for (var i = 0; i < count; i++)
            {
                int64Array[i] = BitConverter.ToInt64(bytes, start + i * 8);
            }
            return int64Array;
        }

        /// <summary>
        /// Byte array to Char array.
        /// </summary>
        /// <returns>Convert Char array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Char count.</param>
        public static char[] ByteArrayToCharArray(byte[] bytes, int start = 0, int count = 1)
        {
            //2(2 bytes to a Char)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 2)
                return null;

            count = Math.Min(count, (bytes.Length - start) / 2);
            char[] charArray = new char[count];
            for (var i = 0; i < count; i++)
            {
                charArray[i] = BitConverter.ToChar(bytes, start + i * 2);
            }
            return charArray;
        }

        /// <summary>
        /// Byte array to Single array.
        /// </summary>
        /// <returns>Convert Single array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Single count.</param>
        public static float[] ByteArrayToSingleArray(byte[] bytes, int start = 0, int count = 1)
        {
            //4(4 bytes to a Single)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 4)
                return null;

            count = Math.Min(count, (bytes.Length - start) / 4);
            float[] singleArray = new float[count];
            for (var i = 0; i < count; i++)
            {
                singleArray[i] = BitConverter.ToSingle(bytes, start + i * 4);
            }
            return singleArray;
        }

        /// <summary>
        /// Byte array to Double array.
        /// </summary>
        /// <returns>Convert Double array.</returns>
        /// <param name="bytes">Bytes array.</param>
        /// <param name="start">Start index.</param>
        /// <param name="count">Convert Double count.</param>
        public static double[] ByteArrayToDoubleArray(byte[] bytes, int start = 0, int count = 1)
        {
            //8(8 bytes to a Double)
            if (bytes == null || bytes.Length == 0 || count == 0 || start > bytes.Length - 8)
                return null;

            count = Math.Min(count, (bytes.Length - start) / 8);
            double[] doubleArray = new double[count];
            for (var i = 0; i < count; i++)
            {
                doubleArray[i] = BitConverter.ToDouble(bytes, start + i * 8);
            }
            return doubleArray;
        }
        #endregion
    }

    /// <summary>
    /// Converter of array.
    /// </summary>
    public static class ArrayConverter
    {
        #region Public Static Method
        /// <summary>
        /// Convert one dimention array to two dimentions array.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="array">Source array.</param>
        /// <param name="row">Two dimention array's row.</param>
        /// <param name="column">Two dimention array's column.</param>
        /// <returns>Two dimentions array.</returns>
        public static T[,] ToTwoDimentionArray<T>(T[] array, int row, int column)
        {
            if (array == null || array.Length == 0 || row * column != array.Length)
                return null;

            T[,] twoDArray = new T[row, column];
            var index = 0;
            for (var r = 0; r < row; r++)
            {
                for (var c = 0; c < column; c++)
                {
                    twoDArray[r, c] = array[index];
                    index++;
                }
            }
            return twoDArray;
        }

        /// <summary>
        /// Convert one dimention array to three dimentions array.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="array">Source array.</param>
        /// <param name="layer">Three dimention array's layer.</param>
        /// <param name="row">Three dimention array's row.</param>
        /// <param name="column">Three dimention array's column.</param>
        /// <returns>Three dimentions array.</returns>
        public static T[,,] ToThreeDimentionArray<T>(T[] array, int layer, int row, int column)
        {
            if (array == null || array.Length == 0 || row * column * layer != array.Length)
                return null;

            T[,,] threeDArray = new T[layer, row, column];
            var index = 0;
            for (var l = 0; l < layer; l++)
            {
                for (var r = 0; r < row; r++)
                {
                    for (var c = 0; c < column; c++)
                    {
                        threeDArray[l, r, c] = array[index];
                        index++;
                    }
                }
            }
            return threeDArray;
        }

        /// <summary>
        /// Convert two dimention array to one dimentions array.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="array">Source array.</param>
        /// <returns>One dimentions array.</returns>
        public static T[] ToOneDimentionArray<T>(T[,] array)
        {
            if (array == null || array.Length == 0)
                return null;

            T[] oneDArray = new T[array.Length];
            var index = 0;
            for (var r = 0; r < array.GetLength(0); r++)
            {
                for (var c = 0; c < array.GetLength(1); c++)
                {
                    oneDArray[index] = array[r, c];
                    index++;
                }
            }
            return oneDArray;
        }

        /// <summary>
        /// Convert three dimention array to one dimentions array.
        /// </summary>
        /// <typeparam name="T">Element type.</typeparam>
        /// <param name="array">Source array.</param>
        /// <returns>One dimentions array.</returns>
        public static T[] ToOneDimentionArray<T>(T[,,] array)
        {
            if (array == null || array.Length == 0)
                return null;

            T[] oneDArray = new T[array.Length];
            var index = 0;
            for (var l = 0; l < array.GetLength(0); l++)
            {
                for (var r = 0; r < array.GetLength(1); r++)
                {
                    for (var c = 0; c < array.GetLength(2); c++)
                    {
                        oneDArray[index] = array[l, r, c];
                        index++;
                    }
                }
            }
            return oneDArray;
        }
        #endregion
    }

    /// <summary>
    /// Converter of structure.
    /// </summary>
    public static class StructureConverter
    {
        /// <summary>
        /// Byte array to object.
        /// </summary>
        /// <typeparam name="T">Structure type.</typeparam>
        /// <param name="byteArray">Byte array.</param>
        /// <returns>Convert structure.</returns>
        public static T ByteArrayToStructure<T>(byte[] byteArray) where T : struct
        {
            if (byteArray == null || byteArray.Length == 0)
                return default(T);

            var size = Marshal.SizeOf(default(T));
            if (size > byteArray.Length)
                return default(T);

            IntPtr intPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(byteArray, 0, intPtr, size);
            var sObject = (T)Marshal.PtrToStructure(intPtr, typeof(T));
            Marshal.FreeHGlobal(intPtr);
            return sObject;
        }

        /// <summary>
        /// Structure to byte array.
        /// </summary>
        /// <typeparam name="T">Structure type.</typeparam>
        /// <param name="structure">Structure.</param>
        /// <returns>Byte array.</returns>
        public static byte[] StructureToByteArray<T>(T structure) where T : struct
        {
            var size = Marshal.SizeOf(structure);
            if (size == 0)
                return null;

            IntPtr intPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(structure, intPtr, true);
            byte[] byteArray = new byte[size];
            Marshal.Copy(intPtr, byteArray, 0, size);
            Marshal.FreeHGlobal(intPtr);
            return byteArray;
        }
    }
}