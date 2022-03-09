using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontController : MonoBehaviour
{
    private Text text;
    private string originalText;

    // Next update in second
    [SerializeField] //[SerializeField] Allows the private field to show up in Unity's inspector. Way better than just making it public
    private double updateFrequency = 1;

    private double startTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        originalText = text.text.ToString();
        text.text = RandomMenuColor();
    }

    // Update is called once per frame
    void Update()
    {
        // If the next update is reached
        if (updateFrequency > 0 && Time.time >= startTime)
        {
            //Debug.Log(Time.time + ">=" + updateFrequency);
            startTime = Time.time + updateFrequency;
            text.text = RandomMenuColor();
        }
    }

    string RandomTextColor()
    {
        string[] colors = {
            "049CD8", //Blue
            "FBD000", //Yellow
            "E52521", //Red
            "43B047" //Green
        };
        int index = Random.Range(0, colors.Length);
        return colors[index];
    }


    string RandomMenuColor()
    {

        char[] textArray = originalText.ToCharArray();
        string finalText = "";
        string previousColor = RandomTextColor();
        for(int i = 0; i<textArray.Length; i++)
        {
            if(textArray[i]!=" ".ToCharArray()[0])
            {
                string newColor = RandomTextColor();
                while (newColor == previousColor)
                {
                    newColor = RandomTextColor();
                }
                previousColor = newColor;
                finalText += "<color=#" + newColor + ">" + textArray[i] + "</color>";
            }
            else
            {
                finalText += textArray[i];
            }
            
        }
        return finalText;
    }
}
