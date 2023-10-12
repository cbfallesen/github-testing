using Octokit;

var github = new GitHubClient(new ProductHeaderValue("github-testing"));
var user = await github.User.Get("cbfallesen");
Console.WriteLine(user.Followers + " folks love the half ogre!");