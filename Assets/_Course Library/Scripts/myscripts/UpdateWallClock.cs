using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateWallClock : MonoBehaviour
{
    // Start is called before the first frame update
    public float X, Y, Z = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform secondHand = transform.Find("Clock_Analog_A_Second"); //get the tranform of the GameObject
        Transform minuteHand = transform.Find("Clock_Analog_A_Minute"); //get the tranform of the GameObject
        Transform hourHand = transform.Find("Clock_Analog_A_Hour"); //get the tranform of the GameObject

        if (secondHand != null && minuteHand != null && hourHand != null)
        {
            float secDeg = DateTime.Now.Second * 6;
            float minDeg = DateTime.Now.Minute * 6;

            //this adject for 24-hour clocks since the logic is (1 - 12) * 30degs so 1 is 30deg and 12 is 360degs
            float hourDeg = ((DateTime.Now.Hour > 12) ? DateTime.Now.Hour - 12 : DateTime.Now.Hour) * 30;

            // here we are adjusting the hour hand slowly towards the next hand which is 30 degs away... do it means the hand moves (0-59) *0.5 is movement of 30degs
            hourDeg = hourDeg + (float)(DateTime.Now.Minute * 0.5); // for example at 3:00 hourdeg is at 90deg , at 3:30 it is at 90 + (30 *0.5) == 90 + 15 = 105degs

            //secondHand.Rotate(180f, 0.0f, 0.0f, Space.World);
            secondHand.localRotation = Quaternion.Euler(secDeg, 0f, 0f);
            minuteHand.localRotation = Quaternion.Euler(minDeg, 0f, 0f);
            hourHand.localRotation = Quaternion.Euler(hourDeg, 0f, 0f);
        }
    }
}
