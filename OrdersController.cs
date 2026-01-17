using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Data;
using OrderManagementApp.Models;
using OrderManagementApp.ViewModels;

namespace OrderManagementApp.Controllers;

public class OrdersController : Controller
{
    private readonly OrderDbContext _context;

    public OrdersController(OrderDbContext context)
    {
        _context = context;
    }

    // ==========================
    // INDEX + SEARCH + PAGINATION
    // ==========================
    public async Task<IActionResult> Index(string? search, int page = 1)
    {
        int pageSize = 10;
        var query = _context.Orders
            .Include(o => o.Product)
            .AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(o =>
                o.OrderNumber.Contains(search) ||
                o.CustomerName.Contains(search));
        }

        int totalItems = await query.CountAsync();
        var orders = await query
            .OrderByDescending(o => o.OrderDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        ViewBag.Search = search;
        ViewBag.Page = page;
        ViewBag.TotalItems = totalItems;
        ViewBag.PageSize = pageSize;

        return View(orders);
    }

    // ==========================
    // CREATE
    // ==========================
    public IActionResult Create()
    {
        var vm = new OrderFormViewModel
        {
            Products = _context.Products.ToList(),
            OrderDate = DateTime.Now
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(OrderFormViewModel vm)
    {
        vm.Products = _context.Products.ToList();

        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        // Validate OrderDate <= Now
        if (vm.OrderDate > DateTime.Now)
        {
            ModelState.AddModelError("OrderDate", "Order Date cannot be greater than today");
            return View(vm);
        }

        // Validate Delivery Date >= Order Date
        if (vm.DeliveryDate.HasValue && vm.DeliveryDate < vm.OrderDate)
        {
            ModelState.AddModelError("DeliveryDate", "Delivery Date must be greater than or equal to Order Date");
            return View(vm);
        }

        // Validate Quantity <= stock
        var product = _context.Products.Find(vm.ProductId);
        if (product == null)
        {
            ModelState.AddModelError("ProductId", "Selected product does not exist");
            return View(vm);
        }

        if (vm.Quantity > product.StockQuantity)
        {
            ModelState.AddModelError("Quantity", $"Quantity cannot exceed product stock quantity ({product.StockQuantity})");
            return View(vm);
        }

        // Check unique email
        if (_context.Orders.Any(o => o.CustomerEmail == vm.CustomerEmail))
        {
            ModelState.AddModelError("CustomerEmail", "Customer Email must be unique");
            return View(vm);
        }

        // Generate OrderNumber
        var today = DateTime.Now;
        var count = _context.Orders.Count(o => o.OrderDate.Date == today.Date) + 1;
        vm.OrderNumber = $"ORD-{today:yyyyMMdd}-{count:D4}";

        // Check if OrderNumber is unique (though unlikely)
        while (_context.Orders.Any(o => o.OrderNumber == vm.OrderNumber))
        {
            count++;
            vm.OrderNumber = $"ORD-{today:yyyyMMdd}-{count:D4}";
        }

        var order = new Order
        {
            OrderNumber = vm.OrderNumber,
            CustomerName = vm.CustomerName,
            CustomerEmail = vm.CustomerEmail,
            ProductId = vm.ProductId,
            Quantity = vm.Quantity,
            OrderDate = vm.OrderDate,
            DeliveryDate = vm.DeliveryDate,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        _context.Orders.Add(order);
        _context.SaveChanges();

        TempData["Success"] = "Order created successfully!";
        return RedirectToAction(nameof(Index));
    }

    // ==========================
    // EDIT
    // ==========================
    public IActionResult Edit(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null) return NotFound();

        var vm = new OrderFormViewModel
        {
            Id = order.Id,
            OrderNumber = order.OrderNumber,
            CustomerName = order.CustomerName,
            CustomerEmail = order.CustomerEmail,
            ProductId = order.ProductId,
            Quantity = order.Quantity,
            OrderDate = order.OrderDate,
            DeliveryDate = order.DeliveryDate,
            Products = _context.Products.ToList()
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, OrderFormViewModel vm)
    {
        var order = _context.Orders.Include(o => o.Product).FirstOrDefault(o => o.Id == id);
        if (order == null) return NotFound();

        vm.Products = _context.Products.ToList();

        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        // Validate Delivery Date >= Order Date
        if (vm.DeliveryDate.HasValue && vm.DeliveryDate < order.OrderDate)
        {
            ModelState.AddModelError("DeliveryDate", "Delivery Date must be greater than or equal to Order Date");
            return View(vm);
        }

        // Validate Quantity <= stock
        if (order.Product == null)
        {
            ModelState.AddModelError("", "Product not found");
            return View(vm);
        }
        if (vm.Quantity > order.Product.StockQuantity)
        {
            ModelState.AddModelError("Quantity", $"Quantity cannot exceed product stock quantity ({order.Product.StockQuantity})");
            return View(vm);
        }

        // Check unique email (exclude current order)
        if (_context.Orders.Any(o => o.CustomerEmail == vm.CustomerEmail && o.Id != id))
        {
            ModelState.AddModelError("CustomerEmail", "Customer Email must be unique");
            return View(vm);
        }

        // Prevent editing OrderNumber & ProductId
        order.CustomerName = vm.CustomerName;
        order.CustomerEmail = vm.CustomerEmail;
        order.Quantity = vm.Quantity;
        order.DeliveryDate = vm.DeliveryDate;
        order.UpdatedAt = DateTime.Now;

        _context.SaveChanges();

        TempData["Success"] = "Order updated successfully!";
        return RedirectToAction(nameof(Index));
    }

    // ==========================
    // DELETE
    // ==========================
    public IActionResult Delete(int id)
    {
        var order = _context.Orders.Include(o => o.Product).FirstOrDefault(o => o.Id == id);
        if (order == null) return NotFound();

        return View(order);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null) return NotFound();

        _context.Orders.Remove(order);
        _context.SaveChanges();

        TempData["Success"] = "Order deleted successfully!";
        return RedirectToAction(nameof(Index));
    }
}
