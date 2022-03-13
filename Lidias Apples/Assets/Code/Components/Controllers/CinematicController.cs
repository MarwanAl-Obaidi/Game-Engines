using UnityEngine;
using UnityEngine.Video;

public class CinematicController : Controller
{
    [SerializeField]
    private VideoPlayer m_vplayer = null;

    public override void Start()
    {
        base.Start();
    }

    public override void StartScene()
    {
        m_vplayer.loopPointReached += M_vplayer_loopPointReached;
        Game.OnAccept += Game_OnAccept;
        m_vplayer.Play();
    }

    private void Game_OnAccept()
    {
        m_vplayer.Stop();
        Game.m_gameStateMachine.SetTrigger("Menu");
    }

    public override void StopScene()
    {
        Game.OnAccept -= Game_OnAccept;
    }

    private void M_vplayer_loopPointReached(VideoPlayer source)
    {
        Game.m_gameStateMachine.SetTrigger("Menu");
    }
}
