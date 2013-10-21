// Slideshow.cs
//

using System;
using System.Collections.Generic;
using BL.UI;
using System.Runtime.CompilerServices;
using System.Html;

namespace BL.Site
{
    public class Slideshow : Control
    {
        [ScriptName("e_next")]
        protected Element nextElement;

        [ScriptName("e_previous")]
        protected Element previousElement;

        [ScriptName("c_presenter")]
        protected Section presenter;

        private int activeIndex = 0;
        private ContentSectionSet sections;

        public int ActiveIndex
        {
            get
            {
                return this.activeIndex;
            }

            set
            {
                this.activeIndex = value;

                this.Update();
            }
        }

        [ScriptName("o_sections")]
        public ContentSectionSet Sections
        {
            get
            {
                return this.sections;
            }

            set
            {
                this.sections = value;
                this.ActiveIndex = 0;


            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this.nextElement != null)
            {
                this.nextElement.AddEventListener("click", this.HandleNextButton, true);
            }
        }

        private void HandleNextButton(ElementEvent e)
        {
            this.Next();
        }

        public void Next()
        {
            if (this.activeIndex >= this.sections.Sections.Count)
            {
                this.ActiveIndex = 0;
            }
            else
            {
                this.ActiveIndex++;
            }
        }

        private void HandlePreviousButton(ElementEvent e)
        {
            this.Previous();
        }

        public void Previous()
        {
            if (this.activeIndex <= 0)
            {
                this.ActiveIndex = this.Sections.Sections.Count -1;
            }
            else
            {
                this.ActiveIndex--;
            }
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            if (this.Sections != null && this.presenter != null)
            {
                if (this.activeIndex >= 0 && this.activeIndex <= this.Sections.Sections.Count)
                {
                    this.presenter.ContentSection = this.Sections.Sections[this.activeIndex];
                }
            }
        }
    }
}
