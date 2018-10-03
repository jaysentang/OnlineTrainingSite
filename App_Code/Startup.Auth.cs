using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using Owin;
using System;

namespace TrainingSite
{
    public partial class Startup {

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301883
        //static Startup() {
         //   UserManagerFactory = () => new UserManager<IdentityUser>(new UserStore<IdentityUser>());
        //}
       // public static Func<UserManager<IdentityUser>> UserManagerFactory { get; set; }
       public static IDataProtectionProvider provider { get; set; }
        public void ConfigureAuth(IAppBuilder app)

        {
            // Enable the application to use a cookie to store information for the signed in user
            // and also store information about a user logging in with a third party login provider.
            // This is required if your application allows users to login

          //  var manager = UserManagerFactory();
               provider = app.GetDataProtectionProvider();

            //            if (provider != null) {
            //              manager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(provider.Create("PasswordReset")) { TokenLifespan = TimeSpan.FromMinutes(2)};
            //        }
            app.CreatePerOwinContext<UserManager>(UserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieManager = new SystemWebCookieManager(),
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
           // app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            
            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}
