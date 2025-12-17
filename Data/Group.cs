using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarWebApp.Data
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int? OrganisationId { get; set; }
        public virtual Organisation? Organisation { get; set; }

        public string? GroupLeaderId { get; set; }

        [ForeignKey("GroupLeaderId")]
        public ApplicationUser? GroupLeader { get; set; }
        public bool IsLogicalGroup => OrganisationId == null;

        public virtual ICollection<ApplicationUser> HierarchicalMembers { get; set; } = new List<ApplicationUser>();
        public virtual ICollection<ApplicationUser> LogicalMembers { get; set; } = new List<ApplicationUser>();
    }
}
