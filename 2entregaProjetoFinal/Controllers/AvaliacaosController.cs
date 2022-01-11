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
    public class AvaliacaosController : Controller
    {
        private readonly Context _context;

        public AvaliacaosController(Context context)
        {
            _context = context;
        }

        // GET: Avaliacaos
        public async Task<IActionResult> Index()
        {
            var context = _context.avaliacoes.Include(a => a.CadastrarEstabelecimento).Include(a => a.CadastrarUsuario);
            return View(await context.ToListAsync());
        }

        // GET: Avaliacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.avaliacoes
                .Include(a => a.CadastrarEstabelecimento)
                .Include(a => a.CadastrarUsuario)
                .FirstOrDefaultAsync(m => m.IdAvaliacao == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // GET: Avaliacaos/Create
        public IActionResult Create()
        {
            ViewData["IdEstabelecimento"] = new SelectList(_context.estabelecimentos, "IdEstabelecimento", "IdEstabelecimento");
            ViewData["IdUsuario"] = new SelectList(_context.usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Avaliacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAvaliacao,IdUsuario,IdEstabelecimento,NotaEstabelecimento,Comentario")] Avaliacao avaliacao)
        {
           
            _context.Add(avaliacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            ViewData["IdEstabelecimento"] = new SelectList(_context.estabelecimentos, "IdEstabelecimento", "IdEstabelecimento", avaliacao.IdEstabelecimento);
            ViewData["IdUsuario"] = new SelectList(_context.usuarios, "IdUsuario", "IdUsuario", avaliacao.IdUsuario);
    
        }

        // GET: Avaliacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            ViewData["IdEstabelecimento"] = new SelectList(_context.estabelecimentos, "IdEstabelecimento", "IdEstabelecimento", avaliacao.IdEstabelecimento);
            ViewData["IdUsuario"] = new SelectList(_context.usuarios, "IdUsuario", "IdUsuario", avaliacao.IdUsuario);
            return View(avaliacao);
        }

        // POST: Avaliacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAvaliacao,IdUsuario,IdEstabelecimento,NotaEstabelecimento,Comentario")] Avaliacao avaliacao)
        {
            if (id != avaliacao.IdAvaliacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoExists(avaliacao.IdAvaliacao))
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
            ViewData["IdEstabelecimento"] = new SelectList(_context.estabelecimentos, "IdEstabelecimento", "IdEstabelecimento", avaliacao.IdEstabelecimento);
            ViewData["IdUsuario"] = new SelectList(_context.usuarios, "IdUsuario", "IdUsuario", avaliacao.IdUsuario);
            return View(avaliacao);
        }

        // GET: Avaliacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _context.avaliacoes
                .Include(a => a.CadastrarEstabelecimento)
                .Include(a => a.CadastrarUsuario)
                .FirstOrDefaultAsync(m => m.IdAvaliacao == id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            return View(avaliacao);
        }

        // POST: Avaliacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avaliacao = await _context.avaliacoes.FindAsync(id);
            _context.avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliacaoExists(int id)
        {
            return _context.avaliacoes.Any(e => e.IdAvaliacao == id);
        }
    }
}
