using NUnit.Framework;

namespace Kursach.Test
{
    [TestFixture]
    public class Tests
    {

        [SetUp]
        public void Setup()
        {

        }

        [TestCase(" арл у  лары украл кораллы", "кларнет", "’лрь б ѕюкьы дшхтц цобнрюЄ")]
        [TestCase("ну, за€ц. ну, погоди", "волк", "пв, укбе. щю, сэощЄч")]
        [TestCase("на марсе классно", "песн€", "эе юнпбй ьщ€бц€ь")]
        public void TestEncode(string start, string key, string finish)
        {
            Assert.AreEqual(EvilProg.EvilEncode(start, key), finish);
        }

        [TestCase(" арл у  лары украл кораллы", "кларнет", "’лрь б ѕюкьы дшхтц цобнрюЄ")]
        [TestCase("ну, за€ц. ну, погоди", "волк", "пв, укбе. щю, сэощЄч")]
        [TestCase("на марсе классно", "песн€", "эе юнпбй ьщ€бц€ь")]
        public void TestAntiEncode(string finish, string key, string start)
        {
            Assert.AreEqual(EvilProg.EvilAntiEncode(start, key), finish);
        }
    }
}