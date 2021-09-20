using System.Collections;
using System.Collections.Generic;
using static System.Console;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    private float dirx, dirz;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxis("Horizontal") * moveSpeed;
        //Get the value of the Horizontal input axis.

        dirz = Input.GetAxis("Vertical") * moveSpeed;
        //Get the value of the Vertical input axis.


    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(dirx, rb.velocity.y, dirz);
    }
}
