﻿using Bcm.AED.CSharp12.Banking;

namespace Bcm.AED.CSharp12
{
    /// <summary>
    /// primäre Konstruktoren
    /// </summary>
	public struct Distance(double dx, double dy)
    {
        public readonly double Magnitude => Math.Sqrt(dx * dx + dy * dy);
        public readonly double Direction => Math.Atan2(dy, dx);

        public void Translate(double deltaX, double deltaY)
        {
            dx += (double)deltaX; dy += (double)deltaY;
        }

        public Distance() : this(0.0, 0.0)
        {

        }
        static void Main(string[] args)
        {
            Distance distance = new Distance(1, 1);
            Banking.CheckingAccount acct = new Banking.CheckingAccount("1234567890", "abc");
            CheckingAccount acct2 = new CheckingAccount("1234567890", "André", 20);
            acct.Deposit(10);
            acct2.Deposit(10);
            acct.Withdrawal(10);
            acct2.Withdrawal(11);
            Console.WriteLine(acct.ToString());
            Console.WriteLine(acct2.ToString());
        }
    }
}