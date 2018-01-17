using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour {

    public Text start;

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            start.text = "Please wait...";
            SceneManager.LoadSceneAsync(1);
        }
	}
}
