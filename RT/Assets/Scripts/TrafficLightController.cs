using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLightController : MonoBehaviour
{
    [HideInInspector] public TrafficLight currentLight = null;

    [Header("Light Component Link's")]
    [Space]
    public TrafficLight redLight = null;
    public TrafficLight yellowLight = null;
    public TrafficLight greenLight = null;

    [Header("Material Link's")]
    [Space]
    [SerializeField] private Material offLightMaterial = null;

    [Header("Component Link's")]
    [Space]
    [SerializeField] private Text textContainer = null;

    [HideInInspector] public bool canMove = false;

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
        textContainer.text = "Смена сигнала!";

        yield return new WaitForSeconds(yellowLight.time);

        redLight.meshRenderer.material = offLightMaterial;
        yellowLight.meshRenderer.material = offLightMaterial;
        greenLight.meshRenderer.material = greenLight.lightMaterial;
        currentLight = greenLight;
        textContainer.text = null;

        yield return new WaitForSeconds(greenLight.time);

        redLight.meshRenderer.material = offLightMaterial;
        yellowLight.meshRenderer.material = offLightMaterial;
        greenLight.meshRenderer.material = offLightMaterial;

        StartCoroutine(LightCycle());
    }
}
