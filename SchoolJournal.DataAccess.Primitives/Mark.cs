using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolJournal.DataAccess.Primitives;

[NotMapped]
public class Mark
{
    private int? _value;

    public int? Value
    {
        get => _value;
        set
        {
            if (IsPresent) _value = value;
        }
    }

    public bool IsPresent { get; set; }
}