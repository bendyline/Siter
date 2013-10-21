// Class1.cs
//

using System;
using System.Collections.Generic;
using System.Html;
using jQueryApi;
using BL.UI;
using BL.Site;
using System.Runtime.CompilerServices;

namespace BL.Site
{
    public class SectionSetDisplay : ItemsControl
    {
        private ContentSectionSet sectionSet;
        private String sectionDataUrl = null;
        private bool retrieved;

        [ScriptName("u_sectionDataUrl")]
        public String SectionDataUrl
        {
            get
            {
                return this.sectionDataUrl;
            }

            set
            {
                this.sectionDataUrl = value;
                this.retrieved = false;

                this.Update();
            }
        }

        public ContentSectionSet ContentSectionSet
        {
            get
            {
                return sectionSet;
            }

            set
            {
                sectionSet = value;
                this.Update();
            }
        }

        protected override void OnUpdate()
        {
            if (this.sectionDataUrl != null && this.retrieved == false)
            {
                this.retrieved = true; 
                jQuery.GetJson(this.sectionDataUrl, new AjaxCallback<object>(this.SectionSetRetrieved));
            }

            if (this.ContentSectionSet != null)
            {
                Dictionary<String, Section> existingSections = new Dictionary<string, Section>();

                if (this.ItemControls != null)
                {
                    foreach (Section section in this.ItemControls)
                    {
                        existingSections[section.ContentSection.Id] = section;

                    }
                }

                foreach (ContentSection cs in this.ContentSectionSet.Sections)
                {
                    Section s = existingSections[cs.Id];

                    if (s == null)
                    {
                        s = new Section();

                        if (cs.TemplateId != null)
                        {
                            s.TemplateId = cs.TemplateId;
                        }

                        s.ContentSection = cs;
                    }

                    this.AddItemControl(s);
                }
            }
        }


        public void SectionSetRetrieved(object css)
        {
            ContentSectionSet[] contentSectionSets = (ContentSectionSet[])css;

            this.ContentSectionSet = contentSectionSets[0];
        }


    }
}
