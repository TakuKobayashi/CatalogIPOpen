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
        //transform.position = target.localPosition - new Vector3(0.0f, 0.0f, 24.0f);
        //transform.LookAt(target);

        Vector3 vec = target.localPosition;
        Vector3 fvec = target.forward;

        vec.z -= 24.0f;
        fvec *= 6.0f;
        //fvec *= 8.0f + Trans.JetBoard_Speed;
        //fvec.z = 1f;


        transform.position = vec - fvec;
        transform.LookAt(target.localPosition);
    }
}
