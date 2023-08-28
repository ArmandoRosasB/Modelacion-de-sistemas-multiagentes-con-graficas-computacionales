using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class TimeManager : MonoBehaviour
{

    public static Action OnSecondChange;
    
    
    public static int Second {get; private set;}
    public float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        Second = 0;
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            Second++;
            OnSecondChange?.Invoke();
            
            if (Second >= 30)
            {
                Second = 0;
            }
            
            timer = 1;
        }
    }
}
