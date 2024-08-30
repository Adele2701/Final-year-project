using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{ 
    public float speed;
    private GameManager gameManager;
    private GameObject player; // Reference to the player GameObject
    private bool hasScored = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0)) {
            if (player.transform.position.z < transform.position.z)
            {
                if (!hasScored)
                {
                    NotifyGameManager();
                    hasScored = true; // Set the flag to true to prevent multiple score increments for the same obstacle
                }
            }
        }
    }

    // Notify the GameManager to increment the score
    private void NotifyGameManager()
    {
        if (gameManager != null)
        {
            gameManager.ScoreUp();
        }
    }

    public void SetGameManager(GameManager manager)
    {
        gameManager = manager;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
