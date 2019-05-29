﻿/*  
 
    Copyright (c) 2008-2012 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Configuration;
using Profiles.Framework.Utilities;

namespace Profiles.Login.Modules.ShibLogin
{
    public partial class ShibLogin : System.Web.UI.UserControl
    {
        Framework.Utilities.SessionManagement sm;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["method"].ToString() == "logout")
                {

                    sm.SessionLogout();
                    sm.SessionDestroy();
                    Response.Redirect(Request.QueryString["redirectto"].ToString());
                }
                else if (Request.QueryString["method"].ToString() == "shibboleth")
                {
                    // added by Eric
                    // If they specify an Idp, then check that they logged in from the configured IDP
                    bool authenticated = false;
                    if (ConfigurationManager.AppSettings["Shibboleth.ShibIdentityProvider"] == null ||
                        ConfigurationManager.AppSettings["Shibboleth.ShibIdentityProvider"].ToString().Equals(Request.Headers.Get("ShibIdentityProvider").ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        String userName = Request.Headers.Get(ConfigurationManager.AppSettings["Shibboleth.UserNameHeader"].ToString()); //"025693078";
                        if (userName != null && userName.Trim().Length > 0)
                        {
                            Profiles.Login.Utilities.DataIO data = new Profiles.Login.Utilities.DataIO();
                            Profiles.Login.Utilities.User user = new Profiles.Login.Utilities.User();

                            user.UserName = userName;
                            if (data.UserLoginExternal(ref user))
                            {
                                authenticated = true;
                                RedirectAuthenticatedUser();
                            }
                        }
                    }
                    if (!authenticated)
                    {
                        // try and just put their name in the session.
                        //sm.Session().ShortDisplayName = Request.Headers.Get("ShibdisplayName");
                        RedirectAuthenticatedUser();
                    }
                }
                else if (Request.QueryString["method"].ToString() == "login")
                {
                    // see if they already have a login session, if so don't send them to shibboleth
                    Profiles.Framework.Utilities.SessionManagement sm = new Profiles.Framework.Utilities.SessionManagement();
                    String viewerId = sm.Session().PersonURI;
                    if (viewerId != null && viewerId.Trim().Length > 0)
                    {
                        RedirectAuthenticatedUser();
                    }
                    else
                    {
                        string redirect = Root.Domain + "/login/default.aspx?method=shibboleth";
                        if (Request.QueryString["redirectto"] == null && Request.QueryString["edit"] == "true")
                            redirect += "&edit=true";
                        else
                            redirect += "&redirectto=" + Request.QueryString["redirectto"].ToString();

                        Response.Redirect(ConfigurationManager.AppSettings["Shibboleth.LoginURL"].ToString().Trim() +
                            HttpUtility.UrlEncode(redirect));
                    }
                }

            }


        }

        private void RedirectAuthenticatedUser()
        {
            if (Request.QueryString["redirectto"] == null && Request.QueryString["edit"] == "true")
            {
                Response.Redirect(Root.Domain + "/edit/" + sm.Session().NodeID);
            }
            else if (Request.QueryString["redirectto"] != null)
            {
                if ("mypage".Equals(Request.QueryString["redirectto"].ToLower())) 
                {
                    Response.Redirect(Root.Domain + "/profile/" + sm.Session().NodeID);
                }
                else if ("myproxies".Equals(Request.QueryString["redirectto"].ToLower()))
                {
                    Response.Redirect(Root.Domain + "/proxy/default.aspx?subject=" + sm.Session().NodeID);
                }
                else 
                {
                    Response.Redirect(Request.QueryString["redirectto"].ToString());
                }
            }
            Response.Redirect(Root.Domain);
        }

        public ShibLogin() { }
        public ShibLogin(XmlDocument pagedata, List<ModuleParams> moduleparams, XmlNamespaceManager pagenamespaces)
        {
            sm = new Profiles.Framework.Utilities.SessionManagement();
        }

    }
}