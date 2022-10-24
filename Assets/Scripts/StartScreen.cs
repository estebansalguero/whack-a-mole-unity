using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void onPressStart()
    {
        SceneController scene = FindObjectOfType<SceneController>();
        scene.NextScene();
    }
}
