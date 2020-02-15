using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager SINGLETON;
    // Start is called before the first frame update
    void Start()
    {
        if (SINGLETON == null)
            SINGLETON = this;
        else Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!SceneManager.GetSceneByName("nameofscenetoload").isLoaded)
            {
                SceneManager.LoadSceneAsync("nameofscenetoload", LoadSceneMode.Additive);


            }
            else
            {
                SceneManager.UnloadSceneAsync("nameofscenetoload");
            }
        }
    }
}
