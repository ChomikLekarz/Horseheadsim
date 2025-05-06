using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sceneBuildIndex: scene.buildIndex+1);
        Debug.Log("Active Scene is '" + scene.name + "'.");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
