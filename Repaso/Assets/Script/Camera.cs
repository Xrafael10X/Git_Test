using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Vector3 offset = new Vector3(0f, 0f, -5f);
    Vector3 camVelocity = Vector3.zero;
    [SerializeField] float smoothCam;

    [SerializeField] Transform Target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 objectPosition = Target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, objectPosition, ref camVelocity, smoothCam);
    }
}
