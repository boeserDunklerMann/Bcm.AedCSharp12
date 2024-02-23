namespace Bcm.AED.CSharp12.Banking
{
	/// <summary>
	/// primärer Konstruktor. akzeptiert alle Parameter der Basisklasse plus einen weiteren.
	/// </summary>
	public class CheckingAccount(string accountID, string owner, decimal overdraftLimit = 0) : BankAccount(accountID, owner)
	{
		public decimal CurrentBalance { get; private set; }= 0;

		public void Deposit(decimal amount)
		{
			if (amount < 0)
				throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positve");
			CurrentBalance += amount;
		}

		public void Withdrawal(decimal amount)
		{
			if (amount < 0)
				throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive");
			if (CurrentBalance-amount< -overdraftLimit)
				throw new InvalidOperationException("keine Verfügung möglich");
			CurrentBalance -= amount;
		}

		public override string ToString()=>$"AccountID: {AccountID}, Owner: {Owner}, Balance {CurrentBalance}";
	}
}