using System.Collections.Generic;

namespace Memento
{
	public class Frame : IFrame
	{
		public long TimeStamp { get; private set; }

		public Dictionary<long, ISnapshot> Snapshots { get; private set; }

		public Frame(long timeStamp, Dictionary<long, ISnapshot> snapshots)
		{
			TimeStamp = timeStamp;
			Snapshots = snapshots;
		}
	}
}
