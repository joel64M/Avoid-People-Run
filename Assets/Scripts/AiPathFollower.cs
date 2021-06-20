using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class AiPathFollower : PathFollower
{
    bool changeDir;
    bool allowChangeDir;
    public float completion;
     float subtractor=0;
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (pathCreator != null)
        {
            if(endOfPathInstruction == PathCreation.EndOfPathInstruction.Reverse)
            {
                if (!changeDir)
                {
                    distanceTravelled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                    transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, 90);
                }
                else
                {
                    distanceTravelled += speed * Time.deltaTime;
                    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                    transform.eulerAngles = transform.eulerAngles + new Vector3(0, 180, 90);
                }

                completion = Mathf.Round((distanceTravelled / pathCreator.path.length) * 100) - subtractor;
                if (completion >= 100)
                {
                    changeDir = !changeDir;
                    subtractor += 100;
                }
            }
            else
            {
                base.Update();
            }
         
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("ChangeDir"))
        //{
        //    if(completion>=99)
        //    changeDir = !changeDir;
        //}
    }
}
