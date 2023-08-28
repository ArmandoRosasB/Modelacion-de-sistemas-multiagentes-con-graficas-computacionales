using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private Vector2 velocity; // Velocidad de movimiento
    
    private Vector2 offset; 
    private Material material;
    
    private void Awake() {
        material = GetComponent<Renderer>().material;
    }
    
    private void Update(){
       offset +=  velocity * Time.deltaTime;
       material.SetTextureOffset("_MainTex", offset);
    }
}
