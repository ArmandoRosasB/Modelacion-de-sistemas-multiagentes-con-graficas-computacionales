using System.Collections;
using System.Collections.Generic;
using UnityEngine; // Para la clase JsonUtility

using System.Net;
using System.IO;

public static class APIHelper
{
    public static Joke GetNewJoke()
    {
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create("https://api.chucknorris.io/jokes/random"); // CREAMOS LA PETICION
        
        HttpWebResponse response = (HttpWebResponse) request.GetResponse(); // OBTENEMOS LA RESPUESTA
        
        StreamReader reader = new StreamReader(response.GetResponseStream());
        
        string json = reader.ReadToEnd(); // LEEMSO LA RESPUESTA COMO STRING
        
        return JsonUtility.FromJson<Joke> (json); // REGRESAMOS UN OBJETO DE TIPO JOKE
    
    
    }
}
