using UnityEngine;
using System.Collections;

public class Camera_Player : MonoBehaviour {
    public Transform target;
    public float smoothing = 5f;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - target.position;
    }
    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
