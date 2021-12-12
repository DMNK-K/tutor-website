using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Korki.Models;
using System.Threading;
using KorkiDataAccessLib.Access;
using Korki.ExtAndUtility;
using KorkiDataAccessLib.Models;

namespace Korki.Areas.Identity.Stores
{
    public class KorkiUserStore : IUserStore<User>, IUserPasswordStore<User>, IUserEmailStore<User>
    {
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly IUserWriter writer;
        private readonly IUserReader reader;

        public KorkiUserStore(IUserReader reader, IUserWriter writer, IPasswordHasher<User> passwordHasher)
        {
            this.writer = writer;
            this.reader = reader;
            this.passwordHasher = passwordHasher;
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            int rowsAffected = await writer.CreateUser(user.Map());
            return IdentityResultByNOfRows(rowsAffected, "CreateAsync Failed");
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            int rowsAffected = await writer.DeleteUser(user.ID, "");
            return IdentityResultByNOfRows(rowsAffected, "DeleteAsync Failed");
        }

        public void Dispose()
        {
            
        }

        public async Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return (await reader.GetUserByEmail(normalizedEmail))?.Map();
        }

        //Identity allows custom User types where ID is not a string, but it seems this is not reflected
        //in the IUserStore<WhateverCustomUserType> interface, it still demands this method to be
        //implemented with string, hence the parse
        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            int properID;
            if (int.TryParse(userId, out properID))
            {
                return (await reader.GetUser(properID))?.Map();
            }
            else
            {
                return null;
            }
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return (await reader.GetUserByUsername(normalizedUserName))?.Map();
        }

        public async Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            return await Task.FromResult(user.Email);
        }

        public async Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            return await Task.FromResult(user.EmailConfirmed);
        }

        public async Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            return await Task.FromResult(user.NormalizedEmail);
        }

        public async Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            return await Task.FromResult(user.NormalizedUserName);
        }

        public async Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            return await Task.FromResult(user.PasswordHash);
        }

        public async Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            return await Task.FromResult(user.ID.ToString());
        }

        public async Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            return await Task.FromResult(user.UserName);
        }

        public async Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            return await Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }

        public async Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            user.Email = email;
            await Task.CompletedTask;
        }

        public async Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            user.EmailConfirmed = confirmed;
            await Task.CompletedTask;
        }

        public async Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            user.NormalizedEmail = normalizedEmail;
            await Task.CompletedTask;
        }

        public async Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            user.NormalizedUserName = normalizedName;
            await Task.CompletedTask;
        }

        public async Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            user.PasswordHash = passwordHash;
            await Task.CompletedTask;
        }

        public async Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            user.UserName = userName;
            await Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            ThrowBasedOnUserAndToken(user, cancellationToken);
            int rowsAffected = await writer.UpdateUser(user.Map());
            return IdentityResultByNOfRows(rowsAffected, "UpdateAsync Failed");
        }

        private IdentityResult IdentityResultByNOfRows(int nOfRowsAffected, string failCode, string failDesc = "")
        {
            if (nOfRowsAffected > 0)
            {
                return IdentityResult.Success;
            }
            else
            {
                return IdentityResult.Failed(new IdentityError() { Code = failCode, Description = failDesc });
            }
        }

        private void ThrowBasedOnUserAndToken(User user, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            if (user == null) throw new ArgumentNullException("user");
        }
    }
}
