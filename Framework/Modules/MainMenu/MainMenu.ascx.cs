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
using System.Web.UI;
using System.Xml;

using Profiles.Framework.Utilities;
namespace Profiles.Framework.Modules.MainMenu
{
    public partial class MainMenu : BaseModule
    {

        System.Text.StringBuilder menulist;
        SessionManagement sm;
        protected void Page_Init(object sender, EventArgs e)
        {
            DrawProfilesModule();
        }

        public MainMenu() : base() { }

        public MainMenu(XmlDocument pagedata, List<ModuleParams> moduleparams, XmlNamespaceManager pagenamespaces)
            : base(pagedata, moduleparams, pagenamespaces)
        {
            menulist = new System.Text.StringBuilder();
            sm = new SessionManagement();
            ActiveNetworkRelationshipTypes.ClassURI = "";
        }

        private void DrawProfilesModule()
        {
            Int64 subject = 0;

            if (Request.QueryString["subject"] != null)
                subject = Convert.ToInt64(Request.QueryString["subject"]);

            Utilities.DataIO data = new Profiles.Framework.Utilities.DataIO();
            menulist.Append("<ul>");

            menulist.Append("<li><a href='" + Root.Domain + "/search'>Find People</a></li>");
            menulist.Append("<li><a href='" + Root.Domain + "/search/all'>Find Everything</a></li>");

            //-50 is the profiles Admin
            if (data.GetSessionSecurityGroup() == -50)
                menulist.Append("<li><a href='" + Root.Domain + "/SPARQL/default.aspx'>SPARQL Query</a></li>");

            menulist.Append("<li><a href='" + Root.Domain + "/about/default.aspx'>About This Site</a></li>");

            if (sm.Session().NodeID > 0)
                menulist.Append("<li><a href='" + sm.Session().PersonURI + "'>View My Profile</a></li>");

            if (sm.Session().UserID == 0 || sm.Session().NodeID > 0)
                menulist.Append("<li><a href='" + Root.Domain + "/login/default.aspx?method=login&edit=true'>Edit My Profile</a></li>");


            if (base.MasterPage.CanEdit)
            {
                menulist.Append("<li><a href='" + Root.Domain + "/edit/" + subject.ToString() + "'>Edit This Profile</a></li>");
            }

            if (sm.Session().UserID > 0)
                menulist.Append("<li><a href='" + Root.Domain + "/proxy/default.aspx?subject=" + sm.Session().NodeID.ToString() + "'>Manage Proxies</a></li>");

            if (sm.Session().UserID > 0)
            {
                if(data.IsGroupAdmin(sm.Session().UserID))
                menulist.Append("<li><a href='" + Root.Domain + "/groupAdmin/default.aspx'>Manage Groups</a></li>");
            }


            if (base.BaseData.SelectSingleNode(".").OuterXml != string.Empty && !Root.AbsolutePath.ToLower().Contains("/search"))
            {
                if (base.BaseData.SelectSingleNode("//rdf:RDF/rdf:Description/@rdf:about", base.Namespaces) != null && !Root.AbsolutePath.ToLower().Contains("proxy"))
                {
                    string uri = this.BaseData.SelectSingleNode("//rdf:RDF/rdf:Description/@rdf:about", base.Namespaces).Value;

                    //IF the URI is in our system then we build the link. If not then we do not build the link for the data.
                    if (uri.Contains(Root.Domain))
                    {
                        string file = string.Empty;
                        string spostring = string.Empty;
                        string[] spoarray;

                        spostring = uri.ToLower().Replace(Root.Domain.ToLower() + "/profile/", "");
                        spoarray = spostring.Split('/');

                        for (int i = 0; i < spoarray.Length; i++)
                        {
                            file = file + spoarray[i] + "_";
                        }

                        file = file.Substring(0, file.Length - 1);

                        menulist.Append("<li><a href=\"" + uri + "/" + file + ".rdf\" target=\"_blank\">" + "Export RDF" + "</a>&nbsp;<a style='border: none;' href='" + Root.Domain + "/about/default.aspx?tab=data'><img style='border-style: none' src='" + Root.Domain + "/Framework/Images/info.png'  border='0' alt='Help with RDF'></a></li>");

                        if (base.MasterPage != null)
                        {
                            System.Web.UI.HtmlControls.HtmlContainerControl Head1;
                            Head1 = (System.Web.UI.HtmlControls.HtmlContainerControl)base.MasterPage.FindControl("Head1");
                            //If a masterpage exists, you need to to create an ASP.Net Literal object and pass it to the masterpage so it can process the link in the Head block.
                            string link = "<link rel=\"alternate\" type=\"application/rdf+xml\" href=\"" + uri + "/" + file + ".rdf\" />";
                            Head1.Controls.Add(new LiteralControl(link));
                        }

                    }
                }
            }


            if (sm.Session().UserID == 0)
            {
                if (!Root.AbsolutePath.Contains("login"))
                {
                    menulist.Append("<li><a href='" + Root.Domain + "/login/default.aspx?pin=send&method=login&redirectto=" + Root.Domain + Root.AbsolutePath + "'>Login to Profiles</a></li>");
                }
            }
            else
            {
                menulist.Append("<li><a href='" + Root.Domain + "/login/default.aspx?method=logout&redirectto=" + Root.Domain + Root.AbsolutePath + "'>Logout</a></li>");
            }

            menulist.Append("</ul>");

            // hide active networks DIV if not logged in
            if (sm.Session().UserID > 0)
            {
                ActiveNetworkRelationshipTypes.Visible = true;
            }
            else
            {
                ActiveNetworkRelationshipTypes.Visible = false;
            }

            UserHistory uh = new UserHistory();

            ProfileHistory.RDFData = base.BaseData;
            ProfileHistory.PresentationXML = base.MasterPage.PresentationXML;
            ProfileHistory.Namespaces = base.Namespaces;


            if (uh.GetItems() != null)
            {
                ProfileHistory.Visible = true;
            }
            else
            {
                ProfileHistory.Visible = false;
            }



            panelMenu.InnerHtml = menulist.ToString();

        }

    }
}