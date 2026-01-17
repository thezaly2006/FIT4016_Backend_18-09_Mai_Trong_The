using System.ComponentModel.DataAnnotations;
using OrderManagementApp.Models;

namespace OrderManagementApp.ViewModels;

public class OrderFormViewModel
{
    public int? Id { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Customer Name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Customer Name must be between 2 and 100 characters")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Customer Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email format")]
    public string CustomerEmail { get; set; } = string.Empty;

    [Required(ErrorMessage = "Product is required")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Order Date is required")]
    public DateTime OrderDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public List<Product>? Products { get; set; }
}
