using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcm.AED.CSharp12.Banking
{
	public class CheckingAccount2 : BankAccount
	{
		private readonly decimal _creditLimit;
		public CheckingAccount2(string accountID, string owner, decimal creditLimit) : base(accountID, owner)
		{
			_creditLimit = creditLimit;
		}
		public decimal CurrentBalance { get; private set; } = 0;
		public void Deposit(decimal amount)
		{
			if (amount < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive");
			}
			CurrentBalance += amount;
		}

		public void Withdrawal(decimal amount)
		{
			if (amount < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive");
			}
			if (CurrentBalance - amount < -_creditLimit)
			{
				throw new InvalidOperationException("Insufficient funds for withdrawal");
			}
			CurrentBalance -= amount;
		}

		public override string ToString() => $"{base.ToString()} Balance: {CurrentBalance}";
	}
}