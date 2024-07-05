using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerCamera : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras;
    short activeCam = 0;
    void NextCamera()
    {
        foreach (GameObject cam in cameras)
        {
            cam.SetActive(false);
        }
        activeCam++;
        if(activeCam>= cameras.Length) activeCam = 0;
        cameras[activeCam].SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab))
            NextCamera();
    }
}
