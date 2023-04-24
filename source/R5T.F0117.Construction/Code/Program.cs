using System;


namespace R5T.F0117.Construction
{
    class Program
    {
        static void Main()
        {
            Scripts.Instance.Initialize_GitRepository();
            Scripts.Instance.Add_RemoteOrigin();
            //Scripts.Instance.List_Remotes();
            //Scripts.Instance.List_Branches();
            Scripts.Instance.Pull_Initial();
        }
    }
}