using SolutionCore.Models;

namespace SolutionCore.Builders
{
    class UpdateIssueBuilder
    {
        public string _customfield_10102 = "DEMO-33";
        
        public UpdateIssue Build()
        {
            return new UpdateIssue
            {
                fields = new UpdateFields
                {
                    customfield_10102 = _customfield_10102
                }
            };
        }
        
        public UpdateIssueBuilder WithIssueToUpdate(string issueToUpdate)
        {
            _customfield_10102 = issueToUpdate;
            return this;
        }
    }
}
