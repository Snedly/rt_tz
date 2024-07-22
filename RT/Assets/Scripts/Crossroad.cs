using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Crossroad : MonoBehaviour
{
    [Header("Main")]
    [Space]
    [SerializeField] private Transform initialPosition;

    [Space(20)]

    [Header("Components")]
    [Space]
    [SerializeField] private ScoreSystem scoreSystem = null;
    [SerializeField] private TrafficLightController trafficController = null;
    [SerializeField] private CarController carController = null;
    [SerializeField] private Text textContainer = null;

    private bool gameOver = false;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CarController>())
        {
            if (trafficController.currentLight == trafficController.redLight)
            {
                textContainer.color = Color.red;
                textContainer.text = "Игра окончена! Вы нарушили правила!" +
                    "\n Нажмите кнопку ПРОБЕЛ для начала игры!";

                Time.timeScale = 0f;
                gameOver = true;
            }
            else if (trafficController.currentLight == trafficController.yellowLight)
            {
                scoreSystem.scoreAmount += 5;
                scoreSystem.UpdateScoreText();
            }
            else if (trafficController.currentLight == trafficController.greenLight)
            {
                scoreSystem.scoreAmount += 10;
                scoreSystem.UpdateScoreText();
            }

            ReturnCar();
        }
    }

    private void Update()
    {
        if(gameOver)
        {
            if (Input.GetKey(KeyCode.Space)) SceneManager.LoadScene("SampleScene");
        }
    }

    private void ReturnCar()
    {
        carController.transform.position = Vector3.MoveTowards(carController.transform.position, initialPosition.position, 100f);
    }
}
