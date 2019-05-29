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
using System.Xml;

using Profiles.Framework.Utilities;
using Profiles.ORNG.Utilities;


namespace Profiles.ORNG.Modules.Gadgets
{

    public partial class ViewPersonalGadget : BaseModule
    {
        private OpenSocialManager om;
        private string uri = null;
        private PreparedGadget gadget;

        protected void Page_Load(object sender, EventArgs e)
        {
            DrawProfilesModule();
        }

        public ViewPersonalGadget() : base() { }

        public ViewPersonalGadget(XmlDocument pagedata, List<ModuleParams> moduleparams, XmlNamespaceManager pagenamespaces)
            : base(pagedata, moduleparams, pagenamespaces)
        {
            // code to convert from numeric node ID to URI
            if (base.Namespaces.HasNamespace("rdf"))
            {
                XmlNode node = this.BaseData.SelectSingleNode("rdf:RDF/rdf:Description/@rdf:about", base.Namespaces);
                uri = node != null ? node.Value : null;
            }
            om = OpenSocialManager.GetOpenSocialManager(uri, Page);
            gadget = om.AddGadget(Convert.ToInt32(base.GetModuleParamString("AppId")), base.GetModuleParamString("View"), base.GetModuleParamString("OptParams"));
        }

        private void DrawProfilesModule()
        {
            // UCSF OpenSocial items
            if (gadget != null && om.IsVisible())
            {
                litGadget.Text = "<table><tr><td><div id='" + gadget.GetChromeId() + "' class='gadgets-gadget-parent'></div></td></tr></table>";
                om.LoadAssets();
            }
        }

    }

}