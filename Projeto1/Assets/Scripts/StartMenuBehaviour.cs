using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBehaviour : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
			SceneManager.LoadScene ("Scenes/ExerciciosAula4/Level1", LoadSceneMode.Single);
	}
}
