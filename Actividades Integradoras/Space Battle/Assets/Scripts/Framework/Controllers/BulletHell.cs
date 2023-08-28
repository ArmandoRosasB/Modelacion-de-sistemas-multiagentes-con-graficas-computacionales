using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletHell : MonoBehaviour
{

    public static Action bulletInstantiated;
    
    
    [SerializeField][Min(0)]
    private int Bullets;
    
    [SerializeField]
    private float StartAngle, EndAngle;
    
    [SerializeField]
    private GameObject BulletPrefab;
    
    private float wait = .3f;
    private float timer;
    
    void Start()
    {
    	timer = wait;
        
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            if (TimeManager.Second < 10)
            {
                Bullets = 20;
                OnFire();

            }
        
            else if (TimeManager.Second < 20)
            {
                Bullets = 20;
                OnFire2();

            }
        
            else if (TimeManager.Second < 30)
            {
                Bullets = 6;
                OnFire3();
                StartAngle += 10;
                EndAngle += 10;
                
            }
            
            timer = wait;
        }
        

    }
    
    void OnFire()
    {
        float angleStep = (EndAngle - StartAngle) / Bullets;
        
        float currentAngle = StartAngle;
        
        for(int i = 0; i < Bullets; i++)
        {
            float dirX = transform.position.x + Mathf.Sin((currentAngle * Mathf.PI) / 180);
            float dirY = transform.position.y + Mathf.Cos((currentAngle * Mathf.PI) / 180);
            
            
            Vector2 bulletPosition = new Vector2(dirX, dirY);
            Vector2 bulletDirection = (bulletPosition - (Vector2) transform.position).normalized;
            
            GameObject currentBullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bulletInstantiated?.Invoke();
            
            EnemyBullet currentBulletMovement = currentBullet.GetComponent<EnemyBullet>();
            currentBulletMovement.MoveSpeed = 4;
            currentBulletMovement.MoveDirection = bulletDirection;
            
            
            currentAngle += angleStep;
            
        }
    }
   
    void OnFire2()
    {

        float angleStep = (EndAngle - StartAngle) / Bullets;
        
        float currentAngle = StartAngle;
        
        for(int i = 0; i < Bullets; i++)
        {
            float dirX = transform.position.x + Mathf.Sin((currentAngle * Mathf.PI) / 180);
            float dirY = transform.position.y + Mathf.Cos((currentAngle * Mathf.PI) / 180);
            
            
            Vector2 bulletPosition = new Vector2(dirX, dirY);
            Vector2 bulletDirection = (bulletPosition - (Vector2) transform.position).normalized;
            
            GameObject currentBullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bulletInstantiated?.Invoke();
            
            EnemyBullet currentBulletMovement = currentBullet.GetComponent<EnemyBullet>();
            currentBulletMovement.MoveSpeed = 3 + Mathf.Sin((currentAngle * Mathf.PI) / 180 * 5);
            currentBulletMovement.MoveDirection = bulletDirection;
            
            
            
            currentAngle += angleStep;
            
        }
    }
    
    void OnFire3()
    {
        float angleStep = (EndAngle - StartAngle) / Bullets;
        
        float currentAngle = StartAngle;
        
        for(int i = 0; i < Bullets; i++)
        {
            float dirX = transform.position.x + Mathf.Sin((currentAngle * Mathf.PI) / 180);
            float dirY = transform.position.y + Mathf.Cos((currentAngle * Mathf.PI) / 180);
            
            
            Vector2 bulletPosition = new Vector2(dirX, dirY);
            Vector2 bulletDirection = (bulletPosition - (Vector2) transform.position).normalized;
            
            GameObject currentBullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bulletInstantiated?.Invoke();
            
            EnemyBullet currentBulletMovement = currentBullet.GetComponent<EnemyBullet>();
            currentBulletMovement.MoveSpeed = 4;
            currentBulletMovement.MoveDirection = bulletDirection;
            
            
            float dir2X = transform.position.x + Mathf.Sin(((currentAngle - 20) * Mathf.PI * -1) / 180);
            float dir2Y = transform.position.y + Mathf.Cos(((currentAngle - 20) * Mathf.PI * -1) / 180);
            
            
            Vector2 bulletPosition2 = new Vector2(dir2X, dir2Y);
            Vector2 bulletDirection2 = (bulletPosition2 - (Vector2) transform.position).normalized;
            
            GameObject currentBullet2 = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bulletInstantiated?.Invoke();
            
            EnemyBullet currentBulletMovement2 = currentBullet2.GetComponent<EnemyBullet>();
            currentBulletMovement2.MoveSpeed = 4;
            currentBulletMovement2.MoveDirection = bulletDirection2;
            
            
            
            currentAngle += angleStep;
            
        }
    }
    
}
