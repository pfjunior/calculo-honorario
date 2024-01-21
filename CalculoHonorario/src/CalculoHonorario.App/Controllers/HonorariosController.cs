using CalculoHonorario.App.Services;
using CalculoHonorario.App.ViewModels;
using CalculoHonorario.Business.Interfaces.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace CalculoHonorario.App.Controllers;

[Route("honorarios")]
public class HonorariosController : BaseController
{
    private readonly IApplicationService _service;

    public HonorariosController(INotificador notificador, IApplicationService service) : base(notificador)
    {
        _service = service;
    }


    public async Task<IActionResult> Index()
    {
        var results = await _service.ObterTodosAsync();

        if (results == null) return NotFound();

        return View(results);
    }

    [Route("detalhes/{id:guid}")]
    public async Task<IActionResult> Details(Guid id)
    {
        var viewModel = await _service.ObterPorIdAsync(id);

        if (viewModel == null) return NotFound();

        return View(viewModel);
    }

    [Route("novo")]
    public ActionResult Create()
    {
        return View();
    }

    [Route("novo")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AdicionarHonorarioViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        await _service.AdicionarAsync(viewModel);

        if (!OperacaoValida()) return View(viewModel);

        return RedirectToAction("Index");
    }

    [Route("excluir/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var viewModel = await _service.ObterPorIdAsync(id);

        if (viewModel == null) return NotFound();

        return View(viewModel);
    }

    [Route("excluir/{id:guid}")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var viewModel = await _service.ObterPorIdAsync(id);

        if (viewModel == null) return NotFound();

        await _service.RemoverAsync(id);

        if (!OperacaoValida()) return View(viewModel);

        TempData["Sucesso"] = "Honorário excluído com sucesso";

        return RedirectToAction("Index");
    }
}
