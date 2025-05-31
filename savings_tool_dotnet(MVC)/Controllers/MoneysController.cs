using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using savings_tool_dotnet_MVC_.Models;
using savings_tool_dotnet_MVC_.Services;

namespace savings_tool_dotnet_MVC_.Controllers
{
    public class MoneysController : Controller
    {
        private readonly IServiceMoney serviceMoney;
        public MoneysController( IServiceMoney serviceMoney)
        {
            this.serviceMoney = serviceMoney;
        }

        // GET: Moneys
        public async Task<IActionResult> Index()
        {
            return View(await serviceMoney.ListMoney());
        }

        // GET: Moneys/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var money = await serviceMoney.FindMoney(id);
            if (money == null)
            {
                return NotFound();
            }

            return View(money);
        }

        // GET: Moneys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moneys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMoney,QuantityMoney,ValueMoney,Days,TotalValue")] Money money)
        {
            if (ModelState.IsValid)
            {
                await serviceMoney.AddMoney(money);
                return RedirectToAction(nameof(Index));
            }
            return View(money);
        }

        // GET: Moneys/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var money = await serviceMoney.FindMoney(id);
            if (money == null)
            {
                return NotFound();
            }
            return View(money);
        }

        // POST: Moneys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdMoney,QuantityMoney,ValueMoney,Days,TotalValue")] Money money)
        {
            if (id != money.IdMoney)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await serviceMoney.EditMoney(id, money.QuantityMoney, money.ValueMoney);
                return RedirectToAction(nameof(Index));
            }
            return View(money);
        }
    }
}
