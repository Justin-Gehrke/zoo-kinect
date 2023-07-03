using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerAmeisen : MonoBehaviour
{
    public TMP_Text score;
    public GameObject[] loch;
    public int aktLoch;
    public int prevLoch;
    public int scoreScore;

    void Start() {
        score.text = "Score: 0";
        InvokeRepeating("neuesLoch", 0, 5);
    }

    public void scoreUpdate(){
        scoreScore = scoreScore + 1;
        score.text = ("Score: " + scoreScore);

    }



    public void neuesLoch() {
        loch[prevLoch].GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        aktLoch = Random.Range(0,7);
        prevLoch = aktLoch;
        loch[aktLoch].GetComponent<Renderer>().material.color = new Color(1f,0f,0f,1f);

    }
}
