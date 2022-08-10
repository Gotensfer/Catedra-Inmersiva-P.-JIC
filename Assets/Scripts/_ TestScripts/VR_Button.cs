using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VR_Button : MonoBehaviour
{
    [SerializeField] float deadTime;
    bool deadTimeActive = false;

    //Eventos de interacción
    public UnityEvent onPressed, onReleassed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Button" && !deadTimeActive)
        {
            onPressed?.Invoke();
            Debug.Log("Me presionaste");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button" && !deadTimeActive)
        {
            onReleassed?.Invoke();
            Debug.Log("Me soltaste");
            StartCoroutine(WaitDeadTime());
        }
    }

    IEnumerator WaitDeadTime()
    {
        deadTimeActive = true;
        yield return new WaitForSeconds(deadTime);
        deadTimeActive = false;
    }
}
