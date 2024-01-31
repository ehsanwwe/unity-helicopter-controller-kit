using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCamera : MonoBehaviour
{
    public Transform target;
    private Transform  pivote;
    void Start()
    {
        GameObject pivoteGameObject = new GameObject();
        pivoteGameObject.name = "CameraPivote";
        pivote =  pivoteGameObject.transform;
        pivote.position = target.position;
        transform.parent = pivote;
    }

    // Update is called once per frame
    public void LateUpdate()
    {
        pivote.position = Vector3.Lerp(pivote.position,   target.position, Time.deltaTime   );
        pivote.rotation = Quaternion.Lerp(pivote.rotation,target.rotation, Time.deltaTime*3 );
    }
}
