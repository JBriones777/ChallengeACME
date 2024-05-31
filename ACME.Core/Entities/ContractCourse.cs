namespace ACME.Core.Entities;

public class ContractCourse:BaseEntity
{
    public Guid StudentId { get; set; }
    public Student Student { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public decimal Amount { get; set; }
}
