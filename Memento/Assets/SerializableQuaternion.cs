using UnityEngine;

namespace Assets
{
	[System.Serializable]
	public struct SerializableQuaternion
	{
		public float x;
		public float y;
		public float z;
		public float w;

		public SerializableQuaternion(float x, float y, float z, float w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public static implicit operator Quaternion(SerializableQuaternion rValue)
		{
			return new Quaternion(rValue.x, rValue.y, rValue.z, rValue.w);
		}

		public static implicit operator SerializableQuaternion(Quaternion rValue)
		{
			return new SerializableQuaternion(rValue.x, rValue.y, rValue.z, rValue.w);
		}
	}

}
