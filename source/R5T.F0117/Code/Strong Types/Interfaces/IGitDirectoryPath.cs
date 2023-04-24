using System;

using R5T.T0178;
using R5T.T0180;


namespace R5T.F0117
{
    /// <summary>
    /// The strong-type for git directory paths (i.e. ../.git/).
    /// </summary>
    [StrongTypeMarker]
    public interface IGitDirectoryPath : IStrongTypeMarker,
        IDirectoryPath
    {
    }
}
