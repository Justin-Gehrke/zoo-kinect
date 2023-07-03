using UnityEngine;

public class Gamemanager : MonoBehaviour
{

    public static Gamemanager instance;
    public float time;
    public int side; 

    private void Awake()
    {
        instance = this;

    }
}
