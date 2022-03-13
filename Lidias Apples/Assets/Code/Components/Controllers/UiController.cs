using UnityEngine;
using UnityEngine.UI;

public class UiController : Controller
{
    public Text m_textA = null;
    public Text m_textB = null;

    public override void StartScene()
    {
        Game.OnAppleCatched += Game_OnAppleCatched;
        Game.OnAppleMissed += Game_OnAppleMissed;
        Game.OnGameWon += Game_OnGameWon;
        Game.OnGameLost += Game_OnGameLost;
    }

    private void Game_OnGameLost()
    {
    }

    private void Game_OnGameWon()
    {
    }

    public override void StopScene()
    {
        Game.OnAppleCatched -= Game_OnAppleCatched;
        Game.OnAppleMissed -= Game_OnAppleMissed;
        Game.OnGameWon -= Game_OnGameWon;
        Game.OnGameLost -= Game_OnGameLost;
    }

    private void Game_OnAppleMissed()
    {
        m_textB.text = string.Format("{0}", Game.MissedApples);
    }

    private void Game_OnAppleCatched()
    {
        m_textA.text = string.Format("{0}", Game.CatchedApples);
    }

    public void ResetCounters()
    {
        Game.ResetCounters();
        m_textA.text = string.Format("{0}", Game.CatchedApples);
        m_textB.text = string.Format("{0}", Game.MissedApples);
    }
}
