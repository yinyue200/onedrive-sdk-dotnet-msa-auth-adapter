// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.OneDrive.Sdk.Authentication
{
    using System;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;

    public interface IAuthenticationResult
    {
        /// <summary>
        /// Gets the access token.
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        /// Gets the type of the access token.
        /// </summary>
        string AccessTokenType { get; }

        /// <summary>
        /// Gets the point in time in which the access token expires.
        /// This value is calculated based on current UTC time.
        /// </summary>
        DateTimeOffset ExpiresOn { get; }

        /// <summary>
        /// Gets the ID token.
        /// </summary>
        string IdToken { get; }

        /// <summary>
        /// Gets an identifier for the tenant from which the access token was acquired.
        /// </summary>
        string TenantId { get; }

        /// <summary>
        /// Gets user information, such as user ID.
        /// </summary>
        IUserInfo UserInfo { get; }
    }
}
