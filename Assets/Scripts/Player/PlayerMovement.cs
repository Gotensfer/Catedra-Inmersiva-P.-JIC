using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] Transform direction;

    float speedX;
    float speedZ;
    
    private void Update()
    {
        speedX = Input.GetAxis("Horizontal");
        speedZ = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() //Para evitar Glitchearse al intentar moverse contra una pared o barrera
    {
        transform.Translate(direction.forward * speedZ * Time.fixedDeltaTime);
        transform.Translate(direction.right * speedX * Time.fixedDeltaTime);
    }
}
