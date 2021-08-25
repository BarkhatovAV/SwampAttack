using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDieTransition : Transition
{

    

    // Update is called once per frame
    private void Update()
    {
        if(Target == null)
        {
            NeedTransit = true;
        }
    }
}
