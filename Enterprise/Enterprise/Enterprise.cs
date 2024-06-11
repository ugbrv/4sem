using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLibrary
{
    public class Enterprise
    {
        public Guid Guid { get; }

        public Enterprise(Guid guid)
        {
            Guid = guid;
        }

        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }

        private string inn;
        public string INN
        {
            get => inn;
            set
            {
                if (value.Length != 10)
                    throw new ArgumentException();

                if (!value.All(char.IsDigit))
                    throw new ArgumentException();

                inn = value;
            }
        }

        private DateTime establishDate;
        public DateTime EstablishDate
        {
            get => establishDate;
            set => establishDate = value;
        }

        public TimeSpan ActiveTimeSpan => DateTime.Now - establishDate;

        public double GetTotalTransactionsAmount()
        {
            DataBase.OpenConnection();

            var amount = DataBase.GetTransactions()
                .Where(t => t.EnterpriseGuid == Guid)
                .Sum(t => t.Amount);

            return amount;
        }
    }
}
