using Microsoft.EntityFrameworkCore;
using Model.Comment;
using Model.Likes;
using Model.Posts;
using Models.User;

namespace Data.Context
{
    public class DataDbContext : DbContext
    {

        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<LikesModel> Likes { get; set; }
        public DbSet<PostModel> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<UserModel>()
            //     .HasMany(u => u.Posts)
            //     .WithOne(p => p.User)
            //     .HasForeignKey(p => p.UserId)
            //     .OnDelete(DeleteBehavior.Cascade); // This line specifies that when a user is deleted, delete their posts as well

            // modelBuilder.Entity<UserModel>()
            //     .HasMany(u => u.Comments)
            //     .WithOne(c => c.User)
            //     .HasForeignKey(c => c.UserId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<UserModel>()
            //     .HasMany(u => u.Likes)
            //     .WithOne(l => l.User)
            //     .HasForeignKey(l => l.UserId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<PostModel>()
            //     .HasMany(p => p.Comments)
            //     .WithOne(c => c.Post)
            //     .HasForeignKey(c => c.PostId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<PostModel>()
            //     .HasMany(p => p.Likes)
            //     .WithOne(l => l.Post)
            //     .HasForeignKey(l => l.PostId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<LikesModel>()
            //     .HasOne(l => l.Post)
            //     .WithMany(p => p.Likes)
            //     .HasForeignKey(l => l.PostId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<LikesModel>()
            //     .HasOne(l => l.User)
            //     .WithMany(u => u.Likes)
            //     .HasForeignKey(l => l.UserId)
            //     .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CommentModel>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommentModel>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}