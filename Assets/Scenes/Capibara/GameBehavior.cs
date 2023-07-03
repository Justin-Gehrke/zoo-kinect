using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Get the x-coordinate of the mouse position
        float mouseX = Input.mousePosition.x;

        // Get the screen width
        float screenWidth = Screen.width;

        // Calculate the middle point of the screen
        float screenMiddle = screenWidth / 2f;

        // Check if the mouse is on the left or right side of the screen
        if (mouseX < screenMiddle)
        {
            Gamemanager.instance.side = 1;
            // Mouse is on the left side
            //Debug.Log("Mouse is on the left side of the screen.");
        }
        else
        {
            Gamemanager.instance.side = 2;
            // Mouse is on the left side
            // Mouse is on the right side
            //Debug.Log("Mouse is on the right side of the screen.");
        }

    }
}
