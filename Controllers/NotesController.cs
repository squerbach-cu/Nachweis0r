using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nachweis0r.Data;
using Nachweis0r.Models;

namespace Nachweis0r.Controllers;

[Authorize]
public class NotesController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _autoMapper;

    public NotesController(ApplicationDbContext db, SignInManager<User> signInManager,
        UserManager<User> userManager, IMapper autoMapper)
    {
        _db = db;
        _signInManager = signInManager;
        _userManager = userManager;
        _autoMapper = autoMapper;
    }

    public IActionResult Index()
    {
        IEnumerable<NotesModel> notesList = _db.Notes.Where(n => n.UserId == _userManager.GetUserId(User)).OrderBy(n => n.Title);
        return View(notesList);
    }

    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    public IActionResult Create(NotesViewModel obj)
    {
        var notesModel = new NotesModel();
        notesModel = _autoMapper.Map<NotesModel>(obj);

        notesModel.UserId = _userManager.GetUserId(User);
        _db.Notes.Add(notesModel);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var notesFromDb = _db.Notes.Find(id);

        if (notesFromDb == null &&
            notesFromDb.UserId != _userManager.GetUserId(User))
        {
            return NotFound();
        }

        NotesViewModel notesViewModel = _autoMapper.Map<NotesViewModel>(notesFromDb);

        return View(notesViewModel);
    }

    //POST
    [HttpPost]
    public IActionResult Edit(NotesViewModel notesViewModel)
    {
        var notesModel = _db.Notes.Find(notesViewModel.Id);
        if (notesModel != null)
            _autoMapper.Map(notesViewModel, notesModel);
        // _db.Notes.Update(notesModel);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    //GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var notesFromDb = _db.Notes.Find(id);

        if (notesFromDb == null &&
            notesFromDb.UserId != _userManager.GetUserId(User))
        {
            return NotFound();
        }

        NotesViewModel viewModel = _autoMapper.Map<NotesViewModel>(notesFromDb);
        return View(viewModel);
    }

    //POST
    [HttpPost]
    public IActionResult Delete(NotesViewModel notesViewModel)
    {
        var notesModel = _autoMapper.Map<NotesModel>(notesViewModel);
        _db.Notes.Remove(notesModel);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}