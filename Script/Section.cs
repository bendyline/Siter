using System;
using System.Collections.Generic;
using System.Linq;
using BL.UI;
using System.Runtime.CompilerServices;
using System.Html;

namespace BL.Site
{
    public class Section : Control
    {
        private ContentItem section;
        private String url;

        [ScriptName("e_title")]
        protected Element titleElement;

        [ScriptName("e_content")]
        protected Element contentElement;

        [ScriptName("e_titleLink")]
        protected AnchorElement titleLinkElement;

        [ScriptName("e_mainImage")]
        protected ImageElement mainImage;

        [ScriptName("c_slideshow")]
        protected Slideshow slideshow;

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
        public override string DefaultClass
        {
            get
            {
                return "row";
            }
        }

        public ContentItem ContentSection
        {
            get
            {
                return this.section; 
            }

            set
            {
                this.section = value;

                if (this.section.TemplateId != null)
                {
                    this.TemplateId = this.section.TemplateId;
                }

                this.Update();
            }
        }


        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (this.section == null)
            {
                return;
            }

            if (titleElement != null)
            {
                titleElement.InnerText = this.section.Title;
            }

            if (contentElement != null)
            {
                contentElement.InnerText = this.section.Content;
            }

            if (titleLinkElement != null)
            {
                if (this.url != null)
                {
                    titleLinkElement.Href = this.url;
                }
                else if (this.section.Url != null)
                {
                    titleLinkElement.Href = this.section.Url;
                }
            }

            if (mainImage != null)
            {
                if (this.section.MainImage == null)
                {
                    this.mainImage.Style.Display = "none";
                }
                else
                {
                    this.mainImage.Style.Display = "block";
                    mainImage.Src = this.section.MainImage;
                }
            }

            if (this.slideshow != null)
            {
                this.slideshow.Sections = (ContentItemSet)this.ContentSection.Data;
            }
        }

    }
}
