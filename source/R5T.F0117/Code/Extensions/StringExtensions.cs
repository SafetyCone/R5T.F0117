using System;


namespace R5T.F0117.Extensions
{
    public static class StringExtensions
    {
        public static GitDirectoryPath ToGitDirectoryPath(this string value)
        {
            var output = Instances.StringOperator.ToGitDirectoryPath(value);
            return output;
        }
    }
}
