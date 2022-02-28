using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class NPCDialogueBranch
{
    [Serializable]
    private class branchOption
    {
        [SerializeField] String branchChoice;
        [SerializeField] branch nextBranch;
    }

    [Serializable]
    public class branch
    {
        [SerializeField] public String dialogueID;
        [SerializeField] public String dialogueText;
        [SerializeField] public String dialogueNext;
    }

    [SerializeField] public branch startBranch;
    [NonSerialized] public branch currentBranch;
    [SerializeField] private branch[] dialogueBranches;

    public void initialize()
    {
        currentBranch = startBranch;
    }

    public bool findNextBranch()
    {
        for (int i = 0; i < dialogueBranches.Length; i++)
        {
            if (dialogueBranches[i].dialogueID == currentBranch.dialogueNext)
            {
                currentBranch = dialogueBranches[i];
                return true;
            }
        }
        return false;
    }
}
