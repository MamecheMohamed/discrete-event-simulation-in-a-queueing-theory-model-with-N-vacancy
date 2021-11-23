using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace DESQT
{
    class Distributions
    {
        public float lmbda  { get; set; }
        public  float Exponontiel(float ma)
        {
           RNGCryptoServiceProvider Random = new RNGCryptoServiceProvider();
           uint s = uint.MaxValue; 
           byte[] array = new byte[4];
           Random.GetBytes(array);
           s = BitConverter.ToUInt32(array, 0);
           var X= (s / (double)uint.MaxValue);
           return (float)Math.Log(X) / (-1 * ma);
        }
        public float exponential(Random seed, float mean)
        {
            return (float)(-mean * Math.Log((float)seed.NextDouble()));
        }
        public double GENRAL(double mean, double standard_deviation)
        {
            Random random = new Random();
            return (float)(mean + (random.NextDouble() * standard_deviation));
        }


        public double GE(double mean, double standard_deviation)
        {
            RNGCryptoServiceProvider Random = new RNGCryptoServiceProvider();
            uint s = uint.MaxValue;
            byte[] array = new byte[4];
            Random.GetBytes(array);
            s = BitConverter.ToUInt32(array, 0);
            var X = (s / (double)uint.MaxValue);
            return (float)(mean + (X * standard_deviation));
        }



       



    }

    }


    

