using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MultiTouchButtonController : MonoBehaviour
{
    // Время, через которое кнопка снова станет взаимодействующей после отжатия всех пальцев.
    public float interactionDelay = 1.0f;

    private bool isInteractable = true;
    private float lastTouchTime = 0f;

    [SerializeField] private GameObject[] buttons;

    void Start()
    {
        // Находим все объекты с компонентом Button на сцене, включая неактивные.
        //GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");

        foreach (GameObject button in buttons)
        {
            // Добавляем метод обработки событий для отслеживания касаний каждой кнопки.
            Button btnComponent = button.GetComponent<Button>();
            if (btnComponent != null)
            {
                btnComponent.onClick.AddListener(() => HandleButtonClick());
            }
        }
    }

    void HandleButtonClick()
    {
        // Если кнопки взаимодействующие, отключаем их все.
        if (!isInteractable)
            return;

        isInteractable = false;
        lastTouchTime = Time.time;

        // Отключаем все кнопки.
        DisableAllButtons();

        // Запускаем корутину для восстановления интерактивности всех кнопок после задержки.
        StartCoroutine(EnableAllButtonsAfterDelay());
    }

    void DisableAllButtons()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");

        foreach (GameObject button in buttons)
        {
            Button btnComponent = button.GetComponent<Button>();
            if (btnComponent != null)
            {
                btnComponent.interactable = false;
            }
        }
    }

    IEnumerator EnableAllButtonsAfterDelay()
    {
        yield return new WaitForSeconds(interactionDelay);

        // Если прошло достаточно времени, включаем все кнопки.
        if (Time.time - lastTouchTime >= interactionDelay)
        {
            GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");

            foreach (GameObject button in buttons)
            {
                Button btnComponent = button.GetComponent<Button>();
                if (btnComponent != null)
                {
                    btnComponent.interactable = true;
                }
            }
            isInteractable = true;
        }
    }
}
