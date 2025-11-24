using FirmaAdvocacia.Data;
using FirmaAdvocacia.Models;
using FirmaAdvocacia.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaAdvocacia.Controllers
{
    public class ProcessoController : Controller
    {
        private readonly FirmaContext _context;

        public ProcessoController(FirmaContext context)
        {
            _context = context;
        }

        // GET: Processo
        public async Task<IActionResult> Index()
        {
            var processos = _context.Processos
                .Include(p => p.ClientesProcessos)
                .ThenInclude(cp => cp.ClienteOrigem);
            return View(await processos.ToListAsync());
        }

        // GET: Processo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processos
                .Include(p => p.ClientesProcessos)
                .ThenInclude(cp => cp.ClienteOrigem)
                .FirstOrDefaultAsync(m => m.ProcessoId == id);

            if (processo == null)
            {
                return NotFound();
            }

            return View(processo);
        }

        // GET: Processo/Create
        public IActionResult Create()
        {
            var vm = new ProcessoViewModel
            {
                ListaCliente = _context.Clientes
            .Select(c => new SelectListItem
            {
                Value = c.ClienteId.ToString(),
                Text = c.Nome
            }).ToList()
            };

            return View(vm);
        }

        // POST: Processo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProcessoViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Processos.Add(vm.Processo);
                await _context.SaveChangesAsync();

                foreach (var id in vm.ClientesSelecionados)
                {
                    _context.ClientesProcessos.Add(new ClienteProcesso
                    {
                        ClienteId = id,
                        ProcessoId = vm.Processo.ProcessoId
                    });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            vm.ListaCliente = _context.Clientes
                .Select(c => new SelectListItem
                {
                    Value = c.ClienteId.ToString(),
                    Text = c.Nome
                })
                .ToList();

            return View(vm);
        }

        // GET: Processo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var processo = await _context.Processos
                .Include(p => p.ClientesProcessos)
                .FirstOrDefaultAsync(p => p.ProcessoId == id);

            if (processo == null) return NotFound();

            var vm = new ProcessoViewModel
            {
                Processo = processo,
                ClientesSelecionados = processo.ClientesProcessos
                    .Select(cp => cp.ClienteId)
                    .ToList(),
                ListaCliente = _context.Clientes
                    .Select(c => new SelectListItem
                    {
                        Value = c.ClienteId.ToString(),
                        Text = c.Nome
                    })
                    .ToList()
            };

            return View(vm);
        }


        // POST: Processo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProcessoViewModel vm)
        {
            if (id != vm.Processo.ProcessoId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(vm.Processo);
                await _context.SaveChangesAsync();

                var antigos = _context.ClientesProcessos
                    .Where(cp => cp.ProcessoId == id);

                _context.ClientesProcessos.RemoveRange(antigos);
                await _context.SaveChangesAsync();

                foreach (var cliId in vm.ClientesSelecionados)
                {
                    _context.ClientesProcessos.Add(new ClienteProcesso
                    {
                        ClienteId = cliId,
                        ProcessoId = vm.Processo.ProcessoId
                    });
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            vm.ListaCliente = _context.Clientes
                .Select(c => new SelectListItem
                {
                    Value = c.ClienteId.ToString(),
                    Text = c.Nome
                })
                .ToList();

            return View(vm);
        }


        // GET: Processo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _context.Processos
                .Include(p => p.ClientesProcessos)
                .ThenInclude(cp => cp.ClienteOrigem)
                .FirstOrDefaultAsync(m => m.ProcessoId == id);
            if (processo == null)
            {
                return NotFound();
            }

            return View(processo);
        }

        // POST: Processo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processo = await _context.Processos.FindAsync(id);

            if (processo != null)
            {
                // remove relações N-N antes
                var relacoes = _context.ClientesProcessos.Where(cp => cp.ProcessoId == id);
                _context.ClientesProcessos.RemoveRange(relacoes);

                _context.Processos.Remove(processo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessoExists(int id)
        {
            return _context.Processos.Any(e => e.ProcessoId == id);
        }
    }
}
