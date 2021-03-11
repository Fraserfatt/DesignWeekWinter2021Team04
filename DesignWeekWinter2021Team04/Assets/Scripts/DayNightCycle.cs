using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    PolyverseSkiesType sky;
    int multiplier = 1;
    Material skyboxDay, skyboxNightSlot;

    Light directionalLight;

    [SerializeField]
    Color dayColour, nightColour;

    // Start is called before the first frame update
    void Start()
    {
        sky = GetComponent<PolyverseSkiesType>();
        skyboxDay = sky.skyboxDay;
        skyboxNightSlot = sky.skyboxNight;
        directionalLight = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sky.updateLighting)
        {
            DynamicGI.UpdateEnvironment();
        }

        sky.timeOfDay += sky.speed * Time.deltaTime * multiplier;
        directionalLight.color = Color.Lerp(dayColour, nightColour, sky.timeOfDay);

        if (sky.timeOfDay > 1 || sky.timeOfDay < 0)
        {
            multiplier *= -1;
        }
    }

}
