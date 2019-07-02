using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPickUp : MonoBehaviour {

    public bool batteryInRange = false;
    GUISkin giSkin;

    void OnTriggerEnter(Collider playerEnter)
    {
        if (playerEnter.gameObject.tag == "Player")
        {
            batteryInRange = true;
        }
    }

    void OnTriggerExit(Collider playerExit)
    {
        if (playerExit.gameObject.tag == "Player")
        {
            batteryInRange = false;
        }
    }

    // Use this for initialization
    void Start () {

   
		
	}
	
	// Update is called once per frame
	void Update () {
        batteryCollect();
	}

    void batteryCollect()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (batteryInRange == true)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnGUI()
    {
        GUI.skin = giSkin;

        if (batteryInRange == true)
        {
            GUI.color = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 55, 120, 50), "PICK UP BATTERY");
        }
    }
}
