using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hit : MonoBehaviour
{

    bool iss;
    GameObject ob;
    GameObject privot;
    float dis;
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Input.GetButton("Fire1"))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, Mathf.Infinity))
            {
                if(hit.collider.gameObject != null && !hit.collider.isTrigger && !hit.collider.CompareTag("Terrain"))
                {
                    if(!iss)
                    {
                        iss = true;
                        ob = hit.collider.gameObject;
                        ob.transform.gameObject.layer = 2;
                        privot = new GameObject("privot");
                        Vector3 s = Vector3.Scale(ob.transform.localScale, ob.GetComponent<MeshFilter>().mesh.bounds.size);
                        dis = s.y / 2;
                        privot.transform.position = new Vector3(ob.transform.position.x,ob.transform.position.y - dis , ob.transform.position.z);
                        ob.transform.parent = privot.transform;

                    }
                }
            }
        }
        else{
            if(ob != null)
            {
                iss = false;
                ob.transform.gameObject.layer = 0;
                ob.transform.parent = null;
                Destroy(privot);
                ob = null;
                return;
            }
        }

        if(ob != null )
        {
            RaycastHit hit2;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit2 ,Mathf.Infinity)){
                
                privot.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit2.normal);
                privot.transform.position = hit2.point;
                
            }
        }

    }
}