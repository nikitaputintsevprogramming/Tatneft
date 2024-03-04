using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MultiTouchButtonController : MonoBehaviour
{
    // �����, ����� ������� ������ ����� ������ ����������������� ����� ������� ���� �������.
    public float interactionDelay = 1.0f;

    private bool isInteractable = true;
    private float lastTouchTime = 0f;

    [SerializeField] private GameObject[] buttons;

    void Start()
    {
        // ������� ��� ������� � ����������� Button �� �����, ������� ����������.
        //GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");

        foreach (GameObject button in buttons)
        {
            // ��������� ����� ��������� ������� ��� ������������ ������� ������ ������.
            Button btnComponent = button.GetComponent<Button>();
            if (btnComponent != null)
            {
                btnComponent.onClick.AddListener(() => HandleButtonClick());
            }
        }
    }

    void HandleButtonClick()
    {
        // ���� ������ �����������������, ��������� �� ���.
        if (!isInteractable)
            return;

        isInteractable = false;
        lastTouchTime = Time.time;

        // ��������� ��� ������.
        DisableAllButtons();

        // ��������� �������� ��� �������������� ��������������� ���� ������ ����� ��������.
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

        // ���� ������ ���������� �������, �������� ��� ������.
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
