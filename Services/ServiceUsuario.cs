using projetoarquitetura.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace projetoarquitetura.Services
{
    public class ServiceUsuario  : IServiceUsuario
    {
        public string HashValue(string value)
        {

            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] hashBytes;

            using (HashAlgorithm hash = SHA1.Create()) hashBytes = hash.ComputeHash(encoding.GetBytes(value));

            StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
            foreach (byte b in hashBytes)
            {
                hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
            }

            string chave = "profedsonbelem@gmail.com_www.arq.com.br_1+1=2";
            using (HashAlgorithm hash = SHA1.Create()) hashBytes = hash.ComputeHash(encoding.GetBytes(chave));

            StringBuilder hashValue2 = new StringBuilder(hashBytes.Length * 2);
            foreach (byte b in hashBytes)
            {
                hashValue2.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
            }
            foreach (byte b in hashBytes)
            {
                hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
            }
            return (hashValue.ToString() + hashValue2.ToString());

        }

    
    }
}
