using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButton : MonoBehaviour
{
    [SerializeField] private GameObject talkButton;
    private CharachterStateMachine charachter;

    private void Awake()
    {
        charachter = GameObject.FindGameObjectWithTag("Player").GetComponent<CharachterStateMachine>();
        if (charachter == null)
        {
            Debug.LogWarning("Null");
            return;
        }
    }

    public void StartButton()
    {
        Debug.Log("Change");
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SceneChanger>().ChangeScene();
    }

    public void TalkButton(GameObject newTalkButtion, bool active)
    {
        Debug.Log("Talk Button Opened");
        talkButton = newTalkButtion;
        talkButton.SetActive(active);
        charachter.ableToTalk = active;
    }
}
