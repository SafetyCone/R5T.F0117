using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.F0117
{
    /// <inheritdoc cref="IGitDirectoryPath"/>
    [StrongTypeImplementationMarker]
    public class GitDirectoryPath : TypedBase<string>, IStrongTypeImplementationMarker,
        IGitDirectoryPath
    {
        public GitDirectoryPath(string value)
            : base(value)
        {
        }
    }
}
