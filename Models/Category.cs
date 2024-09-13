using System.ComponentModel.DataAnnotations.Schema;

namespace ContaineredSql.Models;

[Table("Category")]
public class Category
{
    public int Id { get; set; }
    public string Value { get; set; } = string.Empty;
}