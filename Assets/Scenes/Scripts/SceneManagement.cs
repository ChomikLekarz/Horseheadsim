using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneManagement : MonoBehaviour
{
    public int ButtonNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        switch (ButtonNumber)
        {
            case 1:
                SceneManager.LoadScene(sceneName: "Area 1");
                break;
            case 2:
                SceneManager.LoadScene(sceneName: "Area 2");
                break;
            case 3:
                SceneManager.LoadScene(sceneName: "Area 3");
                break;
            case 4:
                SceneManager.LoadScene(sceneName: "Area 4");
                break;
            case 5:
                SceneManager.LoadScene(sceneName: "Area 5");
                break;

        }
    }
}
