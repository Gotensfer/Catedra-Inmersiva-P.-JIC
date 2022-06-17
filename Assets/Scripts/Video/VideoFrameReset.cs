using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoFrameReset : MonoBehaviour
{
    [SerializeField] Image image;
    // Start is called before the first frame update
    void Start()
    {
        image.material.color = Color.black;
        StartCoroutine(SetWhiteOnNextFrame());
    }

    IEnumerator SetWhiteOnNextFrame()
    {
        yield return new WaitForSeconds(0.2f);
        image.material.color = Color.white;
        StopCoroutine(SetWhiteOnNextFrame());
    }
}
