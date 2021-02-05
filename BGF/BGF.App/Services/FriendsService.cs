using BGF.App.Data;
using BGF.App.Models.Friends;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGF.App.Services
{
    public class FriendsService
    {
        private readonly ApplicationDbContext _context;

        public FriendsService(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<List<FriendVM>> GetUsersFriends(string username)
        //{
        //    var userWithFriends = _context.Users.Include(u => u.Friends).SingleOrDefault(u => u.UserName == username);

        //    var friendVmList = new List<FriendVM>();
        //    foreach (var friend in userWithFriends.Friends)
        //    {
        //        friendVmList.Add(new FriendVM
        //        {
        //            Id = friend.Id,
        //            FirstName = friend.FirstName,
        //            LastName = friend.LastName,
        //            City = friend.City
        //        });
        //    }

        //    return friendVmList;
        //}

        public async Task<List<SearchFriendsResults>> Search(string query)
        {
            var searchResults = _context.Users.Where(e =>
                    e.FirstName.ToLower().Contains(query.ToLower()) ||
                    e.LastName.ToLower().Contains(query.ToLower()) ||
                    e.City.ToLower().Contains(query.ToLower()))
                .Select(e => new SearchFriendsResults
                {
                    UserId = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    City = e.City
                });

            return searchResults.ToList();
        }

        //public async Task AddFriend(string username, string friendId)
        //{
        //    var userWithFriends = _context.Users.Include(u => u.Friends).SingleOrDefault(u => u.UserName == username);
        //    var friend = _context.Users.SingleOrDefault(u => u.Id == friendId);

        //    userWithFriends.Friends.Add(friend);
        //    await _context.SaveChangesAsync();
        //}
    }
}
