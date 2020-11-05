using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shard.Save.Domain;

namespace Shard.Save
{
    public static class Handlers<TServer, TSave>
        where TServer : class, new()
        where TSave : Save<TSave>, new()
    {
        public static TServer Load(TSave save)
        {
            save.Database.Migrate();

            return save.Set<TServer>().IncludeAll().SingleOrDefault() ?? save.Add(new TServer()).Entity;
        }

        public static void Process(TSave save)
        {
            save.SaveChanges();
        }
    }
}
