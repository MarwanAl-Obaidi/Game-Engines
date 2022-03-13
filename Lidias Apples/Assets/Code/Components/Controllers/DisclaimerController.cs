using System;
using System.Collections;
using UnityEngine;

public class DisclaimerController : Controller
{
    public override void Start()
    {
        base.Start();
    }

    private void Game_OnAccept()
    {
        Game.m_gameStateMachine.SetTrigger("Cinematic");
        StopCoroutine(CloseDisclaimer());
    }

    public override void StartScene()
    {
        Game.OnAccept += Game_OnAccept;
        StartCoroutine(CloseDisclaimer());
    }

    public override void StopScene()
    {
        Game.OnAccept -= Game_OnAccept;
    }

    private IEnumerator CloseDisclaimer()
    {
        yield return new WaitForSeconds(5);
        Game.m_gameStateMachine.SetTrigger("Cinematic");
    }
}
