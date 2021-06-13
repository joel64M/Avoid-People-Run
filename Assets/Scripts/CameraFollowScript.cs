using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class CameraFollowScript : MonoBehaviour
{
    public static CameraFollowScript instance;
    public   Vector3 offset = Vector3.zero;

    public float smoothTime = 0.5f;

    public Transform target;

    Vector3 centerPoint = Vector3.zero;

    Vector3 velocity = Vector3.zero;
    Camera cam;


    GameManagerScript gms;
    float t = 0f;
    float t2 = 0f;

    bool gameStarted;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        cam = GetComponent<Camera>();
        gms = GameManagerScript.instance;
        Move();
    }
    public void SetCamera(Transform t)
    {
        target = t;
        offset = this.transform.position - target.position;

    }

    private void Update()
    {
        if (gms.isGameComplete || gms.isGameOver)
        {
            ZoomInCamera();
        }
    }
    private void LateUpdate()
    {
        if (gms.isGameStart)
        {
            ZoomOutCamera();
            Move();
        }

   
    }

    void ZoomInCamera()
    {
        if (t <= 1)
        {
            t += Time.deltaTime;
            cam.fieldOfView = Mathf.Lerp(65, 30, t);
        }

    }
    void ZoomOutCamera()
    {
        if (t2 <= 1)
        {
            t2 += Time.deltaTime;
            cam.fieldOfView = Mathf.Lerp(30, 65, t2);
        }
        else
        {
            gameStarted = true;
        }
    }
    private void Move()
    {
        centerPoint = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, centerPoint, ref velocity, smoothTime);
        transform.LookAt(target);
    }



}
