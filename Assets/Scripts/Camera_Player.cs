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
        Vector3 Vec;
        Vec = target.localPosition.z - 10.0f;
        transform.position = Vec;
        transform.LookAt(target);
 
    }
}
