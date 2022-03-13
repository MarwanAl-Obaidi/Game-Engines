using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Game.ResetLevel();
    }
}
