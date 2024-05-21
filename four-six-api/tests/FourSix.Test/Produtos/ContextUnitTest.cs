using FourSix.Controllers.Gateways.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FourSix.Test.Produtos
{
    public class ContextUnitTest
    {
        public static Context GetDatabase()
        {
            var name = Guid.NewGuid().ToString();
            return GetDatabase(name);
        }

        private static Context GetDatabase(string name)
        {
            var inMemoryOption = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(name).Options;

            return new Context(inMemoryOption);
        }
    }
}
