using System;
using System.Collections.Generic;
using System.Linq;
using BL.UI;
using System.Runtime.CompilerServices;
using System.Html;

namespace BL.Site
{
    public class TwitterTimeline : Control
    {
        private String url;
        private String widgetId;
        private bool displayFooter = true;
        private bool displayHeader = true;
        private bool displayBorders = true;
        private bool displayScrollbar = true;
        private bool transparent = false;

        [ScriptName("b_transparent")]
        public bool Transparent
        {
            get
            {
                return this.transparent;
            }

            set
            {
                this.transparent = value;
            }
        }

        [ScriptName("b_displayScrollbar")]
        public bool DisplayScrollbar
        {
            get
            {
                return this.displayScrollbar;
            }

            set
            {
                this.displayScrollbar = value;
            }
        }

        [ScriptName("b_displayBorders")]
        public bool DisplayBorders
        {
            get
            {
                return this.displayBorders;
            }

            set
            {
                this.displayBorders = value;
            }
        }

        [ScriptName("b_displayHeader")]
        public bool DisplayHeader
        {
            get
            {
                return this.displayHeader;
            }

            set
            {
                this.displayHeader = value;
            }
        }

        [ScriptName("b_displayFooter")]
        public bool DisplayFooter
        {
            get
            {
                return this.displayFooter;
            }

            set
            {
                this.displayFooter = value;
            }
        }

        [ScriptName("e_timelineContainer")]
        private AnchorElement timelineContainer;

        [ScriptName("s_url")]
        public String Url
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
            }
        }

        [ScriptName("s_widgetId")]
        public String WidgetId
        {
            get
            {
                return this.widgetId;
            }

            set
            {
                this.widgetId = value;
            }
        }
        

        protected override void OnInit()
        {
            base.OnInit();

            InjectTwitterScript();
        }

        public static void InjectTwitterScript()
        {

            // script based on the twitter embed script
            //!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0];
            //if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src="//platform.twitter.com/widgets.js";fjs.parentNode.insertBefore(js,fjs);}}(document,"script","twitter-wjs");

            ScriptElement js = null;

            if (Document.GetElementById("twitter-wjs") == null)
            {
                Element fjs = Document.GetElementsByTagName("SCRIPT")[0];

                js = (ScriptElement)Document.CreateElement("SCRIPT");
                js.ID = "twitter-wjs";
                js.Src = "//platform.twitter.com/widgets.js";
                fjs.ParentNode.InsertBefore(js, fjs);
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (this.timelineContainer == null)
            {
                return;
            }

            if (this.url != null)
            {
                this.timelineContainer.Href = this.url;
            }

            if (this.widgetId != null)
            {
                this.timelineContainer.SetAttribute("data-widget-id", this.widgetId);
            }

            String options = String.Empty;

            if (!this.displayFooter)
            {
                options += " nofooter";
            }

            if (!this.displayHeader)
            {
                options += " noheader";
            }

            if (!this.displayBorders)
            {
                options += " noborders";
            }

            if (!this.displayScrollbar)
            {
                options += " noscrollbar";
            }

            if (this.transparent)
            {
                options += " transparent";
            }

            if (options.Length > 0)
            {
                this.timelineContainer.SetAttribute("data-chrome", options.TrimStart());
            }
        }
    }
}
