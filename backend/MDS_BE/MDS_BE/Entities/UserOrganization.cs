namespace MDS_BE.Entities
{
    public class UserOrganization
    {
        public string UserId { get; set; }
        public int OrganizationId { get; set; }

        public virtual User User { get; set; }
        public virtual Organization Organization { get; set; }
    }
}