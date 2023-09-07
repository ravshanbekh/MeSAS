using Domain.Commons;


namespace Domain.Entitiesrg;

public class Attachment : Auditable
{
    public string FileName { get; set; }
    public string FilePath { get; set; }
}
