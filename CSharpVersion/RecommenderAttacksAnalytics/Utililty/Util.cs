using System;
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
        

        public static double getRatingAverageFromRatingsCollection(List<int> ratings)
        {
            double avg = 0.0f;
            foreach (var rating in ratings)
                avg += rating;

            return (ratings.Count == 0) ? 0.0f : avg / ratings.Count;
        }

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


    }
}
