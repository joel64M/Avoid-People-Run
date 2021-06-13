using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class PlayerPathFollower : PathFollower
{

    GameManagerScript gm;


    Vector3 startRot;
    float t = 0;
    bool isStarted;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        gm = GameManagerScript.instance;
      //  pathCreator =  GameObject.FindGameObjectWithTag("PathCreator").GetComponent<PathCreation.PathCreator>();
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        // transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        //   transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 90);
       Quaternion q= pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        startRot = q.ToEuler() + new Vector3(0, 0, 90);
        transform.eulerAngles = new Vector3(0, -180, 0);
    }



    public override void Update()
    {
        if(gm.isGameStart)
        if (pathCreator != null)
        {
            if (!isStarted)
            {
                t += Time.deltaTime*5f;
                transform.eulerAngles = new Vector3(0, Mathf.Lerp(-180, startRot.y, t), 0);
                if (t >= 1)
                {
                    isStarted = true;
                }
            }
            else
            {
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 90);
            }

            if(Input.GetMouseButton(0))
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
        }

       
    }
}
