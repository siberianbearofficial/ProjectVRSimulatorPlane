using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeBehaviour : MonoBehaviour
{
    [SerializeField] GameObject BackgroundPlane;
    [SerializeField] GameObject BehaviourDependenceObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotate Y для крена (rotation Z для GameObject)
        BackgroundPlane.transform.localRotation = new Quaternion(BackgroundPlane.transform.localRotation.x, BehaviourDependenceObject.transform.rotation.z, BackgroundPlane.transform.localRotation.z, BackgroundPlane.transform.localRotation.w);
        //position Z для тангажа (rotation X для GameObjet)
        BackgroundPlane.transform.localPosition = new Vector3(0, 0, BehaviourDependenceObject.transform.rotation.x);
    }
}
