using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float damage;
    
    public static Action bulletDestroyed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Asteroid"))
        {
          //  other.GetComponent<Ateroid>().takeDamage(damage);
            Destroy(gameObject);
            bulletDestroyed?.Invoke();
        }
        
        if (other.CompareTag("Enemigo"))
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
