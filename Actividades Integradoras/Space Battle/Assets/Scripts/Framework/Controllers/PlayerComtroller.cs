using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComtroller : MonoBehaviour
{

    public float velocity = 4;
    
    [SerializeField]
    private float horizontalInput;
    
    [SerializeField]
    private float verticalInput;
    
    
    private Vector3 target; // Posicion de mi objetivo
    
    [SerializeField]
    private Camera camera;
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       changePosition();
       changeRotation();
       	
        
        
    }
    
    void changePosition()
    {
    	horizontalInput = Input.GetAxis("Horizontal"); // Obtengo el valor
      // verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * velocity * horizontalInput);
        
      //  transform.Translate(new Vector2(1f, 0f) * Time.deltaTime * velocity * verticalInput);
    
    }
    
    void changeRotation()
    {
    	target = camera.ScreenToWorldPoint(Input.mousePosition);
       	float rad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x); // Obtengo el angulo entre la posicion de mi personaje y mi objetivo
       	
       	float deg = (180 / Mathf.PI) * rad - 270 ;
       	
       	transform.rotation = Quaternion.Euler(0, 0, deg); // Cambiar el angulo
    } 
    
    

}
