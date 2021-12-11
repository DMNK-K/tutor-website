using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korki.Areas.Identity.Utility
{
    public class IdentityErrorDescriberPL : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = nameof(PasswordRequiresLower),
                Description = "Hasło musi zawierać min. 1 małą literę."
            };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError()
            {
                Code = nameof(PasswordMismatch),
                Description = "Hasło i powtórzone hasło muszą być identyczne."
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "Hasło musi zawierać min. 1 wielką literę."
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = nameof(PasswordTooShort),
                Description = "Hasło musi mieć długość min. 8 znaków."
            };
        }

        public static IdentityError PasswordContainsLogin()
        {
            return new IdentityError()
            {
                Code = nameof(PasswordContainsLogin),
                Description = "Hasło nie może zawierać loginu."
            };
        }

        public static IdentityError PasswordContainsCommonSubstring()
        {
            return new IdentityError()
            {
                Code = nameof(PasswordContainsCommonSubstring),
                Description = "Hasło nie może zawierać popularnych ciągów tekstowych takich jak qwert, hasło, 12345, etc."
            };
        }

        public static IdentityError PasswordIsCommon()
        {
            return new IdentityError()
            {
                Code = nameof(PasswordIsCommon),
                Description = "Hasło nie może być jednym ze stereotypowych haseł takich jak wpuśćmnie, słoneczko, etc."
            };
        }
    }
}
