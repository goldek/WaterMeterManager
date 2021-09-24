using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.Integration.Tests
{
    using static Testing;

    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}