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


        // Join tables
        public DbSet<UserBoardgame> UserBoardgames { get; set; }
        public DbSet<UserGameSession> UserGameSessions { get; set; }
        public DbSet<GameSessionBoardgame> GameSessionBoardgames { get; set; }
        //public DbSet<UserFriend> UserFriends { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User boardgames join table
            modelBuilder.Entity<UserBoardgame>()
                .HasKey(gb => new { gb.UserId, gb.BoardgameId });
            modelBuilder.Entity<UserBoardgame>()
                .HasOne(gb => gb.User)
                .WithMany(b => b.BoardGames)
                .HasForeignKey(gb => gb.UserId);
            modelBuilder.Entity<UserBoardgame>()
                .HasOne(gb => gb.Boardgame)
                .WithMany(u => u.Owners)
                .HasForeignKey(gb => gb.BoardgameId);

            // User game sessions join table
            modelBuilder.Entity<UserGameSession>()
                .HasKey(ug => new { ug.UserId, ug.GameSessionid });
            modelBuilder.Entity<UserGameSession>()
                .HasOne(ug => ug.User)
                .WithMany(b => b.GameSessions)
                .HasForeignKey(ug => ug.UserId);
            modelBuilder.Entity<UserGameSession>()
                .HasOne(ug => ug.GameSession)
                .WithMany(u => u.Users)
                .HasForeignKey(ug => ug.GameSessionid);

            // Game session boardgames join table
            modelBuilder.Entity<GameSessionBoardgame>()
                .HasKey(gb => new { gb.GameSessionId, gb.BoardgameId });
            modelBuilder.Entity<GameSessionBoardgame>()
                .HasOne(gb => gb.GameSession)
                .WithMany(b => b.SuggestedBoardgames)
                .HasForeignKey(gb => gb.GameSessionId);
            modelBuilder.Entity<GameSessionBoardgame>()
                .HasOne(gb => gb.Boardgame)
                .WithMany(u => u.GameSessions)
                .HasForeignKey(gb => gb.BoardgameId);

            // User Friend(user) join table
            //modelBuilder.Entity<UserFriend>()
            //    .HasKey(uf => new { uf.UserId, uf.FriendId });
            //modelBuilder.Entity<UserFriend>()
            //    .HasOne(uf => uf.User)
            //    .WithMany(f => f.Friends)
            //    .HasForeignKey(uf => uf.UserId);
            //modelBuilder.Entity<UserFriend>()
            //    .HasOne(uf => uf.Friend)
            //    .WithMany(u => u.Friends)
            //    .HasForeignKey(uf => uf.FriendId);
        }
    }
}
