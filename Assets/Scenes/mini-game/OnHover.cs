using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHover : MonoBehaviour
{
public int lochID;
GameManager gameManager;

void Start(){
    gameManager = FindObjectOfType<GameManager>();
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
