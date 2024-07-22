using System.Collections;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    [Header("MainSettings")]
    [Space]
    [SerializeField] private TrafficLight currentLight = null;

    [Space(30)]

    [Header("Light Component Link's")]
    [Space]
    [SerializeField] private TrafficLight redLight = null;
    [SerializeField] private TrafficLight yellowLight = null;
    [SerializeField] private TrafficLight greenLight = null;

    [Header("Material Link's")]
    [Space]
    [SerializeField] private Material offLightMaterial = null;

    public bool canMove = false;

    private void Start()
    {
        StartCoroutine(LightCycle());
    }

    private void Update()
    {
        if (currentLight == redLight) canMove = false;
        else canMove = true;
    }

    private IEnumerator LightCycle()
    {
        redLight.meshRenderer.material = redLight.lightMaterial;
        currentLight = redLight;
        yield return new WaitForSeconds(redLight.time);

        redLight.meshRenderer.material = offLightMaterial;
        yellowLight.meshRenderer.material = yellowLight.lightMaterial;
        currentLight = yellowLight;

        yield return new WaitForSeconds(yellowLight.time);

        redLight.meshRenderer.material = offLightMaterial;
        yellowLight.meshRenderer.material = offLightMaterial;
        greenLight.meshRenderer.material = greenLight.lightMaterial;
        currentLight = greenLight;

        yield return new WaitForSeconds(greenLight.time);

        redLight.meshRenderer.material = offLightMaterial;
        yellowLight.meshRenderer.material = offLightMaterial;
        greenLight.meshRenderer.material = offLightMaterial;

        StartCoroutine(LightCycle());
    }
}
