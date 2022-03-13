using System;
using System.Collections;
using UnityEngine;

public class CreditsController : Controller
{
    public override void Start()
    {
        base.Start();
    }

    private void Game_OnAccept()
    {
        Game.m_gameStateMachine.SetTrigger("Disclaimer");
        StopCoroutine(CloseCredits());
    }

    public override void StartScene()
    {
        Game.OnAccept += Game_OnAccept;
        StartCoroutine(CloseCredits());
    }

    public override void StopScene()
    {
        Game.OnAccept -= Game_OnAccept;
    }

    private IEnumerator CloseCredits()
    {
        yield return new WaitForSeconds(5);
        Game.m_gameStateMachine.SetTrigger("Disclaimer");
    }
}
