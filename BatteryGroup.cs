using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryGroup : MonoBehaviour {

    public GameObject[] totalBattery;
    public int batteryCount = 0;
    public int batteryAdded = 0;
    private static int batPower = 5;
    public bool isbatteryReloaded;
    public bool isnoBattery;
    GUISkin messageSkin;

	// Use this for initialization
	void Start () {
        totalBattery = GameObject.FindGameObjectsWithTag("batteryCollider");
        batteryCount = totalBattery.Length;
	}
	
	// Update is called once per frame
	void Update () {
        totalBattery = GameObject.FindGameObjectsWithTag("batteryCollider");
        countBattery();
        batteryReload();
	}

    public void countBattery()
    {
        if (totalBattery.Length < batteryCount)
        {
            batteryAdded += 1;
            batteryCount = totalBattery.Length;
            isnoBattery = false;
        }
    }

    public void batteryReload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (batteryAdded != 0)
            {
                FlashLight.ReloadPower(batPower);
                FlashLight.drainTime = 10.0f;
                FlashLight.drainStart = false;
                batteryAdded -= 1;
                isbatteryReloaded = true;
                StartCoroutine("batteryReloadMessage");
            }
            else
            {
                isnoBattery = true;
                StartCoroutine("noBatteryMessage");
            }
        }
    }

    void OnGUI()
    {
        GUI.skin = messageSkin;
        GUI.color = Color.red;
        if (isnoBattery == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 55, 120, 50), "No Battery in Inventory");
        }

        if (isbatteryReloaded == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 55, 120, 50), "Battery Reloaded");
        }

        GUI.Label(new Rect(50, 50, 120, 50), "Battery Added :- " + batteryAdded);
    }

    IEnumerator noBatteryMessage()
    {
        yield return new WaitForSeconds(3);
        isnoBattery = false;
    }

    IEnumerator batteryReloadMessage()
    {
        yield return new WaitForSeconds(3);
        isbatteryReloaded = false;
    }
}
