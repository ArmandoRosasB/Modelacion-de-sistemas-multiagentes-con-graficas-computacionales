using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System; // Libreria para poder trabajar con las funciones generales del sistema

public class TimeManager : MonoBehaviour
{
    // Nos permitirán lanzar eventos
    public static Action OnMinuteChanged; 
    public static Action OnHourChanged;
    
    

    public static int Minute{get; private set;}
    public static int Hour{get;private set;}

    private float minuteToRealTime = 0.5f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Minute = 0;
        Hour = 10;
        timer = minuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0) // Cuando pase medio segundo (Un minuto en la simulacion)
        {
            
            OnMinuteChanged?.Invoke(); // Invocamos el evento de minuto
            Minute++;
            
            if (Minute >= 60) // Cuando haya pasado una hora en la simulacion
            {
                Hour++;
                Minute = 0;
                OnHourChanged?.Invoke(); // Invocamos el evento de hora
                
            
            }
            
            timer = minuteToRealTime; // Reseteamos
        }
    }
}
