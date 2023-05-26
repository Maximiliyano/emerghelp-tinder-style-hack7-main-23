namespace Web.Common.BaseEntities;

public record BaseRecord
{
    private readonly DateTime _createdAt;

    protected BaseRecord()
    {
        CreatedAt = UpdatedAt = DateTime.Now;
    }

    public int Id { get; set; }

    public DateTime CreatedAt
    {
        get => _createdAt;
        init => _createdAt = (value == DateTime.MinValue) ? DateTime.Now : value;
    }

    public DateTime UpdatedAt { get; set; }
}