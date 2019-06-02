using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public string easy;
    public string medium;
    public string hard;
    public string author;
    public string menu;

    public bool blindmode;
    public GameObject togle;

	// Use this for initialization
	void Start () {
        togle = GameObject.Find("Toggle");
        togle.GetComponent<Toggle>().isOn = false;

        blindmode = false;
        PlayerPrefs.SetInt("BlindModeON", 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Easy_Game_Load()
    {
        SceneManager.LoadScene(easy);
    }

    public void Medium_Game_Load()
    {
        SceneManager.LoadScene(medium);
    }

    public void Hard_Game_Load()
    {
        SceneManager.LoadScene(hard);
    }

    public void Author_Load()
    {
        SceneManager.LoadScene(author);
    }

    public void Quit_Game()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene(menu);
    }

    public void ToggleClick()
    {
        blindmode = !blindmode;

        if(blindmode)
            PlayerPrefs.SetInt("BlindModeON", 1);
        else
            PlayerPrefs.SetInt("BlindModeON", 0);
    }

}
