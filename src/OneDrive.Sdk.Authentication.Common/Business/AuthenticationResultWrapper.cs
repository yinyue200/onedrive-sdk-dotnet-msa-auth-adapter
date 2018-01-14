// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.OneDrive.Sdk.Authentication
{
    using System;

    using Microsoft.IdentityModel.Clients.ActiveDirectory;

    public class AuthenticationResultWrapper : IAuthenticationResult
    {
        private AuthenticationResult authenticationResult;

        public AuthenticationResultWrapper(AuthenticationResult authenticationResult)
        {
            this.authenticationResult = authenticationResult;
        }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken
        {
            get
            {
                if (this.authenticationResult != null)
                {
                    return this.authenticationResult.AccessToken;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the type of the access token.
        /// </summary>
        public string AccessTokenType
        {
            get
            {
                if (this.authenticationResult != null)
                {
                    return this.authenticationResult.AccessTokenType;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the point in time in which the access token expires.
        /// This value is calculated based on current UTC time.
        /// </summary>
        public DateTimeOffset ExpiresOn
        {
            get
            {
                if (this.authenticationResult != null)
                {
                    return this.authenticationResult.ExpiresOn;
                }

                return default(DateTimeOffset);
            }
        }

        /// <summary>
        /// Gets the ID token.
        /// </summary>
        public string IdToken
        {
            get
            {
                if (this.authenticationResult != null)
                {
                    return this.authenticationResult.IdToken;
                }

                return null;
            }
        }


        /// <summary>
        /// Gets an identifier for the tenant from which the access token was acquired.
        /// </summary>
        public string TenantId
        {
            get
            {
                if (this.authenticationResult != null)
                {
                    return this.authenticationResult.TenantId;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets user information, such as user ID.
        /// </summary>
        public IUserInfo UserInfo
        {
            get
            {
                if (this.authenticationResult != null && this.authenticationResult.UserInfo != null)
                {
                    return new UserInfoWrapper(this.authenticationResult.UserInfo);
                }

                return null;
            }
        }

    }
}
