using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Objeto que representa al jugador
    public GameObject player;
    
    // Distancia auxiliar para alejar la camara del jugador
    private Vector3 offset = new Vector3(0, 6, -7);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    // LateUpdate: Se llama despues del update
    void LateUpdate()
    {	
    		
    	// Cambia la posicion de la camara a la posicion del jugador mas el desfase
        transform.position = player.transform.position + offset;
    }
}
