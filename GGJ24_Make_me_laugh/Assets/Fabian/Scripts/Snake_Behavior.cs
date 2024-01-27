using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Behavior : MonoBehaviour
{
    private float _speedMultiplier = 5;
    private SnakeSpawner _snakeSpawner;

    private void Awake()
    {
        _snakeSpawner = FindObjectOfType<SnakeSpawner>();
    }

    void Update()
    {
        //transform.position = Vector3.MoveTowards(_snakeSpawner.SpawnpointSnake.transform.position, 
        //    _snakeSpawner.WaypointsSnake[Random.Range(0, _snakeSpawner.WaypointsSnake.Length)].transform.position, _speedMultiplier * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(_snakeSpawner.SpawnpointSnake.transform.position,
            _snakeSpawner.WaypointsSnake[Random.Range(0, _snakeSpawner.WaypointsSnake.Length)].transform.position, _speedMultiplier * Time.deltaTime);
    }
}