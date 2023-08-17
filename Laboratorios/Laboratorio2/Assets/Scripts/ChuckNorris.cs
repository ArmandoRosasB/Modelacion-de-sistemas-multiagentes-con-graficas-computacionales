using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Libreria para poder trabajar con TextMeshPro
using TMPro;

public class ChuckNorris : MonoBehaviour
{

    public TextMeshProUGUI jokeText; // Texto 
    
    
    public void NewJoke(){
    	// Aqui agregamos el codigo para llamar el API
    	Joke j = APIHelper.GetNewJoke();
    	jokeText.text = j.value;
    }
}
