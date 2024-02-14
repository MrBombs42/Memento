using System.Collections.Generic;

namespace Memento
{
	public interface IFrame
	{
		long TimeStamp { get; }
		Dictionary<long, ISnapshot> Snapshots { get; }
	}
}
