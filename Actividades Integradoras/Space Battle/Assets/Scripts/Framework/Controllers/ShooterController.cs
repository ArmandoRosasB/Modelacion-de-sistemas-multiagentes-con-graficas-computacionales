using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class ShooterController : MonoBehaviour
{

    [SerializeField]
    private Transform shooterController; // Posicion del lugar donde se va a disparar
    
    [SerializeField]
    private GameObject bullet;
    
    public static Action bulletInstantiated;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // CLick derecho del mouse (default)
        {
            Disparar();
        }
    }
    
    private void Disparar()
    {
        Instantiate(bullet, shooterController.position, shooterController.rotation);
        bulletInstantiated?.Invoke();

    }
}
