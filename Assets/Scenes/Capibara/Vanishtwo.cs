using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Vanishtwo : MonoBehaviour
{
    //public float appearDuration = 5f;    // Duration for the sprite to appear

    GameObject sprite1;
    GameObject sprite2;
    GameObject sprite3;
    GameObject sprite4;
    private bool isVisible = false;
    private int ran = 0;
    float wait;
    float last;
    public float lastDif;
    public float AppearDur;
    public bool oneTime;
    public bool geflipped;

    private void Update()
    {
        //Same method wie hier drunter nur minus 1 und dann AppearDur auf 4 statt 3 

        if (Gamemanager.instance.side == 1)
        {
            //left
            transform.localScale = new Vector3(0.01870123f, 0.01870123f, 0.01870123f);
        }
        else
        {
            //right
            transform.localScale = new Vector3(-0.01870123f, 0.01870123f, 0.01870123f);
        }

        if (Time.time - last >= AppearDur)
        {

            if (Gamemanager.instance.side == ran && oneTime == true)
            {
                //Jump Back to island
                Debug.Log("Game over");
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
                oneTime = false;
            }

            sprite1.SetActive(false);
            sprite2.SetActive(false);


            if (ran == 2)
            {
                sprite3.SetActive(true);
            }
            else if (ran == 1)
            {
                sprite4.SetActive(true);
            }

        }

        if (Time.time - last >= AppearDur + 2)
        {
            sprite3.SetActive(false);
            sprite4.SetActive(false);
        }


            //Debug.Log(last);
            if (Time.time - last >= lastDif) {
        ToggleVisibility();
        }



    }
        private void Start()
    {

        sprite1 = GameObject.FindWithTag("Ex1");
        sprite2 = GameObject.FindWithTag("Ex2");
        sprite3 = GameObject.FindWithTag("Danger2");
        sprite4 = GameObject.FindWithTag("Danger1");
        //spriteRenderer1 = GameObject.Find("exclamation-mark-" + 1 + "png")?.GetComponent<SpriteRenderer>();
        sprite1.SetActive(isVisible);
        sprite2.SetActive(isVisible);
        sprite3.SetActive(isVisible);
        sprite4.SetActive(isVisible);

        // Start the visibility toggling loop

        //InvokeRepeating("ToggleVisibility", appearDuration, appearDuration);
    }
    
    private void ToggleVisibility()
    {
        oneTime = true;
        ran = Random.Range(1, 3);
        Debug.Log(ran);

        if (ran == 1)
        {
            last = Time.time;
            isVisible = !isVisible;
            sprite1.SetActive(isVisible);
        }
        else if (ran == 2)
        {
            last = Time.time;
            isVisible = !isVisible;
            sprite2.SetActive(isVisible);
        }

        isVisible = false;

    }
}
