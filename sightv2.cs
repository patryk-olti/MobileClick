using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sightv2 : MonoBehaviour {

    float speed;
    bool change;            // true przeciwnie do zegara,   false zgodnie  

    Enginev2 engine;


    void Start()
    {
        speed = 15f;
        change = true;
        engine = FindObjectOfType<Enginev2>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            change = !change;
        }


        RotatingSight();
    }

    public void RotatingSight()
    {

        if (change)
        {
            transform.Rotate(Vector3.forward * engine.GetLvl() * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.back * engine.GetLvl() * Time.deltaTime);
        }


    }

    public bool GetChange()
    {
        return change;
    }

    public void Click()
    {
        change = !change;
    }
}
