using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gib : MonoBehaviour
{
     public GameObject targetObject;
    
     public string sceneToLoad; // Der Name der Szene, zu der gewechselt werden soll
    private Vector3 targetPosition;
    
    void Update()
    {
        // Überprüfen, ob das Zielobjekt ausgewählt wurde
        if (targetObject != null)
        {
            // Speichern der Koordinaten des Zielobjekts
            targetPosition = targetObject.transform.position;
            
            // Überprüfen, ob das Objekt innerhalb des Bereichs liegt
            if (transform.position.x >= targetPosition.x - 10 && transform.position.x <= targetPosition.x + 10 &&
                transform.position.y >= targetPosition.y - 10 && transform.position.y <= targetPosition.y + 10 &&
                transform.position.z >= targetPosition.z - 10 && transform.position.z <= targetPosition.z + 10)
            {
                Debug.Log("Das Objekt befindet sich im Bereich von -10 bis 10 um das Zielobjekt.");
                SceneManager.LoadScene(sceneToLoad); // Szene wechseln
            }
            else
            {
                
                Debug.Log("Das Objekt befindet sich nicht im Bereich von -10 bis 10 um das Zielobjekt.");
            }
        }
        else
        {
            Debug.Log("Es wurde kein Zielobjekt ausgewählt.");
        }
    }
    
}
