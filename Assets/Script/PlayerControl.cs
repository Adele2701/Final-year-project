using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerControl : MonoBehaviour
{
    public float jumpForce;
    bool canJump;
    Rigidbody rb;
    GameObject tryAgainPanel;
    GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other) // If collide other
    {
        if (other.gameObject.tag == "Obstacle")
        {
            canJump = false;
            gameManager = FindObjectOfType<GameManager>();
            gameManager.GameOver();
        }
    }
}
