using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Use [SerializeField] instead of public to expose variable in editor without public
    public float jumpStrength = 5;
    public float walkStrength = 5;
    private new Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // GetAxisRaw doesn't have smoothing when release key
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * walkStrength, rb.velocity.y, verticalInput * walkStrength);

        if (Input.GetButtonDown("Jump")) {
            // Use current velocity so you can walk and jump at same time
            rb.velocity = new Vector3(rb.velocity.x, jumpStrength, rb.velocity.z);
        }
    }
}
