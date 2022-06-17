using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    bool canMove = false;
    public bool CanMove { get => canMove; set => canMove = value;}
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        //rb.AddForce(transform.forward * speed, ForceMode.Force);
        if (canMove) Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime);
    }
}
