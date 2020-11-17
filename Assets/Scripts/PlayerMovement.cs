using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public Transform PlayerCar;

    public float PlayerSpeed;

    private float _speed => PlayerSpeed;
    private Player _player;
    private Transform _playerCar => PlayerCar;
    private PlayerNodeManager _nodeManager;

    private void Awake()
    {
        _player = gameObject.GetComponent<Player>();
        _nodeManager = gameObject.GetComponent<PlayerNodeManager>();
    }

    public bool OnMove()
    {
        var destTransform = _nodeManager.destinationTransform;

        if (destTransform == null) return false;
        

        Vector3 des = new Vector3(destTransform.position.x, _playerCar.position.y, destTransform.position.z);
        _playerCar.position = Vector3.MoveTowards(_playerCar.position, des, _speed * Time.deltaTime);

        if (des != _playerCar.position) return true; // trigger

        _player.steps -= 1;
        _nodeManager.OnReachedDestination();

        return false;
            

    }
}