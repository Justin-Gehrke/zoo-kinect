using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackToTop : MonoBehaviour
{
    // Start is called before the first frame update
    public float startZ;
    public float endZ;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down on Z axis
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
        if (transform.position.z < endZ)
        {
            //move back to top
            transform.position = new Vector3(transform.position.x, transform.position.y, startZ);
        }
    }
}
