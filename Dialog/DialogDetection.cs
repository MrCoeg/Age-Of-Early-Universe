using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogDetection : MonoBehaviour
{
    [SerializeField] public DialogLoader loader { get; private set; }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        loader =  collision.collider.gameObject.GetComponent<DialogLoader>();
        if (loader == null)
        {
            return;
        }

        uiButton.TalkButton(loader.talkButton, true);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (loader == null)
        {
            loader = collision.collider.gameObject.GetComponent<DialogLoader>();
            return;
        }
        uiButton.TalkButton(loader.talkButton, true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (loader == null)
        {
            loader = collision.collider.gameObject.GetComponent<DialogLoader>();
            return;
        }
        uiButton.TalkButton(loader.talkButton, false);
    }
}
