using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    public void OnEnable()
    {
        TimeManager.OnMinuteChanged += TimeCheck;
    }

    public void OnDisable()
    {
        TimeManager.OnMinuteChanged -= TimeCheck;
    }
    
    private void TimeCheck()
    {
        if (TimeManager.Minute % 30 == 0)
        {
            StartCoroutine(MoveTriangle());
        }
    }
    
    private IEnumerator MoveTriangle()
    {
        transform.position = new Vector3(-617f, -361f, 0);
        Vector3 targetPos = new Vector3(2031f, 700f, 0);
        
        Vector3 currentPos = transform.position;
        
        float timeElapsed = 0;
        float timeToMove = 5;
        
        while (timeElapsed < timeToMove) {
            transform.position = Vector3.Lerp(currentPos, targetPos, timeElapsed/timeToMove); // Mover una fraccion
            
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    
    }
}
