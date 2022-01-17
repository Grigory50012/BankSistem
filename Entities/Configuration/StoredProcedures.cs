namespace Entities.Configuration
{
    public class StoredProcedures
    {
        public static string GetAccountsWithoutCards =>
            "CREATE PROCEDURE [dbo].[GetAccountsWithoutCards] " +
            "AS " +
            "SELECT Accounts.IdAccount, Accounts.Balance, Accounts.IdCardOwner " +
            "FROM Accounts " +
            "LEFT JOIN Cards ON Accounts.IdAccount = Cards.IdAccount " +
            "WHERE Cards.IdCard IS NULL";
    }
}
