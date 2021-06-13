using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Destination : MonoBehaviour
{
    PathCreator pc;

    private void Start()
    {
        pc = GetComponentInParent<PathCreator>();
        transform.position =  new Vector3( pc.path.localPoints[pc.path.localPoints.Length - 1].x,transform.position.y, pc.path.localPoints[pc.path.localPoints.Length - 1].z);
    }
}
