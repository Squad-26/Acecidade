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
    public class CadastrarEstabelecimentoesController : Controller
    {
        private readonly Context _context;

        public CadastrarEstabelecimentoesController(Context context)
        {
            _context = context;
        }

        // GET: CadastrarEstabelecimentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.estabelecimentos.ToListAsync());
        }

        // GET: CadastrarEstabelecimentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarEstabelecimento = await _context.estabelecimentos
                .FirstOrDefaultAsync(m => m.IdEstabelecimento == id);
            if (cadastrarEstabelecimento == null)
            {
                return NotFound();
            }

            return View(cadastrarEstabelecimento);
        }

        // GET: CadastrarEstabelecimentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastrarEstabelecimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstabelecimento,NomeEstabelecimento,NotaEstabelecimento,HorarioFuncionamento,ComentariosEstabelecimento,AcessibilidadesEstabelecimentos")] CadastrarEstabelecimento cadastrarEstabelecimento)
        {
            _context.Add(cadastrarEstabelecimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: CadastrarEstabelecimentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarEstabelecimento = await _context.estabelecimentos.FindAsync(id);
            if (cadastrarEstabelecimento == null)
            {
                return NotFound();
            }
            return View(cadastrarEstabelecimento);
        }

        // POST: CadastrarEstabelecimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstabelecimento,NomeEstabelecimento,NotaEstabelecimento,HorarioFuncionamento,ComentariosEstabelecimento,AcessibilidadesEstabelecimentos")] CadastrarEstabelecimento cadastrarEstabelecimento)
        {
            if (id != cadastrarEstabelecimento.IdEstabelecimento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastrarEstabelecimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastrarEstabelecimentoExists(cadastrarEstabelecimento.IdEstabelecimento))
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
            return View(cadastrarEstabelecimento);
        }

        // GET: CadastrarEstabelecimentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastrarEstabelecimento = await _context.estabelecimentos
                .FirstOrDefaultAsync(m => m.IdEstabelecimento == id);
            if (cadastrarEstabelecimento == null)
            {
                return NotFound();
            }

            return View(cadastrarEstabelecimento);
        }

        // POST: CadastrarEstabelecimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastrarEstabelecimento = await _context.estabelecimentos.FindAsync(id);
            _context.estabelecimentos.Remove(cadastrarEstabelecimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastrarEstabelecimentoExists(int id)
        {
            return _context.estabelecimentos.Any(e => e.IdEstabelecimento == id);
        }
    }
}
