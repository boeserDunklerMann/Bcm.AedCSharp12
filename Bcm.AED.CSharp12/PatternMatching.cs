using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcm.AED.CSharp12PatternMatching
{
	public enum WaterLevel
	{
		Low,
		High
	}

	/// <summary>
	/// Schleuse
	/// </summary>
	internal class CanalLock
	{
		// Query canal lock state
		public WaterLevel CanalLockWaterLevel { get; private set; } = WaterLevel.Low;
		public bool HighWaterGateOpen { get; private set; } = false;
		public bool LowWaterGateOpen { get; private set; } = false;

		// change the gates
		public void SetHighWaterGate(bool open)
		{
			/*
			if (open && CanalLockWaterLevel == WaterLevel.High)
				HighWaterGateOpen = open;
			else if (open && CanalLockWaterLevel == WaterLevel.Low)
				throw new InvalidOperationException("Cannot open higher gate when waterlevel is low.");
			 * Your tests pass. But, as you add more tests, 
			 * you'll add more and more if clauses and test different properties. 
			 * Soon, these methods will get too complicated as you add more conditionals.
			 */
			HighWaterGateOpen = (open, HighWaterGateOpen, CanalLockWaterLevel) switch
			{
				(false, false, WaterLevel.High) => false,
				(false, false, WaterLevel.Low) => false,
				(true, false, WaterLevel.Low) => throw new InvalidOperationException("Cannot open higher gate when waterlevel is low."),
				(true, false, WaterLevel.High) => true,
				(false, true, WaterLevel.High)=>false,
				(false, true, WaterLevel.Low)=>false,   // kann nicht passieren
				(true, true, WaterLevel.High) => true,
				(true, true, WaterLevel.Low) => false, // should never happen
				_ => throw new NotImplementedException()
			};
			HighWaterGateOpen = (open, LowWaterGateOpen) switch
			{
				(true, true) => throw new InvalidOperationException("Cannot open both gates"),
				(false, true) => false,
				(true, false) => true,
				(false, false) => false
			};
		}

		public void SetLowWaterGate(bool open)
		{
			LowWaterGateOpen = open;
		}

		public void SetWaterLevel(WaterLevel waterLevel)
		{
			CanalLockWaterLevel = waterLevel;
		}

		public override string ToString()
		{
			return $"The lower gate is {(LowWaterGateOpen ? "open" : "closed")} the higher gate is {(HighWaterGateOpen ? "open" : "closed")} the water level is {CanalLockWaterLevel}";
		}
	}
}