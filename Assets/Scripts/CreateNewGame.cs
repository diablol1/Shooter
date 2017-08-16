using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class CreateNewGame : MonoBehaviour {

	public Text nameText;
	public Text errorText;

	public void OnClickAcceptName() {
		string gameName = nameText.text;

		if (gameName.Length == 0)
			errorText.text = "Error: Game name cannot be empty";
		else if (gameName.Contains (" "))
			errorText.text = "Error: Game name cannot contain space";
		else if (isCreated (gameName))
			errorText.text = "Error: Game named \"" + gameName + "\" already exists";
		else {
			GamesManagingState.CurrentGameName = gameName;
			create (gameName);
		}
	}

	bool isCreated(string name) {
		if (!File.Exists ("Saves.txt"))
			return false;
		
		using (StreamReader reader = new StreamReader("Saves.txt", true)) {
			string content = reader.ReadToEnd ();
			return content.Contains (name);
		}
	}

	void create(string name) {
		using (FileStream file = new FileStream ("Saves.txt", FileMode.Append, FileAccess.Write))
		using (StreamWriter writer = new StreamWriter (file)) {
			writer.WriteLine (name + " 1");
			SceneManager.LoadScene ("Scenes/Levels/Level1");
		}
	}
}