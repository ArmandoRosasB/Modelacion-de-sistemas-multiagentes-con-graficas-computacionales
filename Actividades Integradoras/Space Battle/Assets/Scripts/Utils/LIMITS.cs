using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIMITS : MonoBehaviour
{

    private Transform transform;
    public Vector2 Hrange = Vector2.zero;
    public Vector2 Vrange = Vector2.zero;
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform> ();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3 (
            Mathf.Clamp(transform.position.x , Hrange.x, Hrange.y ),
            Mathf.Clamp(transform.position.y , Vrange.x, Vrange.y ),
            transform.position.z
            
        );
    }
}
