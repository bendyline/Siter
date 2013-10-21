// ArticleSet.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BL.Site
{
    public class ContentSectionSet
    {
        public List<ContentSection> Sections;

        public ContentSectionSet()
        {
            this.Sections = new List<ContentSection>();
        }
    }
}
