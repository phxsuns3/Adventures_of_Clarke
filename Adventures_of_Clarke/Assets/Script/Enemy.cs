using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float m_MaxSpeed;

    [SerializeField]
    private Vector3[] positions;

    private int index;
    private Transform target;
    private float attackCooldown;
    private bool canAttack = true;
    private float timeSinceAttack;
    private int destroy;
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.deltaTime
            * m_MaxSpeed);
        if(transform.position == positions[index])
        {
            if(index == positions.Length -1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }
    private void Attack()
    {
        if(!canAttack)
        {
            timeSinceAttack += Time.deltaTime;
        }
        if(timeSinceAttack >= attackCooldown)
        {
            canAttack = true;
        }
        if(canAttack && target != null && Mathf.Abs(target.transform.position.y - transform.position.y) <=1f)
        {
            canAttack = false;
            timeSinceAttack = 0;
        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canAttack == true)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                    Destroy(other.gameObject);
                    EndGame();  
            }
        }
    }
    
    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "Sight" && other.tag == "Player")
        {
            if (target == null)
            {
                this.target = other.transform;
            }
        }
    }
}
