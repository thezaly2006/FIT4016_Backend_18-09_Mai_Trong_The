using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Data;
using OrderManagementApp.Models;

namespace OrderManagementApp.Controllers;

public class HomeController : Controller
{
    private readonly OrderDbContext _context;

    public HomeController(OrderDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Lấy 10 đơn hàng mới nhất với sản phẩm liên quan
        var orders = await _context.Orders
            .Include(o => o.Product)
            .OrderByDescending(o => o.OrderDate)
            .Take(10)
            .ToListAsync();

        return View(orders);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
