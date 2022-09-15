using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogDetection : MonoBehaviour
{
    [SerializeField] public DialogLoader loader;
    [SerializeField] private UiButton uiButton;

    private void Start()
    {
        uiButton =  GameObject.FindGameObjectWithTag("Canvas").GetComponent<UiButton>(); 
        if (uiButton == null)
        {
            Debug.LogWarning("uiButton -> Dialog Detection -> Null");
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "DialogLoader")
        {
            return;
        }
        loader = collision.gameObject.GetComponent<DialogLoader>();
        if (loader == null)
        {
            return;
        }

        uiButton.TalkButton(loader.talkButton, true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "DialogLoader")
        {
            return;
        }
        loader = collision.gameObject.GetComponent<DialogLoader>();
        if (loader == null)
        {
            return;
        }

        uiButton.TalkButton(loader.talkButton, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "DialogLoader")
        {
            return;
        }
        loader = collision.gameObject.GetComponent<DialogLoader>();
        if (loader == null)
        {
            return;
        }

        uiButton.TalkButton(loader.talkButton, false);
    }
}
