using BGF.App.Core.Entities;
using BGF.App.Data;
using BGF.App.Models.BGG;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGF.App.Services
{
    public class BggService
    {
        private readonly ApplicationDbContext _dbContext;
        public BggService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task UpdateUsersBggGamesList(string bggUsername, string username)
        {
            var bggWebRequests = new BggWebRequests();

            var boardgameListXml = await bggWebRequests.FetchUserCollection(bggUsername);

            var boardGameList = (UserBoardgameList)XmlHelper.DeserializeFromString<UserBoardgameList>(boardgameListXml);

            var user = _dbContext.Users.Include(e => e.BoardGames).FirstOrDefault(e => e.UserName == username);
            if (user == null)
            {
                throw new NullReferenceException($"Could not find any User with username {username}");
            }

            // Make sure boardgame exists in DB and add it to user list
            foreach (var boardgame in boardGameList.Items)
            {
                // Check if boardgame exists in DB
                var exisitingBoardgame = _dbContext.BoardGames.FirstOrDefault(e => e.BggId == boardgame.ObjectId);

                // If boardgame don't exists, add it
                if (exisitingBoardgame == null)
                {
                    await AddNewBoardgameToDB(boardgame);
                    exisitingBoardgame = _dbContext.BoardGames.FirstOrDefault(e => e.BggId == boardgame.ObjectId);
                }

                var userOwnedBoardgame = user.BoardGames.FirstOrDefault(bg => bg.Boardgame.BggId == boardgame.ObjectId);

                if (userOwnedBoardgame == null)
                {
                    user.BoardGames.Add(new UserBoardgame 
                    { 
                       UserId = user.Id,
                       User = user,
                       BoardgameId = exisitingBoardgame.Id,
                       Boardgame = exisitingBoardgame
                    });
                }
                
            }

            await _dbContext.SaveChangesAsync();

            // Remove any boardgames from user if not in bgg list
            var userBgsToRemove = new List<UserBoardgame>();
            foreach (var userBg in user.BoardGames)
            {
                var bgInCollection = boardGameList.Items.FirstOrDefault(bg => bg.ObjectId == userBg.Boardgame.BggId);

                if (bgInCollection == null)
                {
                    userBgsToRemove.Add(userBg);
                }
            }

            if (userBgsToRemove.Count() > 0)
            {
                foreach (var userBg in userBgsToRemove)
                {
                    user.BoardGames.Remove(userBg);
                }
            }

            await _dbContext.SaveChangesAsync();

            var paus = 0;
        }

        private async Task AddNewBoardgameToDB(UserBoardgameListItem boardgame)
        {
            var boardgameEntity = new Boardgame();

            boardgameEntity.BggId = boardgame.ObjectId;
            boardgameEntity.Name = boardgame.Name;
            boardgameEntity.Image = boardgame.Image;
            boardgameEntity.ThumbNail = boardgame.Thumbnail;
            boardgameEntity.YearPublished = boardgame.YearPublished;

            _dbContext.BoardGames.Add(boardgameEntity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
