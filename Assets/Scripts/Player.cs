using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerID = -1;
    public float playerMoney = 0;
    
    //
    public bool pickUp = false;
    public bool dropOff = false;
    public bool specialNode = false;

    //Quest Selector
    public bool finishedQuest; // atur lagi
    public Quest activeQuest;
    public QuestSelector questSelector;

    //Node Selector
    public bool specialNodeResolved = true;

    private void Update()
    {
        ///DEBUGING ONLY
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (activeQuest != null)
                Debug.Log("ACTIVE QUEST (pickup " + activeQuest.pickupNode + " |des " + activeQuest.destinationNode + ")");
            else Debug.Log(activeQuest + " activeQuest");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("MONEY :" +playerMoney);
        }
    }

    // Check Node Menunjukan Trigger pada Player
    public void CheckNode(Node currentNode)
    {

        if (currentNode == activeQuest.pickupNode)
        {
            pickUp = true;
            //trigger anim if avaialable
        }

        if (currentNode == activeQuest.destinationNode && pickUp)
        {

            dropOff = true;

            playerMoney += activeQuest.reward;
            activeQuest = null;// hanya null isi variable dari class (class != null / activeQuest != null )

            finishedQuest = true; // mark klo ga ada quest

            questSelector.OpenQuestSelector(playerID);
            // triger anim if avaialble
            
        }

        //check klo kena special node 
        string a = currentNode.GetNodeType();
        Debug.Log("tag : " + a);
        string b = "special";
        Debug.Log("test : " + b);
        if (a.Equals(b))
        {
            
            specialNode = true;
            specialNodeResolved = false;
            Debug.Log("SPECIAL NODE");
            // melakukan special Node shenanigans
            //GET NODE
        }
    }

    // Menambah Quest Baru Pada 
    public void SetQuest (Quest qt) // SET ACTIVE QUEST WAJIB PAKE INI
    {
        activeQuest = qt;
        dropOff = false;
        pickUp = false;
        finishedQuest = false;
    }

    public void SpecialNodeResolved()
    {
        specialNodeResolved = true;
        specialNode = false;
    }


}
