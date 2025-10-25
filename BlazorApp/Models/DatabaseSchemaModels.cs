using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Geometry;

namespace BlazorApp.Models;

public class TableNode : NodeModel
{
    public string TableName { get; set; } = "NewTable";
    public List<TableField> Fields { get; set; } = new();

    public TableNode(Point? position = null) : base(position ?? new Point(0, 0))
    {
        AddPort(PortAlignment.Top);
        AddPort(PortAlignment.Bottom);
        AddPort(PortAlignment.Left);
        AddPort(PortAlignment.Right);
    }

    public void AddField(TableField field)
    {
        Fields.Add(field);
    }

    public void RemoveField(TableField field)
    {
        Fields.Remove(field);
    }
}

public class TableField
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = "VarChar";
    public bool IsPrimaryKey { get; set; }
    
    public TableField() { }
    
    public TableField(string name, string type, bool isPrimaryKey = false)
    {
        Name = name;
        Type = type;
        IsPrimaryKey = isPrimaryKey;
    }
}

public static class DatabaseFieldTypes
{
    public static readonly string[] Types = new[]
    {
        "Bit",
        "Char",
        "DateTime",
        "Decimal",
        "Float",
        "Integer",
        "Money",
        "Numeric",
        "Real",
        "SmallDateTime",
        "SmallInt",
        "SmallMoney",
        "TinyInt",
        "VarChar"
    };
}
