using Memento;

namespace Assets
{
	public class MovementSnapshot : ISnapshot
	{
		// 7 bits
		public SerializablePosition Position;
		public SerializableQuaternion Rotation;
	}
}
