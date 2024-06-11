using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace EnterpriseLibrary
{
    public static class DataBase
    {
        private static List<string> fileLines;
        public static void OpenConnection()
        {
            string filePath = "transactions.txt";
            fileLines = File.ReadAllLines(filePath).ToList();
        }

        public static IEnumerable<Transaction> GetTransactions()
        {
            return fileLines
                .Select(line => line.Split(','))
                .Select(parts => new Transaction
                {
                    EnterpriseGuid = Guid.Parse(parts[0]),
                    Amount = double.Parse(parts[1], CultureInfo.InvariantCulture)
                });
        }
    }
}