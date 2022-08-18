﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly UserManager<IdentityUser> _userManager;

    [BindProperty]
    public List<SelectListItem> Users { get; set; }

    [BindProperty]
    public string MyUser { get; set; }
    public IndexModel(ILogger<IndexModel> logger, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public void OnGet()
    {
        Users = _userManager.Users.ToList()
            .Select(a => new SelectListItem { Text = a.UserName, Value = a.UserName })
            .OrderBy(s => s.Text).ToList();

        MyUser = User.Identity.Name;

    }
}