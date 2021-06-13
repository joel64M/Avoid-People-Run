using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class AiStartDestination : MonoBehaviour
{
    [SerializeField] Transform startObj;
    [SerializeField] Transform destinationObj;

    [SerializeField] PathCreator pc;

    private void Start()
    {
        pc = GetComponent<PathCreator>();
        startObj.position = new Vector3(pc.path.localPoints[0].x, startObj.transform.position.y, pc.path.localPoints[0].z);
        destinationObj.position = new Vector3(pc.path.localPoints[pc.path.localPoints.Length - 1].x, destinationObj.transform.position.y, pc.path.localPoints[pc.path.localPoints.Length - 1].z);

    }

}
