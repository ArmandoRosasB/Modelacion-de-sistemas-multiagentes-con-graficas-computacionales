using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; // Libreria para trabajar con TextMeshPro

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    
    // Esta funcion se llama cuando el objeto esta habilitado y activo 
    public void OnEnable()
    {	
    	// Accion += Funcion
        TimeManager.OnMinuteChanged += UpdateTime; 
        TimeManager.OnHourChanged += UpdateTime;
    }

    // Esta funcion se llama cuando el objeto esta inhabilitado e inactivo 
    public void OnDisable()  
    {
    	// Accion -= Funcion
        TimeManager.OnMinuteChanged -= UpdateTime;
        TimeManager.OnHourChanged -= UpdateTime;
    }
    
    private void UpdateTime()
    {
        timeText.text = $"{TimeManager.Hour.ToString("00")}: {TimeManager.Minute:00}";
    
    }
}
