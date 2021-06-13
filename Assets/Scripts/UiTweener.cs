using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTweener : MonoBehaviour
{

    [SerializeField] GameObject objToTween;


    [SerializeField] Type type;
    public enum Type
    {
        shaky,
        slowScaly,

    }
    // Start is called before the first frame update
    void Start()
    {
      //  LeanTween.cancel(objToTween);

        switch (type)
        {
            case  Type.shaky:

                LeanTween.scale(objToTween, Vector3.one * 1.2f, 2f).setEaseInElastic().setLoopPingPong();

                break;
            case Type.slowScaly:
                LeanTween.scale(objToTween, Vector3.one * 1.2f, 1f).setEaseInOutCirc().setLoopPingPong();

                break;

            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
