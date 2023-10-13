using System;
using Octokit;

namespace github_testing
{
	public class GitHubService
	{
		public GitHubService()
		{
        }

        public async Task GetAllIssues(string owner, string repository, string token, RepositoryIssueRequest filter)
		{
            var github = new GitHubClient(new ProductHeaderValue(repository));

            var tokenAuth = new Credentials(token);
            github.Credentials = tokenAuth;

            var issues = await github.Issue.GetAllForRepository("cfallesen", "ComidaQS", filter);
            List<DTOIssueModel> list = new List<DTOIssueModel>();

            foreach (var issue in issues)
            {
                DTOIssueModel dTOIssue = new DTOIssueModel();

                dTOIssue.Title = issue.Title;
                dTOIssue.Repository = repository;
                dTOIssue.Owner = owner;
                dTOIssue.number = issue.Number;
                dTOIssue.Body = issue.Body;

                dTOIssue.Labels = new List<DTOLabelModel>();
                foreach(var label in issue.Labels)
                {
                    DTOLabelModel dTOLabel = new DTOLabelModel();

                    dTOLabel.Name = label.Name;
                    dTOLabel.Color = label.Color;
                    dTOLabel.Description = label.Description;
                    dTOLabel.Url = label.Url;

                    dTOIssue.Labels.Add(dTOLabel);
                }

                dTOIssue.Assignees = new List<DTOAssigneeModel>();
                foreach (var assignee in issue.Assignees)
                {
                    DTOAssigneeModel dTOAssignee = new DTOAssigneeModel();

                    dTOAssignee.Name = assignee.Name;
                    dTOAssignee.Email = assignee.Email;
                    dTOAssignee.Url = assignee.Url;

                    dTOIssue.Assignees.Add(dTOAssignee);
                }
            }

            return list;
        }
	}
}

