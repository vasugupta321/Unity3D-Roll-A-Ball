using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb; //variable to hold reference
    Rigidbody player;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText ();
        count = 0;
        winText.text = "";
        player = GetComponent<Rigidbody>();

    }

    void FixedUpdate() //called just before performing physics calculations, physics code goes here
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // record input from player through keyboard
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed); //AddForce allows rigidbody to start moving

        if (count >= 12)
        {
            winText.text = "You win! Press space to restart";
            player.constraints = RigidbodyConstraints.FreezePosition;
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Key has been pressed");
                SceneManager.LoadScene("MiniGame");
            }
        }
    }
        
    void OnTriggerEnter(Collider other) //called when player gameobject first touches trigger collider. Other is reference to touched trigger collider
    {
        //check if tag is same as pick up gameobject and if so then deactivate it
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
