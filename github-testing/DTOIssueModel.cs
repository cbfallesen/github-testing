using System;
namespace github_testing
{
	public class DTOIssueModel
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public List<DTOAssigneeModel>? Assignees { get; set; }
		public List<DTOLabelModel>? Labels { get; set; }
		public int number { get; set; }
		public string Repository { get; set; }
		public string Owner { get; set; }
	}
}

