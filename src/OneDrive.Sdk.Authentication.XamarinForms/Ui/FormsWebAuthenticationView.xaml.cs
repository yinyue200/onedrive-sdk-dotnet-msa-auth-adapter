﻿using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Microsoft.OneDrive.Sdk.Authentication.Ui
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormsWebAuthenticationView : ContentView
	{
        public void Cancel()
        {
            this.WebAuthenticationUi.OnFailed(
new AuthFailedEventArgs(
new ServiceException(
new Error
{
    Code = "authenticationCanceled",
    Message = "User canceled authentication."
})));
        }
		public FormsWebAuthenticationView ()
		{
			InitializeComponent ();
            webView.Navigated += WebView_Navigated;
		}


        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            Uri source = new Uri(e.Url);
            if (e.Url.StartsWith(this.CallbackUri.ToString()))
            {
                var parameters = UrlHelper.GetQueryOptions(source);
                this.WebAuthenticationUi.OnCompleted(new AuthCompletedEventArgs(parameters));
            }
        }

        public void Load(FormsWebAuthenticationUi webAuthenticationUi,Uri requestUri,Uri callbackUri)
        {
            WebAuthenticationUi = webAuthenticationUi;
            RequestUri = requestUri;
            CallbackUri = callbackUri;
        }
        public Uri CallbackUri { get; private set; }
        public Uri RequestUri { get; private set; }
        public FormsWebAuthenticationUi WebAuthenticationUi { get; private set; }
        public void BeginLoadAuthorizationUrl()
        {
            webView.Source = RequestUri;
        }
    }
}