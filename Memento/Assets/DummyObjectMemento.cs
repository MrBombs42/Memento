using Memento;

namespace Assets
{
	public class DummyObjectMemento : MementoBehavior
	{
		public override ISnapshot GetSnapshot()
		{
			return new MovementSnapshot
			{
				Position = transform.position,
				Rotation = transform.rotation
			};
		}

		public override void Restore(ISnapshot snapshot)
		{
			var memento = (MovementSnapshot)snapshot;
			transform.position = memento.Position;
			transform.rotation = memento.Rotation;
		}
	}
}
