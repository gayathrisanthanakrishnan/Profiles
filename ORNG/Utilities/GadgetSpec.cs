﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Profiles.ORNG.Utilities
{
    public class GadgetSpec 
    {

        static readonly string REGISTERED_APPS_CACHE_PREFIX = "ORNG.REGISTERED_APPS_";

        private int appId = 0;
        private string label;
        private string openSocialGadgetURL;
        private bool enabled;
        private bool unrecognized = false;
        private Dictionary<string, GadgetViewRequirements> viewRequirements = new Dictionary<string, GadgetViewRequirements>();

        // these are loaded from the DB
        public GadgetSpec(int appId, string label, string openSocialGadgetURL, bool enabled)
        {
            this.openSocialGadgetURL = openSocialGadgetURL;
            this.label = label;
            this.appId = appId;
            this.enabled = enabled;
            this.unrecognized = false;

            // load view requirements
            Profiles.ORNG.Utilities.DataIO data = new Profiles.ORNG.Utilities.DataIO();
            using (SqlDataReader dr = data.GetGadgetViewRequirements(appId))
            {
                while (dr.Read())
                {
                    viewRequirements.Add(dr[0].ToString().ToLower(), new GadgetViewRequirements(dr[0].ToString().ToLower(),
                            dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                            dr.IsDBNull(4) ? Int32.MaxValue : dr.GetInt32(4), dr[5].ToString()));
                }
            }
        }

        // this is for unrecognized gadgets loaded through the sandbox
        public GadgetSpec(string openSocialGadgetURL)
        {
            this.openSocialGadgetURL = openSocialGadgetURL;
            this.label = GetFileName();
            CharEnumerator ce = label.GetEnumerator();
            while (ce.MoveNext())
            {
                appId += (int)ce.Current;
            }
            this.enabled = true;
            this.unrecognized = true;
        }

        internal void MergeWithUnrecognizedGadget(GadgetSpec unrecognizedGadget)
        {
            // basically just grab it's URL, but check some things first!
            if (this.GetFileName() == unrecognizedGadget.GetFileName() && !this.unrecognized && unrecognizedGadget.unrecognized)
            {
                this.openSocialGadgetURL = unrecognizedGadget.openSocialGadgetURL;
                this.enabled = true;
            }
            else
            {
                throw new Exception("This merge is not allowed!");
            }
        }

        public int GetAppId()
        {
            return appId;
        }

        public string GetFileName()
        {
            return GetGadgetFileNameFromURL(GetGadgetURL());
        }

        public static string GetGadgetFileNameFromURL(string url)
        {
            string[] urlbits = url.ToString().Split('/');
            return urlbits[urlbits.Length - 1].Split('.')[0];
        }

        public String GetLabel()
        {
            return label;
        }

        public String GetGadgetURL()
        {
            return openSocialGadgetURL;
        }

        public GadgetViewRequirements GetGadgetViewRequirements(String page)
        {
            page = page.ToLower();
            if (viewRequirements.ContainsKey(page))
            {
                return viewRequirements[page];
            }
            return null;
        }

        // based on security and securityGroup settings, do we show this?
        public bool Show(string viewerUri, string ownerUri, String page)
        {
            // if it is a sandbox gadget with no match in the db, always show it because
            // this means a developer is trying to test things
            if (unrecognized)
            {
                return true;
            }
            page = page.ToLower();
            bool show = false;

            if (viewRequirements.ContainsKey(page))
            {
                GadgetViewRequirements req = GetGadgetViewRequirements(page);
                string visibility = req.GetVisiblity();
                if (OpenSocialManager.PUBLIC.Equals(visibility))
                {
                    show = true;
                }
                else if (OpenSocialManager.USERS.Equals(visibility) && viewerUri != null)
                {
                    show = true;
                }
                else if (OpenSocialManager.PRIVATE.Equals(visibility) && (viewerUri != null) && (viewerUri == ownerUri)) 
                {
                    show = true;
                }
            }
            return show;
        }

        public bool IsEnabled()
        {
            return enabled;
        }

        public bool Unrecognized()
        {
            return unrecognized;
        }

    }
}