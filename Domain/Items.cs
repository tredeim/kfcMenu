using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

[Table("items")]
public class Items
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("price")]
    public int Price { get; set; }
    
    [ForeignKey("category_id")]
    public Categories Categories { get; set; }
}