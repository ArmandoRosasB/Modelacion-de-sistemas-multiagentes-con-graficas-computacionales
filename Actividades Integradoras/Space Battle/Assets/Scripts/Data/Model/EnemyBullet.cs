using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBullet : MonoBehaviour
{
    public float MoveSpeed;
    public Vector2 MoveDirection;
    
   
    
    [SerializeField]
    private float damage;
    
    public static Action bulletDestroyed;
    
    private void Update()
    {
        transform.Translate(MoveDirection * Time.deltaTime * MoveSpeed);
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Asteroid"))
        {
          //  other.GetComponent<Ateroid>().takeDamage(damage);
            Destroy(gameObject);
            bulletDestroyed?.Invoke();
        }
        
        if (other.CompareTag("Player"))
        {
            //  other.GetComponent<Enemigo>().takeDamage(damage);
            Destroy(gameObject);
            bulletDestroyed?.Invoke();
        }
        
        if (other.CompareTag("Limite"))
        {
            Destroy(gameObject);
            bulletDestroyed?.Invoke();
        }
        
    }
}
