using System;
using System.ComponentModel.DataAnnotations;
using R5T.T0132;
using R5T.T0180.Extensions;


namespace R5T.F0117.Construction
{
    [FunctionalityMarker]
    public partial interface IScripts : IFunctionalityMarker
    {
        /// <summary>
        /// Perform the initial pull.
        /// </summary>
        public void Pull_Initial()
        {
            var repositoryDirectoryPath =
                //@"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.T0180"
                @"C:\Code\DEV\Git\GitHub\SafetyCone\TestABC"
                ;

            Instances.GitOperator.Pull_Initial(
                repositoryDirectoryPath);
        }

        public void Add_RemoteOrigin()
        {
            var repositoryDirectoryPath =
                //@"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.T0180"
                @"C:\Code\DEV\Git\GitHub\SafetyCone\TestABC"
                ;

            var remoteRepositoryUrl = @"https://github.com/SafetyCone/R5T.T0180.git";

            Instances.GitOperator.Add_RemoteOrigin(
                repositoryDirectoryPath,
                remoteRepositoryUrl);
        }

        public void List_Branches()
        {
            var repositoryDirectoryPath =
                //@"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.T0180"
                @"C:\Code\DEV\Git\GitHub\SafetyCone\TestABC"
                ;

            Instances.GitOperator.List_Branches(repositoryDirectoryPath);
        }

        public void List_Remotes()
        {
            var repositoryDirectoryPath =
                //@"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.T0180"
                @"C:\Code\DEV\Git\GitHub\SafetyCone\TestABC"
                ;

            Instances.GitOperator.List_RemoteDirectories(repositoryDirectoryPath);
        }

        public void Initialize_GitRepository()
        {
            var repositoryDirectoryPath = @"C:\Code\DEV\Git\GitHub\SafetyCone\TestABC"
                .ToDirectoryPath();

            var gitDirectoryPath = Instances.GitOperator.Initialize_GitRepository(repositoryDirectoryPath);

            Console.WriteLine(gitDirectoryPath);
        }
    }
}
