using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2entregaProjetoFinal.Models;

namespace _2entregaProjetoFinal.Controllers
{
    public class CadastrarUsuariosController : Controller
    {
        private readonly Context _context;

        public CadastrarUsuariosController(Context context)
        {
            _context = context;
        }

        // GET: CadastrarUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.usuarios.ToListAsync());
        }

        // GET: CadastrarUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarUsuario = await _context.usuarios
                .FirstOrDefaultAsync(m => m.Id_Usuario == id);
            if (cadastrarUsuario == null)
            {
                return NotFound();
            }

            return View(cadastrarUsuario);
        }

        // GET: CadastrarUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastrarUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Usuario,Nome,Nome_Social,Data_Nascimento,Email,Senha,Confirme_Senha")] CadastrarUsuario cadastrarUsuario)
        {
            _context.Add(cadastrarUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: CadastrarUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarUsuario = await _context.usuarios.FindAsync(id);
            if (cadastrarUsuario == null)
            {
                return NotFound();
            }
            return View(cadastrarUsuario);
        }

        // POST: CadastrarUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Usuario,Nome,Nome_Social,Data_Nascimento,Email,Senha,Confirme_Senha")] CadastrarUsuario cadastrarUsuario)
        {
            if (id != cadastrarUsuario.Id_Usuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastrarUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastrarUsuarioExists(cadastrarUsuario.Id_Usuario))
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
            return View(cadastrarUsuario);
        }

        // GET: CadastrarUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarUsuario = await _context.usuarios
                .FirstOrDefaultAsync(m => m.Id_Usuario == id);
            if (cadastrarUsuario == null)
            {
                return NotFound();
            }

            return View(cadastrarUsuario);
        }

        // POST: CadastrarUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastrarUsuario = await _context.usuarios.FindAsync(id);
            _context.usuarios.Remove(cadastrarUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastrarUsuarioExists(int id)
        {
            return _context.usuarios.Any(e => e.Id_Usuario == id);
        }
    }
}
