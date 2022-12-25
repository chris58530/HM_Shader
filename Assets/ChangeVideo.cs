using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVideo : MonoBehaviour
{
    [SerializeField]
    private GameObject video;

    bool isVideo;
    private Material Material;
    float f;
    float size;

    void Start()
    {
        video.SetActive(false);
        isVideo = false;
        Material = GetComponent<MeshRenderer>().materials[0];
        size = Material.GetFloat("_Size");

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isVideo)
        {
            f = 1;
            Material.SetFloat("_Blur", f);

            Material.SetFloat("_Size", 0);
            isVideo = true;
            video.SetActive(true);
            StartCoroutine(set());
        }

    }
    IEnumerator set()
    {
        for (int i = 0; i < 80; i++)
        {
            Material.SetFloat("_Blur", f);
            f -= 0.01f;
            Debug.Log("-1");
            yield return new WaitForSeconds(0.2f);
        }
        video.SetActive(false);
        for (int i = 0; i < 10; i++)
        {
            Material.SetFloat("_Blur", f);
            f -= 0.01f;
            Debug.Log("-2");
            Material.SetFloat("_Size", size);

            yield return new WaitForSeconds(0.2f);
        }
        isVideo = false;

    }
}
