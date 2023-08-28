using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    float timeCounter = 0;
    float xOffset = 6f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter -= Time.deltaTime;
        float x = Mathf.Cos (timeCounter);
        float y = Mathf.Sin (timeCounter);
        float z = 1;
        transform.position = new Vector3 (x + xOffset, y, z);
    }
}
