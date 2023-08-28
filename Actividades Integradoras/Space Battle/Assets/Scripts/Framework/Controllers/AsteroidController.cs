using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
	
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnEnable()
    {
 
        TimeManager.OnSecondChange += TimeCheck;

    }
    
    public void OnDisable()
    {

        TimeManager.OnSecondChange -= TimeCheck;

    }
    
    
    private void TimeCheck()
    {
        if(TimeManager.Second % 7 == 0)
        {
            StartCoroutine(MoveAsteroid());
        }
    }
    
    private IEnumerator MoveAsteroid()
    {
        System.Random random = new System.Random();
        
        transform.position = new Vector3((float) random.NextDouble() * (8f) -8f, 6f , 1f);
        Vector3 targetPos = new Vector3(transform.position.x, -7f, 1f);
        
        Vector3 currentPos = transform.position;
        
        float timeElapsed = 0;
        float timeToMove = 4;
       
        while (timeElapsed < timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos, targetPos, timeElapsed/timeToMove);
            transform.Rotate(2f, 2f, 2f, Space.World);
            timeElapsed += Time.deltaTime;
            
            yield return null;
        }
    }
    

}
