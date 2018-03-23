using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class WeatherGrabber : MonoBehaviour {
    	
    private const string URL = "https://api.weather.gov//stations/KMRY/observations/current";
    public Text wxText;
    public Text JSONText;
    public string jsonString;
    public Text uitext;
    public float temperature;
    public float windSpeed;
    public int windDir;
    public float windGust;
    public float BarometricPressure;


    public void Request()
    {
        WWW request = new WWW(URL);
        StartCoroutine(OnResponse(request));
    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;
        jsonString = req.text;
        getWeather();
    }
    
    public void getWeather()
    {
        Observation thisObs = JsonUtility.FromJson<Observation>(jsonString);
        Properties thisObsProperties = thisObs.properties;
        WindDirection thisObsWindDirection = thisObsProperties.windDirection;
        WindSpeed thisObsWindSpeed = thisObsProperties.windSpeed;
        Temperature thisObsTemp = thisObsProperties.temperature;
        BarometricPressure thisObsBaro = thisObsProperties.barometricPressure;

        temperature = thisObsTemp.value;
        windSpeed = thisObsWindSpeed.value;
        windDir = thisObsWindDirection.value;
        BarometricPressure = thisObsBaro.value;
        
    string rawObservation = thisObsProperties.rawMessage;
        uitext.text = thisObs.properties.windDirection.value.ToString();
        Debug.Log(windDir.ToString() + " /"+ windSpeed );
    }
}
