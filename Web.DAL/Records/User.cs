using Web.Common.BaseEntities;

namespace Web.DAL.Records;

public record User : BaseRecord
{
    public string Email { get; set; }
}