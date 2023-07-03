using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeveWith : MonoBehaviour
{
    public Transform cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move with cube
        transform.position = new Vector3(cube.position.x, cube.position.y, cube.position.z);
    }
}
