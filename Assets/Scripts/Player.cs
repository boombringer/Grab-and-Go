using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerID = -1;
    public float playerMoney = 0;

    //MovementState    
    public int steps = 0;

    //QuestState
    public bool pickUp = false;
    public bool dropOff = false;
    

    //Quest Selector
    public bool NoActiveQuest; // atur lagi
    public Quest activeQuest;
    public QuestSelector questSelector;

    //special node mode
    public bool specialNode = false;
    public bool effectResolved = false;

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
    public void CheckQuestNode(Node currentNode)
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

            NoActiveQuest = true; // mark klo ga ada quest

            questSelector.OpenQuestSelector(playerID);
            // triger anim if avaialble
            
        }

        
    }

    public void CheckSpecialNode(Node currentNode)
    {
        if (currentNode.isSpecial())
        {
            specialNode = true;
            Debug.Log("SPECIAL NODE");
        }
    }


    public void SetQuest (Quest qt) // SET ACTIVE QUEST WAJIB PAKE INI
    {
        activeQuest = qt;
        dropOff = false;
        pickUp = false;
        NoActiveQuest = false;
    }

    
}
