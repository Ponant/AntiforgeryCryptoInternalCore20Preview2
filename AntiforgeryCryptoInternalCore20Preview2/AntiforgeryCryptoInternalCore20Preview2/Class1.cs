using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace AntiforgeryCryptoInternalCore20Preview2
{
    //public static class CryptographyAlgorithms
    //{
    //    public static SHA256 CreateSHA256()
    //    {
    //        try
    //        {
    //            return SHA256.Create();
    //        }
    //        // SHA256.Create is documented to throw this exception on FIPS compliant machines.
    //        // See: https://msdn.microsoft.com/en-us/library/z08hz7ad%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
    //        catch (System.Reflection.TargetInvocationException)
    //        {
    //            // Fallback to a FIPS compliant SHA256 algorithm.
    //            return new SHA256CryptoServiceProvider();
    //        }
    //    }
    }

    public class CultureCryptoService
    {
        /// <summary>
        /// Hashes <see cref="tail"/> and appends it to string  <see cref="head"/>
        /// </summary>
        /// <param name="head">The beginning of the returned string</param>
        /// <param name="tail">The string to hash and append to <see cref="head"/></param>
        /// <returns></returns>
        public string AppendHash(string head, string tail = "")
        {
            using (var sha256 = CryptographyAlgorithms.CreateSHA256())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(tail));
                var subHash = hash.Take(8).ToArray();
                return head + WebEncoders.Base64UrlEncode(subHash);
            }
        }
    }
}
