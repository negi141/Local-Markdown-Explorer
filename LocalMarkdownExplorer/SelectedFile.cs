using System;

namespace LocalMarkdownExplorer
{
    class SelectedFile
    {
        public bool isDirectory { get; set; }
        public string fileName { get; set; }
        public string fullPath { get; set; }
        public string extension { get; set; }

        public SelectedFile(bool isDirectory, string fileName, string fullPath, string extension)
        {
            this.isDirectory = isDirectory;
            this.fileName = fileName;
            this.fullPath = fullPath;
            this.extension = extension;
        }
    }
}
