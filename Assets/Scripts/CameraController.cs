using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; //reference to player gameobject

    private Vector3 offset; //private as we can set value here
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; //camera transform - player transform
    }

    //Guranteed to run after everything process in Update
    //So when setting camera position we know for sure player has moved for that frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; //camera is update to new position with player object acting like child of player
    }
}
