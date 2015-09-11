namespace ReliSource.Modules.DevUser {
    public static class RegistrationCustomCode {
        public static void CompletionBefore(long userId, bool getRoleFromRegistration, string role = null) {
        }

        public static void CompletionAfter(long userId, bool getRoleFromRegistration, string role = null) {
        }
        internal static void CompletionBefore(ApplicationUser userIndetity, bool getRoleFromRegistration, string role) {
        }
        internal static void CompletionAfter(ApplicationUser userIndetity, bool getRoleFromRegistration, string role) {
           // write codes after completion of the registration
		}
    }
}