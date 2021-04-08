using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitScrapper_Patrick._3_Shared
{
    public static class Response
    {
        public static string Empty { get => "Sorry, but input is Empty"; }
        public static string NotFound { get => "Sorry, this repository not found in GitHub"; }
        public static string InternalError { get => "Sorry, an internal error has occurred"; }
    }
}
