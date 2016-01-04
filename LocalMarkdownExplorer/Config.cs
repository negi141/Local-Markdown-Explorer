using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalMarkdownExplorer
{
    class Config : Util.IniFile
    {
        public Config() : base("config.ini")
        {
        }

        public string PathType
        {
            get { return this.Data("PathType"); }
            set { this.data["PathType"] = value; }
        }

        public string AbsolutePath
        {
            get { return this.Data("AbsolutePath"); }
            set { this.data["AbsolutePath"] = value; }
        }

        public string RelativePath
        {
            get { return this.Data("RelativePath"); }
            set { this.data["RelativePath"] = value; }
        }

        public string FileEncode
        {
            get { return this.Data("FileEncode"); }
            set { this.data["FileEncode"] = value; }
        }

        public string ExtensionText
        {
            get { return this.Data("ExtensionText"); }
            set { this.data["ExtensionText"] = value; }
        }

        public string ExtensionIgnore
        {
            get { return this.Data("ExtensionIgnore"); }
            set { this.data["ExtensionIgnore"] = value; }
        }

    }
}
