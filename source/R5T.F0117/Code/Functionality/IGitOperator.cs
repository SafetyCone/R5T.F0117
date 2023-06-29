using System;
using System.Linq;

using LibGit2Sharp;

using R5T.T0132;
using R5T.T0180;

using R5T.F0117.Extensions;


namespace R5T.F0117
{
    [FunctionalityMarker]
    public partial interface IGitOperator : IFunctionalityMarker
    {
        public void Pull_Initial(string repositoryDirectoryPath)
        {
            using var repository = new Repository(repositoryDirectoryPath);

            Commands.Fetch(
                repository,
                "origin",
                new[]
                {
                    "main:refs/remotes/origin/main"
                    //"refs/remotes/origin/main"
                },
                new FetchOptions
                {
                    TagFetchMode = TagFetchMode.None,
                },
                "Test");

            var remoteBranch = repository.Branches["origin/main"];

            var localBranch = repository.CreateBranch(
                "main",
                remoteBranch.Tip);

            repository.Branches.Update(
                localBranch,
                b => b.TrackedBranch = remoteBranch.CanonicalName);

            Commands.Checkout(
                repository,
                localBranch);

            var result = Commands.Pull(
                repository,
                new Signature("d", "d@g.com", DateTimeOffset.Now),
                new PullOptions());
        }

        public void Add_RemoteOrigin(
            string repositoryDirectoryPath,
            string remoteRepositoryUrl)
        {
            using var repository = new Repository(repositoryDirectoryPath);

            repository.Network.Remotes.Add("origin", remoteRepositoryUrl);
        }

        public void List_Branches(string repositoryDirectoryPath)
        {
            using var repository = new Repository(repositoryDirectoryPath);

            Console.WriteLine($"{repository.Branches.Count()}: count of branches");

            foreach (var branch in repository.Branches)
            {
                Console.WriteLine($"{branch.FriendlyName}:{branch.RemoteName}");
            }
        }

        public void List_RemoteDirectories(string repositoryDirectoryPath)
        {
            using var repository = new Repository(repositoryDirectoryPath);

            Console.WriteLine($"{repository.Network.Remotes.Count()}: count of remotes");

            //Repository.
            
            foreach (var remote in repository.Network.Remotes)
            {
                Console.WriteLine($"{remote.Name}:{remote.Url}");
            }
        }

        /// <summary>
        /// Initialize a Git repository in the given directory path.
        /// It will:
        /// * Create the repository directory path (if it does not exist).
        /// * Create a .git sub-directory such that the directory will now be a Git repository.
        /// </summary>
        /// <param name="repositoryDirectoryPath">The directory that you want to be turned into a Git repository.</param>
        /// <returns>The .git directory path within the input directory path.</returns>
        public IGitDirectoryPath Initialize_GitRepository(IDirectoryPath repositoryDirectoryPath)
        {
            var output = Repository.Init(repositoryDirectoryPath.Value)
                .ToGitDirectoryPath();

            return output;
        }

        /// <summary>
        /// Initialize a bare Git repository in the given directory path.
        /// What is a bare repository? See <see href="https://www.theserverside.com/blog/Coffee-Talk-Java-News-Stories-and-Opinions/What-is-a-bare-git-repository"/>
        /// </summary>
        /// <inheritdoc cref="Initialize_GitRepository(IDirectoryPath)" path="/param[@name='repositoryDirectoryPath']"/>
        /// <inheritdoc cref="Initialize_GitRepository(IDirectoryPath)" path="/returns"/>
        public IGitDirectoryPath Initialize_GitRepository_Bare(IDirectoryPath repositoryDirectoryPath)
        {
            var output = Repository.Init(repositoryDirectoryPath.Value, true)
                .ToGitDirectoryPath();

            return output;
        }
    }
}
