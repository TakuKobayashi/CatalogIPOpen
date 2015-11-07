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
        transform.position = target.localPosition - new Vector3(0.0f, 0.0f, 24.0f);
        transform.LookAt(target);
 
    }
}
