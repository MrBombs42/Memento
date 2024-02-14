using UnityEngine;

namespace Assets
{
	public struct SerializablePosition
	{
		public float x;
		public float y;
		public float z;

		public SerializablePosition(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static implicit operator Vector3(SerializablePosition rValue)
		{
			return new Vector3(rValue.x, rValue.y, rValue.z);
		}

		public static implicit operator SerializablePosition(Vector3 rValue)
		{
			return new SerializablePosition(rValue.x, rValue.y, rValue.z);
		}
	}
}
