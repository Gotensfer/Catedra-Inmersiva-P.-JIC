using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Teleport : MonoBehaviour
{
    [SerializeField] Transform tpPoint;
    [SerializeField] float timer;
    float time;
    Vector3 position; 
    

    // Start is called before the first frame update
    void Start()
    {
        tpPoint = gameObject.GetComponent<Transform>();
        position = tpPoint.position;
        time = timer;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            print("a");
            //Se correria la corrutina que hace esto de abajo
            transform.position = position; ;
        }
    }
}
