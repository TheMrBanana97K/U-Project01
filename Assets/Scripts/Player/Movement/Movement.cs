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
        player = gameObject.GetComponent<Player>();

        rb = gameObject.GetComponent<Rigidbody>();
    }
    public void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        velocity = direction * player.speed.getValue();
    }
    private void FixedUpdate()
    {
        Move(rb.position+velocity * Time.deltaTime);
    }
    void Move(Vector3 direction)
    {
        rb.MovePosition(direction);
    }
}
