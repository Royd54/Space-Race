using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLightsEvent : MonoBehaviour
{
    [SerializeField] private Light[] _lights;
    [SerializeField] private float _smoothing = 2;
    [SerializeField] private bool _on;

    private void Start()
    {
        GameEvents.instance.onLightstrigger += OnLightsTrigger;
    }

    private void Update()
    {
       if(_on) { StartCoroutine(lightsOnAndOff()); }
    }

    private IEnumerator lightsOnAndOff()
    {
        IntensityChangeDown();
        yield return new WaitForSeconds(2);
        IntensityChangeUp();
        _on = false;
    }

    private void IntensityChangeDown()
    {
        float goalIntensity = 0f;
        foreach(Light light in _lights)
        {
            light.intensity = Mathf.Lerp(light.intensity, goalIntensity, _smoothing);
        }
    }

    private void IntensityChangeUp()
    {
        float goalIntensity = 1.33f;
        foreach (Light light in _lights)
        {
            light.intensity = Mathf.Lerp(light.intensity, goalIntensity, _smoothing);
        }
    }

    private void OnLightsTrigger()
    {
        _on = true;
    }
}
