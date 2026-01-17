using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OrderManagementApp.ValidationAttributes;

namespace OrderManagementApp.Models;

public class Order : IValidatableObject
{
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product? Product { get; set; }

    [Required]
    [MaxLength(255)]
    [OrderNumberFormat]
    public string OrderNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string CustomerName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string CustomerEmail { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    [OrderDateValidation]
    public DateTime OrderDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [NotMapped]
    public string Status => DeliveryDate.HasValue ? "Delivered" : "Pending";

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (DeliveryDate.HasValue && DeliveryDate.Value < OrderDate)
        {
            yield return new ValidationResult("Delivery Date must be on or after Order Date", new[] { nameof(DeliveryDate) });
        }
    }
}
