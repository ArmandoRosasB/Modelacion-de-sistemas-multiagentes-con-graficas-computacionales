// Librerias Basicas para trabajar con Untiy
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour // Clase heredada de MonoBehavior
{
    //velocidad del vehículo
    public float speed = 20.0f;
    public float turnSpeed = 20.0f;
    public float horizontalInput;
    
    
    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	horizontalInput = Input.GetAxis("Horizontal");
    	
        //Mover vehiculo hacia adelante
    	transform.Translate(Vector3.forward * Time.deltaTime * speed); // Time.deltaTime: Tiempo que transcurre entre cada llamada al update
    	transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput); // Girar a la derecha
    }
}
