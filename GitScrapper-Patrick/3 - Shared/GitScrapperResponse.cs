using GitScrapper_Patrick.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitScrapper_Patrick._3_Shared
{
    public class GitScrapperResponse
    {
        public string GroupedExtension;
        public int TotalLines;
        public float TotalBytes;
        public IGrouping<string, FileInfo> Files;



        public GitScrapperResponse(string extension, int lines, float bytes, IGrouping<string, FileInfo> files) 
        {
            this.GroupedExtension = extension;
            this.TotalLines = lines;
            this.TotalBytes = bytes;
            this.Files = files;
        }
    }
}
