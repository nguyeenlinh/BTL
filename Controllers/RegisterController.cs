using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTL_NET2.Data;
using BTL_NET2.Models;

namespace BTL_NET2.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
            return _context.Registers != null ?
                        View(await _context.Registers.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Registers'  is null.");
        }

        // GET: Register/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.RegisterID == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegisterID,RegisterName,RegisterMK")] Register register)
        {
            if (ModelState.IsValid)
            {
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: Register/Edit/5
        // public async Task<IActionResult> Edit(string id)
        // {
        //     if (id == null || _context.Registers == null)
        //     {
        //         return NotFound();
        //     }

        //     var register = await _context.Registers.FindAsync(id);
        //     if (register == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(register);
        // }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(string id, [Bind("RegisterID,RegisterName,RegisterMK")] Register register)
        // {
        //     if (id != register.RegisterID)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(register);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!RegisterExists(register.RegisterID))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(register);
        // }

        // GET: Register/Delete/5
        // public async Task<IActionResult> Delete(string id)
        // {
        //     if (id == null || _context.Registers == null)
        //     {
        //         return NotFound();
        //     }

        //     var register = await _context.Registers
        //         .FirstOrDefaultAsync(m => m.RegisterID == id);
        //     if (register == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(register);
        // }

        // POST: Register/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(string id)
        // {
        //     if (_context.Registers == null)
        //     {
        //         return Problem("Entity set 'ApplicationDbContext.Registers'  is null.");
        //     }
        //     var register = await _context.Registers.FindAsync(id);
        //     if (register != null)
        //     {
        //         _context.Registers.Remove(register);
        //     }

        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool RegisterExists(string id)
        // {
        //   return (_context.Registers?.Any(e => e.RegisterID == id)).GetValueOrDefault();
        // }
    }
}
