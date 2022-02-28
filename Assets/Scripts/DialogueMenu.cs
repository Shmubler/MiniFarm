using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class DialogueMenu : MonoBehaviour
{
    [SerializeField] public GameObject NPCImage;
    [SerializeField] public TextMeshProUGUI NPCName;
    [SerializeField] public TextMeshProUGUI NPCDialogue;
    [NonSerialized] PlayerMovementKeyboard playerObject;
    [NonSerialized] NPCDialogueBranch NPCBranch;

    public void Start()
    {
        playerObject = GameObject.FindObjectOfType<PlayerMovementKeyboard>();
    }

    public void startDialogue(NPCDialogueBranch branch, Sprite image, String name)
    {
        branch.initialize();
        NPCImage.GetComponent<Image>().sprite = image;
        NPCName.text = name;
        NPCDialogue.text = branch.currentBranch.dialogueText;
        NPCBranch = branch;
    }

    public void nextStep()
    {
        if (NPCBranch.findNextBranch())
        {
            NPCDialogue.text = NPCBranch.currentBranch.dialogueText;
        }
        else
        {
            playerObject.playerState = PlayerStates.Free;
            gameObject.SetActive(false);
        }
    }
}
