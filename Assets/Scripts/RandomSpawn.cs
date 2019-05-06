using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject cube;
    private int count = 0;

    // Use this for initialization
    void Start()
    {
        //At the start of the game, Pickup is cloned at a speed of 0.1f
        InvokeRepeating("CloneItem", 0.5f, 0.5f);
    }

    void CloneItem()
    {
        GameObject clone = Instantiate(cube); //clone for the Pickup game object
        //random ranges for every cloned pickup game object
        clone.transform.position = new Vector3(Random.Range(-7.75f, 7.75f), 0.5f, Random.Range(8f, -8f));
        count++;

        if (count == 12)
        {
            CancelInvoke(); //stops spawning of the pickup game objects
        }
    }
}
