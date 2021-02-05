using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BGF.App.Data;
using BGF.App.Models.Friends;
using BGF.App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BGF.App.Controllers
{
    [Authorize]
    public class FriendsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FriendsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var friendsService = new FriendsService(_context);
        //    var loggedInUsersFriendsList = await friendsService.GetUsersFriends(User.Identity.Name);

        //    return View(loggedInUsersFriendsList);
        //}

        //public async Task<IActionResult> Search(string query)
        //{
        //    var friendsService = new FriendsService(_context);
        //    var result = await friendsService.Search(query);

        //    return View(result);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Add()
        //{
        //    var addFriendModel = new AddFriendModel();

        //    return View(addFriendModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(AddFriendModel model)
        //{
        //    var friendsService = new FriendsService(_context);
        //    await friendsService.AddFriend(User.Identity.Name, model.FriendId);

        //    return RedirectToAction("Index");
        //}
    }
}
