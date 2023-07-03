using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movetohand : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform hand;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ignor z axis
        transform.position = new Vector3(hand.position.x, hand.position.y, transform.position.z);
    }
}
