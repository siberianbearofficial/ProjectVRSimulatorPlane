using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject Plane;
    [SerializeField] GameObject Cabine;
    [SerializeField] Camera cameraInside;
    [SerializeField] Camera cameraOutside;
    private Camera insideComponent;
    private Camera outsideComponent;
    private bool switchCamera;

    // Start is called before the first frame update
    void Start()
    {
        outsideComponent = cameraOutside.GetComponent<Camera>();
        /*outsideComponent = Camera.main;*/
        insideComponent = cameraInside.GetComponent<Camera>();
        switchCamera = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            //camera switch
            outsideComponent.enabled = !outsideComponent.enabled;
            insideComponent.enabled = !insideComponent.enabled;
            Cabine.SetActive(!switchCamera);
            Plane.SetActive(switchCamera);
            switchCamera = !switchCamera;
        }
    }
}
