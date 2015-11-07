using UnityEngine;
using System.Collections;

public class Camera_Player : MonoBehaviour
{
    public Transform target;
    void Start()
    {

    }

    void Update()
    {
        float V = target.localPosition.z;
        Vector3 Vec= target.localPosition;
        Vec.z = V - 4.0f;
        transform.position = Vec;
        transform.LookAt(target);
 
    }
}
