using Microsoft.EntityFrameworkCore;
using Models.User;

namespace Data.Context;


public class DataDbContext : DbContext
{
	  public DataDbContext(DbContextOptions<DataDbContext> options) : base (options)  { }
      public DbSet< UserModel> UserModel { get; set; }

    internal Task FindAsync(int id)
    {
        throw new NotImplementedException();
    }

    internal Task FirstOrDefault(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}