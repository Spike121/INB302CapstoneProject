using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security;
using System.IO;

namespace RecommenderAttacksAnalytics.Utility
{
    public class Util
    {
        

  

        private static byte[] getBytes(string str)
        { 
            var byteArray = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, byteArray, 0, byteArray.Length);
            return byteArray;
        }

        public static string encrypt(string str, string key)
        {/*
            var ms = new MemoryStream(); 
            var algo = Rijndael.Create();
            algo.Key = getBytes(key);

            var cs = new CryptoStream(ms, algo.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(getBytes(str), 0, str.Length);
            cs.Close();

            //return ms.ToArray();*/
            return str;
        }

        public static int getRandomIntegerInRange(int lowerBound, int upperBound)
        {
            if(upperBound < lowerBound)
                throw new Exception("Upper bong value cannot be smaller than lower bound value");

            if(lowerBound < 0 || upperBound < 0)
                throw new Exception("Lower bound and upper bound values must be positive");

            return new Random().Next(lowerBound, upperBound);
        }

        public static List<int> getNRandomIntegersInRange(int lowerBound, int upperBound, int count)
        {
            var randomIntegers = new List<int>(count);
            
            if(upperBound - lowerBound < count)
                throw new ArgumentOutOfRangeException("Too many elements for current range");

            recursiveGetNNumbersInRange(lowerBound, upperBound, ref randomIntegers, count);
            return randomIntegers;
        }

        public static bool getRandomBoolean()
        {
            return new Random().Next(0,2) > 0;
        }

        private static void recursiveGetNNumbersInRange(int lower, int upper, ref List<int> values, int count)
        {

            if (upper <= lower)
                return;

            var val = getRandomIntegerInRange(lower, upper);
            values.Add(val);

            if (values.Count >= count)
                return;

            recursiveGetNNumbersInRange(lower, val-1, ref values, count);

            if (values.Count >= count)
                return;

            recursiveGetNNumbersInRange(val+1, upper, ref values, count);
        }


    }
}
