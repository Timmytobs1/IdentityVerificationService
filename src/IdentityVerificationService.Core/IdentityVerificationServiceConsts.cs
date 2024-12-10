using IdentityVerificationService.Debugging;

namespace IdentityVerificationService
{
    public class IdentityVerificationServiceConsts
    {
        public const string LocalizationSourceName = "IdentityVerificationService";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;

        /// <summary> 
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "bb0093cddd1a44218b22ec0521e8af93";
    }
}
