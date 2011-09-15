using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlLibrary
{
    public class XmlContentInfo
    {
        public List<ContentItem> Content;
    }
    public class ContentItem
    {
        public string Name;
        public string Path;
    }
}
