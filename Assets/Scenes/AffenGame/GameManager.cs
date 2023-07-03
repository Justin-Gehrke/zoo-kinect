using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float xposL;
    public float ypos;
    public float zposL;
    public float xposR;
    public float zposR;
    public bool running = true;
    public GameObject blätterLinks;
    public GameObject blätterRechts;
    public GameObject affe;
    public GameObject cursor;
    public float endxposL;
    public float endzposL;
    public float endxposR;
    public float endzposR;
    public bool affeposition = false; // false = links, true = rechts

    void Start()
    {
        StartCoroutine(gameStart());
    }

    void Update()
    {
        // Cursor trackt die Mausposition, Anhand der Position (x Koordinate über oder unter 0) wird Affe bewegt

        
        if (cursor.transform.position.x <= 0) {
            affeposition = false;
            affe.transform.position = new Vector3 (-0.127f, 0.02f, -0.209f);
            //Debug.Log("Affe ist Links");
        }
        else {
            affeposition = true;
            affe.transform.position = new Vector3 (0.127f, 0.02f, -0.209f);
            //Debug.Log("Affe ist Rechts");
        }

        // Hit Detection
    //Debug.Log(affeposition);
        if ((blätterLinks.transform.position.z <= -0.15f) && ((blätterLinks.transform.position.z >= -0.22f) && (affeposition == false))) {
            Debug.Log("Game End Links");
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        if ((blätterRechts.transform.position.z <= -0.15f) && ((blätterRechts.transform.position.z >= -0.22f) && (affeposition == true))) {
            Debug.Log("Game End Rechts");
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }





    }

    public IEnumerator gameStart(){
        while(running == true) {
            randomAst();
            yield return new WaitForSeconds(3);
            blätterLinks.transform.position = new Vector3 (xposL, ypos, zposL);
            blätterRechts.transform.position = new Vector3 (xposR, ypos, zposR);
        }
    }

   public void randomAst(){
        float randomNumber = Random.Range(0, 2);
        if (randomNumber == 0){ //Links
            StartCoroutine (MoveOverSeconds (blätterLinks, new Vector3 (-0.544f, 0.015f, -0.515f), 2f));
        }
        else { // rechts
            StartCoroutine (MoveOverSeconds (blätterRechts, new Vector3 (0.544f, 0.015f, -0.515f), 2f));
        }
    }




    public IEnumerator MoveOverSeconds (GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return 0;
        }
        objectToMove.transform.position = end;
    }


}
