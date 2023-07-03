using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gib : MonoBehaviour
{
    public GameObject targetObject;
    public string sceneToLoad; // Der Name der Szene, zu der gewechselt werden soll
    private Vector3 targetPosition;
    private Camera mainCamera;
    private bool isMoving = false;
    public float radius = 0.1f; // Radius um das Zielobjekt, in dem sich das Objekt befinden muss, um die Szene zu wechseln
    private float initialOrthographicSize; // Anfangsgröße der Kamera-Orthographie
    public float targetOrthographicSize = 5f; // Zielgröße der Kamera-Orthographie
    public float zoomSpeed = 10f; // Zoom-Geschwindigkeit der Kamera

    private void Start()
    {
        mainCamera = Camera.main;
        initialOrthographicSize = mainCamera.orthographicSize;
    }

    void Update()
    {
        // Überprüfen, ob das Zielobjekt ausgewählt wurde
        if (targetObject != null)
        {
            // Speichern der Koordinaten des Zielobjekts
            targetPosition = targetObject.transform.position;

            // Überprüfen, ob das Objekt innerhalb des Bereichs liegt
            if (transform.position.x >= targetPosition.x - radius && transform.position.x <= targetPosition.x + radius &&
                transform.position.y >= targetPosition.y - radius && transform.position.y <= targetPosition.y + radius &&
                transform.position.z >= targetPosition.z - radius && transform.position.z <= targetPosition.z + radius)
            {
                Debug.Log("Das Objekt befindet sich im Bereich von -10 bis 10 um das Zielobjekt.");

                // Prüfen, ob das Objekt bereits bewegt wird
                if (!isMoving)
                {
                    StartCoroutine(MoveCameraToObjectCoroutine(targetPosition-Vector3.forward*0.03f));
                }
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

    IEnumerator MoveCameraToObjectCoroutine(Vector3 targetPosition)
    {
        isMoving = true;

        // Berechne die Richtung und die Schrittgröße für die Bewegung der Kamera
        Vector3 direction = (targetPosition - mainCamera.transform.position).normalized;
        float step = 1f * Time.deltaTime; // Passen Sie die Geschwindigkeit an Ihre Bedürfnisse an

        float initialDistance = Vector3.Distance(mainCamera.transform.position, targetPosition);
        float currentDistance = initialDistance;

        while (currentDistance > 0.05f)
        {
            // Bewege die Kamera in Richtung des Zielobjekts
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, targetPosition, step);

            // Verändere die Orthographische Größe der Kamera
            float targetSize = Mathf.Lerp(initialOrthographicSize, targetOrthographicSize, 1f - (currentDistance / initialDistance));
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetSize, zoomSpeed * Time.deltaTime);

            currentDistance = Vector3.Distance(mainCamera.transform.position, targetPosition);

            yield return null;
        }

        // Die Kamera hat die Zielposition erreicht
        Debug.Log("Die Kamera hat die Zielposition erreicht.");

        // Szene wechseln
        SceneManager.LoadScene(sceneToLoad);

        isMoving = false;
    }
}
