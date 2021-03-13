using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public static UIController instance;

    private void Start()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadImageTrackerScene() => SceneManager.LoadScene("ImageTracker");

    public void LoadPlaneTrackerScene() => SceneManager.LoadScene("Plane");
}
