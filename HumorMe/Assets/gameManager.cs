using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class gameManager : MonoBehaviour
{
    public static Action<int> OnActivateSceneSwitch;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ActivateSceneSwitch(int _targetScene)
    {
        OnActivateSceneSwitch?.Invoke(_targetScene);
    }


}
