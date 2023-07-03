using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHover : MonoBehaviour
{
public int lochID;
GameManagerAmeisen gameManager;

void Start(){
    gameManager = FindObjectOfType<GameManagerAmeisen>();
}

void OnMouseOver()
    {
        Debug.Log("Mouse");
        
        if (lochID == gameManager.aktLoch) {
            gameManager.aktLoch = 8;
            gameManager.scoreUpdate();
        }
    }
}
