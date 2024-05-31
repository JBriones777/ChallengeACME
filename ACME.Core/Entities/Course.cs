namespace ACME.Core.Entities;

public class Course : BaseEntity
{
    public string Name { get; set; }
    public decimal RegistrationFee { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
