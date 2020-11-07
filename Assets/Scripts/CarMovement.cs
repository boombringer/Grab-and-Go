using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    //player
    public Player player;
    public int playerID;

    //PlayerState
    public enum PlayerState {stop,move,getNode, checkStep ,specialNode,quest, nodeCheck}
    public PlayerState pState = PlayerState.stop;

    
    // movement
    public Transform destinationTransform;
    public Node destinationNode;
    public Node currentNode;
    public Node previousNode;

    public PathSelector pathSelect;

    public float speed = 100;
    private int steps = 0;

    //CheckQUEST

    private void Update()
    {

        if(pState == PlayerState.stop)
        {
            //PlayerController
            if (Input.GetKeyDown(KeyCode.Space) && playerID == 1)
            {
                pState = PlayerState.move;
                steps = 10;
            }
            if (Input.GetKeyDown(KeyCode.K) && playerID == 2)
            {
                pState = PlayerState.move;
                steps = 10;
            }
        }

        if(pState == PlayerState.move)
        {
           bool move = OnMove();
           if (!move)
           { 
                pState = PlayerState.nodeCheck; 
           }
        }


        if(pState == PlayerState.nodeCheck)
        {
            player.CheckNode(currentNode);
            pState = PlayerState.quest;
        }


        if (pState == PlayerState.quest)
        {

            if (player.finishedQuest) 
            {
                //class tidak bisa dijadikan completely null
                // jadi harus ada boolean penggantinya 
                // nunggu quest kepilih
            }
            else pState = PlayerState.specialNode;

        }

        if(pState == PlayerState.specialNode)
        {
            if (player.specialNode)
            {
                //sementara
                if (Input.GetKeyDown(KeyCode.S))
                    player.SpecialNodeResolved();

            }
            else
                pState = PlayerState.checkStep;
        }


        if (pState == PlayerState.checkStep)
        {
            if (steps > 0)
            {
                pState = PlayerState.getNode;
            }
            if (steps == 0)
            {
                pState = PlayerState.stop;
            }
        }



        if (pState == PlayerState.getNode)
        {

            GetNextDestination();
            if (destinationTransform != null) pState = PlayerState.move;

                
        }

        


    }

    private void GetNextDestination()
    {     
        Node n = pathSelect.NodeSelect(currentNode, previousNode);
        Transform t = null;

        if (n != null)
        {
            destinationTransform = n.GetTransform();
            destinationNode = n;
        }

    }

    private bool OnMove()
    {
        //movementScript
        if (destinationTransform != null)
        {
            Vector3 des = new Vector3(destinationTransform.position.x, transform.position.y, destinationTransform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, des, speed * Time.deltaTime);

            if (des == transform.position) // trigger
            {
                steps -= 1;
                previousNode = currentNode;
                currentNode = destinationNode;

                destinationNode = null;
                destinationTransform = null;

                return false;
            }
            else return true;
        }
        else return false;
    }

    public void SetStep()
    {

    }

}


/////////////////////////////////////////////////// CODE DUMP /////////////////////////////////////
/*private Transform GetNextDestination()
{

    pathSelect.NodeSelect(currentNode, previousNode);
    Node n = null;
    int branch = currentNode.NodeActiveConnection();
    Transform t = null;

    if (branch == 2)
    {
        n = OnePath(currentNode, previousNode);
    }
    else if (branch > 2)
    {
        n = Branching(currentNode);
    }

    if (n != null)
    {
        t = n.GetTransform();
        destinationNode = n;
    }

    return t;
}*/

/*private Node Branching(Node node)
    {
        List<int> stats = node.GetConnection_Status();
        pathSelect.OpenSelectorUI(stats, currentNode.GetTransform());
        int selected = pathSelect.GetSelected();

        if (selected >= 0)
        {
            return node.GetDestinationNode(selected);
        }

        return null;
    }

    private Node OnePath(Node node, Node previous)
    {

        foreach (Node n in node.connection)
        {
            if (n != null && n != previous)
            {
                return n;
            }
        }
        return null;
    }*/



/*private void Update()
{

    if (pState == PlayerState.stop)
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerID == 1)
        {
            pState = PlayerState.move;
            steps = 10;
        }
        if (Input.GetKeyDown(KeyCode.K) && playerID == 2)
        {
            pState = PlayerState.move;
            steps = 10;
        }
    }

    if (pState == PlayerState.move)
    {
        //Debug.Log(pState);
        bool move = OnMove();
        if (!move)
        {
            pState = PlayerState.quest;
        }
    }

    if (pState == PlayerState.quest)
    {

        pState = PlayerState.specialNode;
    }

    if (pState == PlayerState.specialNode)
    {
        bool c = false;
        if (c) // kalo ga ada special Node
        {

        }
        else pState = PlayerState.getNode;
    }

    if (pState == PlayerState.getNode)
    {
        Debug.Log(pState);
        if (steps > 0)
        {
            GetNextDestination();
            if (destinationTransform != null) pState = PlayerState.pending;
        }
        else
        {
            pState = PlayerState.stop;
        }

    }

    if (pState == PlayerState.pending)
    {
        Debug.Log(pState);
        if (true) // kalo ga ada node special
        {
            if (steps > 0)
            {
                if (true) pState = PlayerState.move;
            }
            if (steps == 0)
            {
                pState = PlayerState.stop;
            }

        }
        else // kalau ada special node
        {

        }
    }

}
*/