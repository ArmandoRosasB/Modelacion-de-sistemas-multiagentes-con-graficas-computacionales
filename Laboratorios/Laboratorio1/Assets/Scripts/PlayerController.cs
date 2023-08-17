// Librerias Basicas para trabajar con Untiy
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour // Clase heredada de MonoBehavior
{
    //velocidad del vehículo
    public float speed = 20.0f;
    
    // Velocidad de rotacion
    public float turnSpeed = 45.0f;
    
    
    public float horizontalInput;
    public float forwardInput;
    
    
    // Variables de camara
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey; // Tecla que permite cambiar entre camaras
    
    
    // Varaibles de multijugador
    public string inputId;
    
    
    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	horizontalInput = Input.GetAxis("Horizontal" + inputId);
    	forwardInput = Input.GetAxis("Vertical" + inputId);
    	
        //Mover el vehiculo sobre el eje z
    	transform.Translate(Vector3.forward * Time.deltaTime * speed *  forwardInput); // Time.deltaTime: Tiempo que transcurre entre cada llamada al update
    	
    	// Mover el vehiculo sobre el eje x
    	// transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
    	
    	// Rota el objeto
    	transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput); // Rotacion
    	
    	
    	
    	// Cambio entre camaras
    	if (Input.GetKeyDown(switchKey)) 
    	{
    	    mainCamera.enabled = !mainCamera.enabled;
    	    hoodCamera.enabled = !hoodCamera.enabled;
    	}
    }
}
