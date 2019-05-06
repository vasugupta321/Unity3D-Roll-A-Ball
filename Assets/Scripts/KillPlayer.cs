using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public int lives = 3;
    public Text gameOver;
    public Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.text = "";
        SetLivesText();
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("MiniGame");
                Debug.Log("Game Restarted");
            }
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            gameOver.text = "Game Over! Press Space to restart game";
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (lives > 0)
        {
            if (collision.gameObject.tag == "Wall")
            {
                lives--;
                SetLivesText();
                Invoke("Respawn", 0.1f);
            }

        }
    }
    void Respawn()
    {
        player.transform.position = new Vector3(0, 0, 0); // respawns player
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }
}
