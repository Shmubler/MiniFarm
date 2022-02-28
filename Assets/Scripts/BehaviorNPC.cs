using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BehaviorNPC : MonoBehaviour
{
    [NonSerialized] private GameObject playerObject;

    [Header("NPC Information")]
    [SerializeField] public Sprite NPCImage;
    [SerializeField] public String NPCName;

    [Header("PlayerInteraction")]
    [SerializeField] private GameObject dialogueIndicator;

    [Header("Dialogue")]
    [SerializeField] private NPCDialogueBranch dialogueBranch;
    [NonSerialized] private DialogueMenu NPCDialogueMenu;

    // Start is called before the first frame update
    void Start()
    {
        dialogueIndicator.SetActive(false);
        NPCDialogueMenu = GameObject.FindObjectOfType<DialogueMenu>();
        NPCDialogueMenu.gameObject.SetActive(false);
        //NPCDialogueMenu = GameObject.FindGameObjectWithTag("DialogueMenu").GetComponent<DialogueMenu>();

        playerObject = GameObject.FindObjectOfType<PlayerMovementKeyboard>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (testPlayerDistance() && playerObject.gameObject.GetComponent<PlayerMovementKeyboard>().playerState != PlayerStates.Dialogue)
        {
            dialogueIndicator.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                doDialogue();
            }
        }
        else
        {
            dialogueIndicator.SetActive(false);
        }
    }

    bool testPlayerDistance()
    {
        if (Mathf.Abs((playerObject.transform.position - gameObject.transform.position).magnitude) < 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void doDialogue()
    {
        if (NPCDialogueMenu == null)
        {
            Debug.Log("Why are you null");
            NPCDialogueMenu = GameObject.FindObjectOfType<DialogueMenu>();
        }

        playerObject.GetComponent<PlayerMovementKeyboard>().playerState = PlayerStates.Dialogue;
        NPCDialogueMenu.gameObject.SetActive(true);

        //Debugging
        if (dialogueBranch == null) { Debug.Log("dialogueBranch = null"); }
        if (NPCImage == null) { Debug.Log("NPCImage = null"); }
        if (NPCName == null) { Debug.Log("NPCName = null"); }
        if (NPCDialogueMenu == null) { Debug.Log("NPCDialogueMenu = null"); }

        NPCDialogueMenu.startDialogue(dialogueBranch, NPCImage, "Ned"); 
    }
}
