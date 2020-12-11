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

        [TestCase("���� � ����� ����� �������", "�������", "���� � ����� ����� �������")]
        [TestCase("��, ����. ��, ������", "����", "��, ����. ��, ������")]
        [TestCase("�� ����� �������", "�����", "�� ����� �������")]
        public void TestEncode(string start, string key, string finish)
        {
            Assert.AreEqual(EvilProg.EvilEncode(start, key), finish);
        }

        [TestCase("���� � ����� ����� �������", "�������", "���� � ����� ����� �������")]
        [TestCase("��, ����. ��, ������", "����", "��, ����. ��, ������")]
        [TestCase("�� ����� �������", "�����", "�� ����� �������")]
        public void TestAntiEncode(string finish, string key, string start)
        {
            Assert.AreEqual(EvilProg.EvilAntiEncode(start, key), finish);
        }
    }
}