using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneManagement : MonoBehaviour
{
    public int ButtonNumber;

    // Update is called once per frame
    void Update()
    {
        var pointer = Pointer.current;
        if (pointer.press.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(pointer.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                OnMouseDown(ButtonNumber);
        }
    }

    static void OnMouseDown(int number)
    {
        switch (number)
        {
            case 1:
                SceneManager.LoadScene(sceneName: "Area1");
                break;
            case 2:
                SceneManager.LoadScene(sceneName: "Area2");
                break;
            case 3:
                SceneManager.LoadScene(sceneName: "Area3");
                break;
            case 4:
                SceneManager.LoadScene(sceneName: "Area4");
                break;
            case 5:
                SceneManager.LoadScene(sceneName: "Area5");
                break;

        }
    }
}
