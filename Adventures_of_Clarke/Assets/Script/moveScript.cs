using System.Collections;
using System.Collections.Generic;
using static System.Console;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveScript : MonoBehaviour
{
    
    public float MovementSpeed = 12;
    public float JumpForce = 70;

    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetKey(KeyCode.UpArrow) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
    void WinGame()
    {
        SceneManager.LoadScene("Winscreen");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
           
            WinGame();
        }
    }
}
