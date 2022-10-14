using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Criminal.Service
{
    public class Cypher
    {
        public static string generarSHA1(string cadena)
        {
            //funcion ayuda a que nuestro strin de password este cifrado en la base de datos y no se pueda visualizar
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {

                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            return sb.ToString();
        }
    }
}
