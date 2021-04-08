using GitScrapper_Patrick._3_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitScrapper_Patrick._1_Services
{
    public interface IScrapperService
    {
        public IEnumerable<GitScrapperResponse> GetGithubFilesGroupedByExtension(string url);
    }
}
