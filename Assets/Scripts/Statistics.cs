using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation.Examples;

public class Statistics : MonoBehaviour
{
    public string playerName;
    public int rank;
    public float completion;

  public  bool isPlayer;


    Transform thisTransform;
    float goalZ, startZ, divZ;


    GameManagerScript gms;


    PlayerPathFollower ps;

    void Start()
    {

        gms = GameManagerScript.instance;
        ps = GetComponent<PlayerPathFollower>();
        if (isPlayer)
        {
            isPlayer = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollowScript>().SetCamera(this.transform);

            UIManagerScript.instance.mainPlayerStats = this.GetComponent<Statistics>();
        }
 
        //  gms.stats.Add(this.GetComponent<Statistics>());
        gms.AddToStats(GetComponent<Statistics>());
  


    }

    // Update is called once per frame
    void Update()
    {
        if (gms.isGameStart)
        {
            completion = Mathf.Round((ps.distanceTravelled/ ps.pathCreator.path.length) *100);     // Mathf.Round(((thisTransform.position.z - startZ) / divZ)*100);
        }
    }
}
