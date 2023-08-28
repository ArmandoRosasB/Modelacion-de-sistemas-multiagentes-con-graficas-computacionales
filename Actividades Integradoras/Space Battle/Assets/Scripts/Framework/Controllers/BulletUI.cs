using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class BulletUI : MonoBehaviour
{

    public TextMeshProUGUI bulletText;
    private int bullets = 0;
    
    // Esta funcion se llama cuando el objeto esta habilitado y activo 
    public void OnEnable()
    {	
    	// Accion += Funcion
        ShooterController.bulletInstantiated += PlusCount;
        BulletHell.bulletInstantiated += PlusCount;
        
        Bullet.bulletDestroyed += MinusCount;
        EnemyBullet.bulletDestroyed += MinusCount; 

    }

    // Esta funcion se llama cuando el objeto esta inhabilitado e inactivo 
    public void OnDisable()  
    {
    	// Accion -= Funcion
        ShooterController.bulletInstantiated -= PlusCount;
        Bullet.bulletDestroyed -= MinusCount;
    }
    
    private void PlusCount()
    {
        bullets++;
        bulletText.text = $"Conteo de balas: {bullets.ToString("0")}";
    
    }
    
    private void MinusCount()
    {
        bullets--;

        bulletText.text = $"Conteo de balas: {bullets.ToString("0")}";

    }
}
