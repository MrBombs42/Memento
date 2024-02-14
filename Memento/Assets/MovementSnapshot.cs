using Memento;

namespace Assets
{
	public class MovementSnapshot : ISnapshot
	{
		// 7 bits
		public float XPos;
		public float YPos;
		public float ZPos;
		public SerializableQuaternion Rotation;
	}
}
