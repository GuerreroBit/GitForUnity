using System;
using System.IO;
using System.Linq;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using UnityEngine;

public static class GitManager {
    public static void Setup(string repoUrl, string user = null, string pass = null) {
        string projectDirectory = Directory.GetParent(Application.dataPath)?.ToString();

        ResetAll(projectDirectory); //TODO Remove this

        InitLocalRepository(projectDirectory);
        InitRemoteRepository(repoUrl, projectDirectory);
        PushToRemote(user, pass, projectDirectory);
    }

    private static void ResetAll(string projectDirectory) {
        using (Repository repo = new(projectDirectory)) {
            repo.Index.Clear();
            Signature author = new("Git for Unity", "https://github.com/GuerreroBit/GitForUnity", DateTime.Now);
            Signature committer = author;
            repo.Commit("Reset Repository", author, committer);
        }
        /*string gitDirectory = Path.Combine(projectDirectory, ".git");
        if (Directory.Exists(gitDirectory)) {
            Directory.Delete(gitDirectory, true);
        }*/
    }

    private static void InitRemoteRepository(string repoUrl, string projectDirectory) {
        using (Repository repo = new(projectDirectory)) {
            if (!repo.Network.Remotes.Any()) repo.Network.Remotes.Add("origin", repoUrl);
        }
    }

    private static void PushToRemote(string user, string pass, string projectDirectory) {
        using (Repository repo = new(projectDirectory)) {
            /*PullOptions pullOptions = new() {
                FetchOptions = new FetchOptions {
                    CredentialsProvider = (_, _, _) =>
                        new UsernamePasswordCredentials {
                            Username = user,
                            Password = pass
                        }
                }
            };

            // User information to create a merge commit
            var signature = new Signature("Git for Unity", "https://github.com/GuerreroBit/GitForUnity",
                                          DateTimeOffset.Now);

            // Pull
            Commands.Pull(repo, signature, pullOptions);*/

            var remote = repo.Network.Remotes["origin"];
            PushOptions options = new() {
                CredentialsProvider = (_, _, _) =>
                    new UsernamePasswordCredentials {
                        Username = user,
                        Password = pass
                    }
            };
            repo.Network.Push(remote, @"+refs/heads/master", options);
        }
    }

    private static void InitLocalRepository(string projectDirectory) {
        GitIgnore.CreteDefaultGitIgnore(projectDirectory);
        Repository.Init(projectDirectory);
        using (Repository repo = new(projectDirectory)) {
            Commands.Stage(repo, "*");
        }
        InitialCommit(projectDirectory);
    }

    private static void InitialCommit(string projectDirectory) {
        using (Repository repo = new(projectDirectory)) {
            Signature author = new("Git for Unity", "gitforunity@gmail.com", DateTime.Now);
            Signature committer = author;
            repo.Commit("Initial commit", author, committer, new CommitOptions {
                PrettifyMessage = true
            });
        }
    }
}