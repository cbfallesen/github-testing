using Octokit;

var github = new GitHubClient(new ProductHeaderValue("github-testing"));

var tokenAuth = new Credentials("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");
github.Credentials = tokenAuth;

var user = await github.User.Get("cbfallesen");

var labelFilter = new RepositoryIssueRequest
{
    Labels = {"Frankly Juice"},
    Filter = IssueFilter.All
};

var issues = await github.Issue.GetAllForRepository("cfallesen", "ComidaQS", labelFilter);

foreach (var issue in issues)
{
    Console.WriteLine(issue.Title);
}

Console.WriteLine();

//var createIssue = new NewIssue("Nyt issue fra backend");
//var newIssue = await github.Issue.Create("cfallesen", "ComidaQS", createIssue);

//var newIssues = await github.Issue.GetAllForRepository("cfallesen", "ComidaQS");

//foreach (var issue in newIssues)
//{
//    Console.WriteLine(issue.Title);
//}

//Console.WriteLine();

var getIssue = await github.Issue.Get("cfallesen", "ComidaQS", 713);

Console.WriteLine(getIssue.Title);

var update = getIssue.ToUpdate();

update.AddLabel("Frankly Juice");

update.AddAssignee("cbfallesen");

update.Body = "Her er en ny beskrivelse";

update.Title = "Og en ny title";

await github.Issue.Update("cfallesen", "ComidaQS", 713, update);

Console.WriteLine();

foreach (var label in update.Labels)
{
    Console.WriteLine(label);
}

foreach (var assignee in update.Assignees)
{
    Console.WriteLine(assignee);
}