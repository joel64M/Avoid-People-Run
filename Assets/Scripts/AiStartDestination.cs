using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class AiStartDestination : MonoBehaviour
{
    [SerializeField] GameObject startEndObj;
    [SerializeField] PathCreator pc;

    private void Start()
    {
        pc = GetComponent<PathCreator>();
        if (!pc.path.isClosedLoop)
        {
         
            GameObject go = Instantiate(startEndObj, this.transform);
            go.transform.position = new Vector3(pc.path.localPoints[0].x, -0.065f, pc.path.localPoints[0].z);

            go = Instantiate(startEndObj, this.transform);
            go.transform.position = new Vector3(pc.path.localPoints[pc.path.localPoints.Length - 1].x, -0.065f, pc.path.localPoints[pc.path.localPoints.Length - 1].z);

        }

    }

}
