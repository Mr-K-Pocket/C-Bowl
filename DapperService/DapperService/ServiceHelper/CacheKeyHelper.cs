namespace DapperService.ServiceHelper
{
    public static class CacheKeyHelper
    {
        private static string allSuffix = "|All";
        public static string GetAllCacheKey(string rootKey)
        {
            return rootKey + allSuffix;
        }
    }
}
