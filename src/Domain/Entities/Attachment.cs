using Domain.Commons;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entitiesrg;

public class Attachment : Auditable
{

    public string FileName { get; set; }
    public string FilePath { get; set; }
}
