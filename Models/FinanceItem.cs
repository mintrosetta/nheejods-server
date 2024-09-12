using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using nheejods.Enums;

namespace nheejods.Models;

[Table("finance_items")]
public class FinanceItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("box_id")]
    public int BoxId { get; set; }

    [Column("title")]
    public string title { get; set; } = string.Empty;

    [Column("amount")]
    public decimal amount { get; set; }

    [Column("type")]
    public FinanceType Type { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
