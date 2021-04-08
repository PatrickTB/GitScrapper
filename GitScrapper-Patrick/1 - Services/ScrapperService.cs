using GitScrapper_Patrick._1_Services;
using GitScrapper_Patrick._2_Domain;
using GitScrapper_Patrick._3_Shared;
using GitScrapper_Patrick.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GitScrapper_Patrick._1_Services
{
    public class ScrapperService: IScrapperService
    {
        public readonly IGitScrapperRepository _scrapperRepository;
        public ScrapperService(IGitScrapperRepository scrapperRepository)
        {
            _scrapperRepository = scrapperRepository;
        }
        public IEnumerable<GitScrapperResponse> GetGithubFilesGroupedByExtension(string url)
        {
            ValidateUrl(url);
            var allFiles = _scrapperRepository.ScrapGitHubUrl(url);
            var data = MapData(allFiles);
            return data;
        }
        private IList<GitScrapperResponse> MapData(IList<FileInfo> gitHubFiles)
        {
            var filesGrouped = gitHubFiles.GroupBy(f => f.Extension).ToList();
            var Grouped = new List<GitScrapperResponse>();

            int lines = 0;
            float bytes = 0;            

            for (int i = 0; i < filesGrouped.Count; i++)
            {
                lines = 0;
                bytes = 0;
                filesGrouped[i].ToList().ForEach(f => lines += f.Lines);
                filesGrouped[i].ToList().ForEach(f => bytes += f.Bytes);

                Grouped.Add(new GitScrapperResponse(filesGrouped[i].Key, lines, bytes, filesGrouped[i]));
            }
            return Grouped;
        }

        public void ValidateUrl(string url)
        {
            if(!url.StartsWith(Constants.GITHUB_URL_BASE) && Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                throw new Exception("Not a valid GitHub URL");
            }
        }
    }
}
