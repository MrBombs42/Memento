using ImGuiNET;
using Memento;
using UImGui;
using UnityEngine;

namespace Assets
{
	public class CaretakerDebugUI : MonoBehaviour
	{
		[SerializeField] private Caretaker _caretaker;
		private void OnEnable()
		{
			UImGuiUtility.Layout += OnLayout;
		}

		private void OnDisable()
		{
			UImGuiUtility.Layout -= OnLayout;
		}

		private void OnLayout(UImGui.UImGui gui)
		{
			if (ImGui.Begin("TimeLine"))
			{
				var state = _caretaker.CurrentState;

				ImGui.TextColored(new Vector4(1, 0, 0, 1), $"State: {state}, Frames: {_caretaker.FrameCount}");

				ImGui.End();
			}
		}
	}
}
