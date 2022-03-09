using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{

    public Text fuelText;
    Vector2 move;
    public float fuel;
    // Start is called before the first frame update
    void Start()
    {
        fuelText = GetComponent<Text>();
        fuel = 1.0f;
        //fuelText.text = $"Fuel: {(float)Math.Round(fuel * 100f) / 100f}";
        fuelText.text = $"Fuel: {fuel.ToString("0.00")}";
    }

    // Update is called once per frame
    void Update()
    {
        //Don't allow movement if there is no fuel
        if (fuel > 0f)
        {
            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");
        }
        
        //If movemment is detected
        if(move.x != 0f || move.y != 0f)
        {
            //Decrement fuel
            fuel -= Time.deltaTime;
            //If fuel goes negative, reset back to zero.
            if (fuel < 0f)
            {
                fuel = 0f;
            }
        }

        //fuelText.text = $"Fuel: {(float)Math.Round(fuel * 100f) / 100f}";
        //This leaves off the decimal when the value is a whole number.
        //fuelText.text = $"Fuel: {fuel.ToString("#.##")}";
        //0.00 will always show the values when the number is a whole number.
        fuelText.text = $"Fuel: {fuel.ToString("0.00")}";
    }
}
