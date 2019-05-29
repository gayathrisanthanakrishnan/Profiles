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

using Profiles.Framework.Utilities;

namespace Profiles.Error.Modules
{
    public partial class ErrorMessage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["GLOBAL_ERROR"] !=null)
            litError.Text = HttpContext.Current.Session["GLOBAL_ERROR"].ToString();
        }

        public ErrorMessage() { }
        public ErrorMessage(XmlDocument pagedata, List<ModuleParams> moduleparams, XmlNamespaceManager pagenamespaces) { }

    }
}