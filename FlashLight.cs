using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour {

    public static Light lightSource;
    public static bool lightOn;
    public float lightDrain = 0.0f;
    public static float batteryLife = 0.0f;
    public float maxBatteryLife = 5.0f;
    public float barDisp=0;
    public Slider drainBatterySlider;
    public static bool drainStart;
    public static float drainTime;

	// Use this for initialization
	void Start () {
        batteryLife = maxBatteryLife;
        drainStart = false;
        drainTime = 10.0f;
        lightSource = GetComponent<Light>();
        lightSource.enabled = true;
        lightOn = true;
	}

    public static void ReloadPower(int reloadValue)
    {
        batteryLife = reloadValue;
        lightOn = true;
        lightSource.intensity = batteryLife;
        lightSource.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (lightOn && drainTime >= 0)
        {
            drainTime -= Time.deltaTime * 1.0f;
            Debug.Log("Drain Time :- " + drainTime);
        }

            if (drainTime <= 0)
            {
                drainStart = true;
            }

            if (drainStart)
            {
                if (lightOn && batteryLife >= 0)
                {
                    batteryLife -= Time.deltaTime / 2 * lightDrain;
                    lightSource.intensity = batteryLife;
                }
            }

            if (lightOn && batteryLife <= 0)
            {
                lightSource.intensity = 0;
                lightSource.enabled = false;
            }

            barDisp = batteryLife;
            drainBatterySlider.value = batteryLife;

            if (batteryLife <= 0)
            {
                batteryLife = 0;
                lightOn = false;
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                ToggleFlashLight();

                if (lightOn)
                {
                    lightOn = false;
                    drainStart = false;
                }
                else if (!lightOn && batteryLife >= 0)
                {
                    lightOn = true;
                }

            }
        }

    void ToggleFlashLight()
    {
        if (lightOn)
        {
            lightSource.enabled = false;
        }
        else
        {
            lightSource.enabled = true;
        }
    }
    
}
