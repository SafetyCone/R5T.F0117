using System;

using R5T.T0132;


namespace R5T.F0117
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        public GitDirectoryPath ToGitDirectoryPath(string value)
        {
            var output = new GitDirectoryPath(value);
            return output;
        }
    }
}
