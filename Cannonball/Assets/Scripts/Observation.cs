using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class Observation{

    public List<object> context; 
    public string id; 
    public string type; 
    public Geometry geometry; 
    public Properties properties;
}
[System.Serializable]
public class Geometry
{
    public string type ;
    public List<double> coordinates ;
}
[System.Serializable]
public class Properties
{
    public string propID ;
    public string propType ;
    public string elevation ;
    public string station ;
    public string timestamp ;
    public string rawMessage ;
    public string textDescription ;
    public string icon ;
    public List<string> presentWeather ;
    public Temperature temperature ;
    public string dewpoint ;
    public WindDirection windDirection ;
    public WindSpeed windSpeed ;
    public string windGust ;
    public BarometricPressure barometricPressure ;
    public string seaLevelPressure ;
    public string visibility ;
    public string maxTemperatureLast24Hours ;
    public string minTemperatureLast24Hours ;
    public string precipitationLastHour ;
    public string precipitationLast3Hours ;
    public string precipitationLast6Hours ;
    public string relativeHumidity ;
    public string windChill ;
    public string heatIndex ;
    public List<string> cloudLayers ;
}


public class PresentWeather
{
    public string intensity ;
    public object modifier ;
    public string weather ;
    public string rawString ;
}
[System.Serializable]
public class Temperature
{
    public float value ;
    public string unitCode ;
    public string qualityControl ;
}

[System.Serializable]
public class Dewpoint
{
    public double value ;
    public string unitCode ;
    public string qualityControl ;
}
[System.Serializable]
public class WindDirection
{
    public int value;
    public string unitCode;
    public string qualityControl;
}

[System.Serializable]
public class WindSpeed
{
    public float value;
    public string unitCode;
    public string qualityControl;
}
[System.Serializable]
public class WindGust
{
    public float value;
    public string unitCode;
    public string qualityControl ;
}
[System.Serializable]
public class BarometricPressure
{
    public int value ;
    public string unitCode ;
    public string qualityControl ;
}
[System.Serializable]
public class SeaLevelPressure
{
    public int value ;
    public string unitCode ;
    public string qualityControl ;
}
[System.Serializable]
public class Visibility
{
    public int value ;
    public string unitCode ;
    public string qualityControl ;
}