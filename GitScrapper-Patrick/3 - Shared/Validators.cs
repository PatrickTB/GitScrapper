using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitScrapper_Patrick._3_Shared
{
    public class Validators
    {
        public Validators()
        {

        }
        public bool isValidGithubUrl(string url)
        {
            return validURL(url) && url.StartsWith(Constants.GITHUB_URL_BASE);
        }

        private bool validURL(string url)
        {
            return url != null && !url.Trim().Equals("") && CheckURLValid(url);
        }

        private bool CheckURLValid(string strURL)
        {
            return Uri.IsWellFormedUriString(strURL, UriKind.RelativeOrAbsolute);
        }
    }
}
