using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VR_Button : MonoBehaviour
{
    [SerializeField] float deadTime;
    public Outline outline;
    bool deadTimeActive = false;

    public bool anchorEventIsOn = false;
    bool alreadyPressed = false;
    [SerializeField] float timeForEvent;
    [SerializeField] float eventTimeRemaining;
    [SerializeField] BoxCollider boxCollider;

    [SerializeField] GameObject anchorEventBegin;
    [SerializeField] GameObject anchorHurryText;
    [SerializeField] GameObject anchorEventFailure;
    [SerializeField] GameObject anchorEventSuccess;

    //Eventos de interacción
    public UnityEvent onPressed, onReleassed;

    private void Start()
    {
        eventTimeRemaining = timeForEvent;
        boxCollider.enabled = false;
        outline.OutlineWidth = 0;
    }

    bool hurryFlag = false;
    private void Update()
    {
        if (anchorEventIsOn)
        {
            eventTimeRemaining -= Time.deltaTime;

            if (eventTimeRemaining <= timeForEvent/2 && !hurryFlag)
            {
                anchorEventBegin.SetActive(false);
                anchorHurryText.SetActive(true);
                hurryFlag = true;
            }

            if (eventTimeRemaining <= 0)
            {
                anchorEventIsOn = false;
                outline.OutlineWidth = 0;
                boxCollider.enabled = false;
                AnchorEvent_FailureResolution();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Button" && !deadTimeActive && !alreadyPressed)
        {
            onPressed?.Invoke(); // Evento
            Debug.Log("Me presionaste");
            alreadyPressed = true;
            outline.OutlineWidth = 0;
            anchorEventIsOn = false;
            
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

    public void AnchorEvent_SuccessResolution()
    {
        anchorEventBegin.SetActive(false);
        anchorHurryText.SetActive(false);
        anchorEventSuccess.SetActive(true);
        print("success");
    }

    public void AnchorEvent_FailureResolution()
    {
        anchorEventBegin.SetActive(false);
        anchorHurryText.SetActive(false);
        anchorEventFailure.SetActive(true);
        print("Failure");
    }
}
