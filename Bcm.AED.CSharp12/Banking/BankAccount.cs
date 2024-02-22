namespace Bcm.AED.CSharp12.Banking
{
	public class BankAccount(string accountID, string owner)
	{
		public string AccountID { get; } = IsValidAccountNumber(accountID) ?
			accountID : throw new ArgumentException("Invalid account number", nameof(accountID));

		public string Owner { get; } = string.IsNullOrWhiteSpace(owner) ?
			throw new ArgumentException("Owner name must not be empty", nameof(owner)) : owner;

		public static bool IsValidAccountNumber(string accountID)
			=> accountID.Length == 10 && accountID.All(c => char.IsDigit(c));
	}
}