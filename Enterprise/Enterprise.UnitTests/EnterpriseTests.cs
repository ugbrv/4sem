using DataNames;
using EnterpriseLibrary;

namespace EnterpriseUnitTestProject
{
    [TestFixture]
    public class EnterpriseTests
    {
        [Test]
        public void EnterpriseTestMethod()
        {
            for( var i = 0; i < Data.Names.Length - 1; i++)
            {
                var propInfo = typeof(Enterprise)
                    .GetProperties()
                    .Where(p => p.Name.ToLower() == Data.Names[i].ToLower())
                    .FirstOrDefault();

                Assert.IsNotNull(propInfo, string.Format(Data.Messages[0], Data.Names[i]));

                if (i == 1 || i == 4)
                    Assert.IsFalse(propInfo.CanWrite, string.Format(Data.Messages[1], Data.Names[i]));

                Assert.IsTrue(Data.IsCapitalised(propInfo.Name), string.Format(Data.Messages[2], propInfo.Name));
            }

            var methodInfo = typeof(Enterprise)
                .GetMethods()
                .Where(m => m.Name.ToLower() == Data.Names[5].ToLower())
                .FirstOrDefault();

            Assert.IsNotNull(methodInfo, string.Format(Data.Messages[3], Data.Names[5]));
            Assert.IsTrue(Data.IsCapitalised(methodInfo.Name), string.Format(Data.Messages[4], methodInfo.Name));
        }

        [Test]
        public void TestGetTotalTransactionsAmount()
        {
            var enterpriseGuid = new Guid("00000000-0000-0000-0000-000000000001");
            var enterprise = new Enterprise(enterpriseGuid);

            double totalAmount = enterprise.GetTotalTransactionsAmount();

            Assert.AreEqual(150.0, totalAmount);
        }
    }
}

