using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Player))]
public class Movement : MonoBehaviour {
    Player player;

    Rigidbody rb;
    Vector3 velocity;
    public void Start()
    {
        player =GetComponent<Player>();

        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        // move in x and z axis
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        velocity = direction * player.speed.getValue();
    }
    // Rigidbody in Fixed Update to prevent bad collision detection
    private void FixedUpdate()
    {
        Move(rb.position+velocity * Time.deltaTime);
    }
    void Move(Vector3 direction)
    {
        rb.MovePosition(direction);
    }
}
