using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogLoader : MonoBehaviour
{
    [SerializeField] private DialogProperties[] conversation;
    [SerializeField] private int index;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogText;
    public SpriteRenderer sprites;
    [SerializeField] public GameObject talkButton { get; private set; }
    private void Start()
    {
        GameObject container = GameObject.FindGameObjectWithTag("Dialog");
        TextMeshProUGUI[] texts = container.GetComponentsInChildren<TextMeshProUGUI>();
        nameText = texts[0];
        dialogText = texts[1];
        nameText.text = "";
        dialogText.text = "";


        sprites = GetComponentsInChildren<SpriteRenderer>()[1];
        if (sprites == null)
        {
            Debug.LogWarning("sprites !ok");
            return;
        }
        talkButton = sprites.gameObject;
        talkButton.SetActive(false);
    }

    public void Talk()
    {
        if(index > conversation.Length - 1)
        {
            EndTalk();
            return;
        }

        nameText.text = conversation[index].spekaer;
        dialogText.text = conversation[index].dialog;
        index++;
    }

    public void EndTalk()
    {
        nameText.text = "";
        dialogText.text = "";
        index = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharachterStateMachine>().ableToTalk = false;
    }
}
