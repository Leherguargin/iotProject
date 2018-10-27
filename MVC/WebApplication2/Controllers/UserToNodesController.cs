using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.model;

namespace WebApplication2.Controllers
{
    public class UserToNodesController : Controller
    {
        private readonly UserToNodesContext _context;

        public UserToNodesController(UserToNodesContext context)
        {
            _context = context;
        }

        // GET: UserToNodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserToNode.ToListAsync());
        }

        // GET: UserToNodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToNode = await _context.UserToNode
                .FirstOrDefaultAsync(m => m.UserSensorID == id);
            if (userToNode == null)
            {
                return NotFound();
            }

            return View(userToNode);
        }

        // GET: UserToNodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserToNodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserSensorID,UserID,NodeID,Authorizations")] UserToNode userToNode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userToNode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userToNode);
        }

        // GET: UserToNodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToNode = await _context.UserToNode.FindAsync(id);
            if (userToNode == null)
            {
                return NotFound();
            }
            return View(userToNode);
        }

        // POST: UserToNodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserSensorID,UserID,NodeID,Authorizations")] UserToNode userToNode)
        {
            if (id != userToNode.UserSensorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userToNode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserToNodeExists(userToNode.UserSensorID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userToNode);
        }

        // GET: UserToNodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToNode = await _context.UserToNode
                .FirstOrDefaultAsync(m => m.UserSensorID == id);
            if (userToNode == null)
            {
                return NotFound();
            }

            return View(userToNode);
        }

        // POST: UserToNodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userToNode = await _context.UserToNode.FindAsync(id);
            _context.UserToNode.Remove(userToNode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserToNodeExists(int id)
        {
            return _context.UserToNode.Any(e => e.UserSensorID == id);
        }
    }
}
