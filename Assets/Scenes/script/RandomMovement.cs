using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
     public float movementSpeed = 5f;
    private float startYPosition;

    private void Start()
    {
        // Y-Position der Startposition speichern
        startYPosition = transform.position.y;

        MoveObject();
    }

    private void MoveObject()
    {
        Vector3 randomPosition = GetRandomPosition();

        // Prüfen, ob ein Untergrund unter dem Objekt vorhanden ist
        RaycastHit hit;
        if (Physics.Raycast(randomPosition, Vector3.down, out hit))
        {
            if (hit.collider.CompareTag("Terrain"))
            {
                // Objekt zur zufälligen Position bewegen
                StartCoroutine(MoveToPosition(randomPosition));
                return;
            }
        }

        // Wenn kein Untergrund vorhanden ist, erneut nach einer Position suchen
        MoveObject();
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-20f, 20f), startYPosition, Random.Range(-20f, 20f));
    }

    private bool IsGroundBelow(Vector3 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(position, Vector3.down, out hit))
        {
            return hit.collider.CompareTag("Terrain");
        }

        return false;
    }

    private System.Collections.IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            // Objekt zur Zielposition bewegen
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

            yield return null;
        }

        // Neue Bewegung starten
        MoveObject();
    }
}
