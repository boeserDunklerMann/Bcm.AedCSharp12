namespace Bcm.AED.CSharp12.Banking
{
	/// <summary>
	/// Sparbuch: Problem mit doppelten prim. KOnstruktorenparametern. Siehe ToString().
	/// </summary>
	/// <param name="accountID">Kontonummer</param>
	/// <param name="owner">Inhaber</param>
	/// <param name="interestRate">Zinsrate</param>
	public class SavingsAccount(string accountID, string owner, decimal interestRate) : BankAccount(accountID, owner)
	{
		public SavingsAccount() : this("default", "default", 0.01m) { }
		public decimal CurrentBalance { get; private set; } = 0;

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
			if (CurrentBalance - amount < 0)
				throw new InvalidOperationException("keine Verfügung möglich");
			CurrentBalance -= amount;
		}

		public void ApplyInterest()
		{
			CurrentBalance *= 1 + interestRate;
			
		}

		/// <summary>
		/// Wir benutzen hier die primären Konstuktorparameter - nicht die Properties der Basisklasse (AccountID, Owner).
		/// Das führt dazu, dass SavingsAccount Kopien dieser Parameter speichert.
		/// Würden wir die Properties der Basisklasse ändern (was nicht geht, da diese nur getter haben),
		/// würden diese Änderungen hier nicht ankommen.
		/// </summary>
		/// <returns></returns>
		public override string ToString() => $"Account ID: {accountID}, Owner: {owner}, Balance: {CurrentBalance}";
	}
}