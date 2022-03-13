using UnityEngine;

public class GameController : Controller
{
    public override void Start()
    {
        base.Start();
        Animator anim = this.GetComponent<Animator>();
        Game.m_gameStateMachine = anim;
    }
}