using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VR_Teleport : MonoBehaviour
{
    [SerializeField] Transform tpPoint;
    [SerializeField] float timer;
    float time;
    Vector3 position;
    [SerializeField] Image panel;

    // Start is called before the first frame update
    void Start()
    {
        time = timer;       
    }

    // Update is called once per frame
    void Update()
    {        
        time -= Time.deltaTime;
        if(time < 2)
        {
            StartCoroutine(Fade());
            if (time <= 0)
            {
                print("a");
                //Se correria la corrutina que hace esto de abajo
                SceneManager.LoadScene(1);
            }
        }
        
    }

    IEnumerator Fade()
    {
        print("a");
        while(panel.color.a <= 1)
        {
            panel.color = new Color(0, 0, 0, panel.color.a + 0.001f);
            yield return null;
        }
        print("b");
    }
}
