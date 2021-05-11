using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    private int score = 0;
    public int health = 5;
    private Vector3 move;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 20f;
    }
    void Update(){
        move =  new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        
        rb.AddForce(move * speed);
        if(health == 0){
            Debug.Log("Game Over!");
            SceneManager.LoadScene("maze");
            score = 0;
            health = 5;
        }
    }
    public void FixedUpdate(){
        if(Input.GetKey(KeyCode.A)){
            rb.AddForce(Vector3.left);
        }
        else if(Input.GetKey(KeyCode.W)){
            rb.AddForce(Vector3.forward);
        }
        else if(Input.GetKey(KeyCode.S)){
            rb.AddForce(Vector3.back);
        }
        else if(Input.GetKey(KeyCode.D)){
            rb.AddForce(Vector3.right);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Pickup"){
            score++;
            Debug.Log("Score: " + score);
        }
        if (other.tag == "Trap"){
            health--;
            Debug.Log("Health: " + health);
        }
        if(other.tag == "Goal"){
            Debug.Log("You win!");
        }
    }
}
