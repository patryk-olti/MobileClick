using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EngineGame : MonoBehaviour {

    float timeOfGame;
    float nextSec;
    public Text time;

    float lvlGame;
    bool next;

    public Text color;
    int lastRandom;
    bool ok;
    int value;

    SightCOntroller sight;

    public GameObject panel;
    public GameObject gamepanel;

    float maxAngle;

    public string lvl;
    public string back_source;

    public int blind;

	void Start () {

        Time.timeScale = 1f;

        timeOfGame = 0;
        nextSec = Time.time + 1;

        lvlGame = 50;               // actually speed sight
        next = true;                // this is variable od bools for increments sec in interface
        lastRandom = 5;             // that variable is for check next new variable, we cant have equals two variable, last and next
        ok = true;                  // variable for waiting for a loop

        Randomizer();
        sight = FindObjectOfType<SightCOntroller>();

        panel.SetActive(false);
        gamepanel.SetActive(true);

        maxAngle = 356f;
        blind = PlayerPrefs.GetInt("BlindModeON");
    }

    void Update () {

        if (sight.transform.eulerAngles.z - maxAngle < 3 && sight.transform.eulerAngles.z - maxAngle > -3)
            OverGame();

        time.text = "sec: " + timeOfGame;

        // generationg new Time for interface
        if(nextSec - Time.time < 0)
        {
            nextSec = Time.time + 1;
            timeOfGame++;
            next = true;
        }


        // new lvl after each 5 sec
        if(timeOfGame % 5 == 0)
        {
            if (next)
            {
                next = false;
                lvlGame = lvlGame + 10;
            }
        }

        // input controller for game
        if(Input.GetKeyDown(KeyCode.Space))
        {
            WhereAmI();
            MechanicGame();
            Randomizer();
        }

	}


    public void Randomizer()
    {
        while(ok)
        {
            value = Random.Range(1, 5);
            if(value != lastRandom)
            {
                ok = false;

                switch (value)
                {
                    case 1:
                        color.text = "yellow";
                        color.color = Color.yellow;
                        break;

                    case 2:
                        color.text = "blue";
                        color.color = Color.blue;
                        break;

                    case 3:
                        color.text = "red";
                        color.color = Color.red;
                        break;

                    case 4:
                        color.text = "green";
                        color.color = Color.green;
                        break;

                }

                lastRandom = value;
            }

        }

        ok = true;
    }

    public void Randomizer_Blind()
    {
        while (ok)
        {
            value = Random.Range(1, 5);
            if (value != lastRandom)
            {
                ok = false;

                switch (value)
                {
                    case 1:
                        color.text = "yellow";
                        break;

                    case 2:
                        color.text = "blue";
                        break;

                    case 3:
                        color.text = "red";
                        break;

                    case 4:
                        color.text = "green";
                        break;

                }

                int color_new = Random.Range(1, 5);
                switch(color_new)
                {
                    case 1:
                        color.color = Color.yellow;
                        break;

                    case 2:
                        color.color = Color.blue;
                        break;

                    case 3:
                        color.color = Color.red;
                        break;

                    case 4:
                        color.color = Color.green;
                        break;
                }

                lastRandom = value;
            }

        }

        ok = true;
    }


    void MechanicGame()
    {
        switch(value)
        {
            case 1:     // yellow
                {
                    if(sight.transform.localEulerAngles.z < 360 && sight.transform.localEulerAngles.z > 270)
                    {
                        Debug.Log("great");
                    }
                    else
                    {
                        Debug.Log("false");
                        OverGame();
                    }
                }
                break;

            case 2:     // blue
                {
                    if (sight.transform.localEulerAngles.z > 0 && sight.transform.localEulerAngles.z < 90)
                    {
                        Debug.Log("great");
                    }
                    else
                    {
                        Debug.Log("false");
                        OverGame();
                    }
                }
                break;

            case 3:     // red
                {
                    if (sight.transform.localEulerAngles.z > 90 && sight.transform.localEulerAngles.z < 180)
                    {
                        Debug.Log("great");
                    }
                    else
                    {
                        Debug.Log("false");
                        OverGame();
                    }
                }
                break;

            case 4:     // green
                {
                    if (sight.transform.localEulerAngles.z > 180 && sight.transform.localEulerAngles.z < 270)
                    {
                        Debug.Log("great");
                    }
                    else
                    {
                        Debug.Log("false");
                        OverGame();
                    }
                }
                break;
        }
    }

    public void WhereAmI()
    {
            if (sight.transform.localEulerAngles.z < 360 && sight.transform.localEulerAngles.z > 270)
            {
                if (sight.GetChange()) { maxAngle = 270f; } else {  maxAngle = 360f;    }
            }

            if (sight.transform.localEulerAngles.z > 0 && sight.transform.localEulerAngles.z < 90)
            {
                if (sight.GetChange()) { maxAngle = 0f; } else { maxAngle = 90f; }
            }

            if (sight.transform.localEulerAngles.z > 90 && sight.transform.localEulerAngles.z < 180)
            {
                if (sight.GetChange()) { maxAngle = 90f; } else { maxAngle = 180f; }
            }

            if (sight.transform.localEulerAngles.z > 180 && sight.transform.localEulerAngles.z < 270)
            {
                if (sight.GetChange()) { maxAngle = 180f; } else { maxAngle = 270f; }
            }

    }



    public float GetLvl()
    {
        return lvlGame;
    }


    void OverGame()
    {
        panel.SetActive(true);
        gamepanel.SetActive(false);
        Time.timeScale = 0f;
    }


    public void NewGame()
    {
        SceneManager.LoadScene(lvl);
    }

    public void Back()
    {
        SceneManager.LoadScene(back_source);
    }

    public void ClickSpace()
    {
        WhereAmI();
        MechanicGame();

        if (blind == 1)
        { Randomizer_Blind();   }
        else{   Randomizer();   }
    }
}
