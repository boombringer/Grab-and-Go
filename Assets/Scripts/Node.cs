using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Node : MonoBehaviour
{
    public int nodeID;

    public Action<string> nodeTrigger;

    //connection
    public Node north;
    public Node south;
    public Node east;
    public Node west;
    public List<Node> connection;

    private void Awake()
    {
        connection = new List<Node> {
            north, //0
            south, //1
            east, //2
            west  //3
        };
    }

    public void Trigger() 
    {
        if (nodeTrigger != null)
        {
            nodeTrigger(gameObject.name); // contoh implementasi
        }
    }



    public int GetNodeId()
    {
        return nodeID;
    }

    public string GetNodeType() 
    {
        return gameObject.tag;
    }

    public int NodeActiveConnection()
    {
        int activeConnection = 0;
        foreach (Node n in connection)
        {
            activeConnection += (n != null) ? 1 : 0;
        }
        return activeConnection;
    }

    public List<int> GetConnection_Status()
    {
        List<int> temp = new List<int>();
        foreach (Node n in connection)
        {
            if (n == null)
                temp.Add(0);
            else
                temp.Add(1);
        }
        return temp;
    }

    public List<Node> GetConnection()
    {
        return connection;
    }

    public Node GetDestinationNode(int selected)
    {
        return connection[selected];
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
