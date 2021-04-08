using GitScrapper_Patrick.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitScrapper_Patrick._2_Domain
{
    public interface IGitScrapperRepository
    {
        public List<FileInfo> ScrapGitHubUrl(string url);
    }
}
