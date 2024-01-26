using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trow_Ball : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private GameObject _spawnpointBall;

    public float SpeedMultiplier = 5;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 velocity = rb.velocity;

        velocity.x *= SpeedMultiplier;
        velocity.y *= SpeedMultiplier;
        velocity.z *= SpeedMultiplier;
        rb.velocity = velocity;
    }

    public void GoBall()
    {
        Instantiate(_ballPrefab, _spawnpointBall.transform.position, Camera.main.transform.rotation);
    }
}
