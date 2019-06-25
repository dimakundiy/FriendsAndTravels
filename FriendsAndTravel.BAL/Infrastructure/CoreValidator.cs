using System;


namespace FriendsAndTravel.BAL.Infrastructure
{
    public static class CoreValidator
    {
        public static bool CheckIfStringIsNullOrEmpty(string input) => String.IsNullOrEmpty(input);
    }
}
