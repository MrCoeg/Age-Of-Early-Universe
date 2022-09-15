using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public void StartButton()
    {
        Debug.Log("Change");
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SceneChanger>().ChangeScene();
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
