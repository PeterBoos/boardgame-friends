using BGF.App.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BGF.App.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {  }

        public DbSet<Boardgame> BoardGames { get; set; }

        public DbSet<GameSession> GameSessions { get; set; }

        public DbSet<GameSessionDate> GameSessionDates { get; set; }

        public DbSet<SessionComment> SessionComments { get; set; }

    }
}
