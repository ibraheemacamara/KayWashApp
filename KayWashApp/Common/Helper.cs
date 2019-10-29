using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KayWashApp.Common
{
    public static class Helper
    {
        private static string PatternWashRequestRef = "WReq_";
        private static string PatternWashRef = "W_";

        public static bool VerifyPasswordHash(string password, string passwordHash)
        {
            var hash = CreatePasswordHash(password);

            return hash == passwordHash;
        }

        public static string CreatePasswordHash(string password)
        {

            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            var passwordHash = System.Text.Encoding.ASCII.GetString(data);

            return passwordHash;
        }

        internal static string GenerateRef()
        {
            return PatternWashRequestRef + DateTime.Now.ToString("MMddmmssff");

        }
    }
}
