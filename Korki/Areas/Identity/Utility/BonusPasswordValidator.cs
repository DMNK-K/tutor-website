using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korki.Areas.Identity.Utility
{
    public class BonusPasswordValidator<T> : IPasswordValidator<T> where T : class
    {

        private readonly List<string> forbiddenSubStrings = new List<string>()
        {
            "qwerty",
            "asdfg",
            "zxcvb",
            "poiuy",
            "lkjhg",
            "mnbvc",
            "hasło",
            "admin",
            "abcde",
            "password",
            "passw0rd",
            "12345",
            "11111",
            "login",
            "zaq1",
            "1q2w3",
        };

        private readonly List<string> commonPasswords = new List<string>()
        {
            "football",
            "princess",
            "monkey123",
            "letmein",
            "małpa123",
            "welcome",
            "witamy",
            "wpuśćmnie",
            "wpóśćmnie",
            "kochamcię",
            "kochamcie",
            "iloveyou",
            "iloveu",
            "starwars",
            "sunshine",
            "słoneczko",
            "sloneczko",
            "master",
            "superman",
            "access",
            "dostęp",
            "dragon",
            "kwiatuszek",
            "picture1",
        };

        public async Task<IdentityResult> ValidateAsync(UserManager<T> manager, T user, string password)
        {
            string username = await manager.GetUserNameAsync(user);
            string lowerPass = password.ToLower();

            if (username.ToLower().Contains(lowerPass))
            {
                return IdentityResult.Failed(IdentityErrorDescriberPL.PasswordContainsLogin());
            }

            foreach (string forbidden in forbiddenSubStrings)
            {
                if (lowerPass.Contains(forbidden))
                {
                    return IdentityResult.Failed(IdentityErrorDescriberPL.PasswordContainsCommonSubstring());
                }
            }

            foreach (string common in commonPasswords)
            {
                if (lowerPass.Equals(commonPasswords))
                {
                    return IdentityResult.Failed(IdentityErrorDescriberPL.PasswordIsCommon());
                }
            }

            return IdentityResult.Success;
        }
    }
}
