using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHelpers : MonoBehaviour
{
    public static string FloatToTime(float timeInput)
    {
        float time = timeInput;
        float hour = Mathf.Floor(timeInput);
        float minutes = timeInput - hour;
        int minuteInt = Mathf.FloorToInt(minutes * (60f));

        float seconds = minutes * 100 - Mathf.Floor(minutes * 100);
        int secondsInt = Mathf.FloorToInt(seconds * 60f);


        string outputString = hour.ToString("00") + ":" + minuteInt.ToString("00") + ":" + secondsInt.ToString("00");
        return outputString;
    }

    public static float Fuzzify(float value)
    {
        float randomizer = Random.Range(.8f, 1.2f);
        float newValue = value * randomizer;
        return newValue;
    }

    public static float Fuzzify(float value, float percentRange)
    {
        float centerpoint = value;
        float onePerCent = value * .01f;
        float lowOffset = value - (onePerCent * percentRange);
        float hiOffset = value + (onePerCent * percentRange);
        float randomizer = Random.Range(lowOffset, hiOffset);
        float newValue = randomizer;
        return newValue;
    }

    public static int MakeAChoice(int lowNumberInclusive, int highHumberInclusive)
    {
        int choiceOutput = Random.Range(lowNumberInclusive, highHumberInclusive);

        return choiceOutput;
    }

    public static string DayOfTheWeek(int dayNumber)
    {

        string weekday = "";
        int dayOfWeek = dayNumber;
        switch (dayOfWeek)
        {
            case 1:
                weekday = "Monday";
                break;
            case 2:
                weekday = "Tuesday";
                break;
            case 3:
                weekday = "Wednesday";
                break;
            case 4:
                weekday = "Thursday";
                break;
            case 5:
                weekday = "Friday";
                break;
            case 6:
                weekday = "Saturday";
                break;
            case 7:
                weekday = "Sunday";
                break;
            default:
                weekday = "error";
                break;
        }
        return weekday;
    } 
}
