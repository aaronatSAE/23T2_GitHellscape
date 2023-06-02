using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPlayerController : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashCooldown = 1f;

    private bool isDashing = false;
    private float lastDashTime = 0f;
    private Vector3 dashDirection;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isDashing && Time.time - lastDashTime <= dashCooldown)
            {
                Dash();
            }
            else
            {
                isDashing = true;
                lastDashTime = Time.time;
                dashDirection = transform.forward;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            // Move the player in the dash direction
            GetComponent<Rigidbody>().MovePosition(transform.position + dashDirection * dashDistance);
        }
    }

    private void Dash()
    {
        isDashing = false;
    }
}
