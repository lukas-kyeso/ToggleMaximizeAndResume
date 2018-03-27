using UnityEditor;
using UnityEngine;

public class ToggleMaximizeAndResume : MonoBehaviour {
	EditorWindow gameWindow;

	void Start () {
		System.Type T = System.Type.GetType ("UnityEditor.GameView,UnityEditor");
		System.Reflection.MethodInfo GetMainGameView = T.GetMethod ("GetMainGameView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
		System.Object Res = GetMainGameView.Invoke (null, null);
		gameWindow = (EditorWindow) Res;
	}

	void Update () {
		if (Input.GetKey (KeyCode.O) && Input.GetKeyDown (KeyCode.P)) {
			Pause ();
			ToggleMaximize ();
			Resume ();
		}
	}

	void ToggleMaximize () {
		gameWindow.maximized = !gameWindow.maximized;
	}

	void Pause () {
		EditorApplication.isPaused = true;
	}

	void Resume () {
		EditorApplication.isPaused = false;
	}

}