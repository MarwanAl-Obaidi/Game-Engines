using UnityEngine;

public class StatusTexts : MonoBehaviour
{
    public Animator m_gotpointAnimator = null;
    public Animator m_missedAnimator = null;

    public void InitTexts()
    {
        Game.OnAppleCatched += Game_OnAppleCatched;
        Game.OnAppleMissed += Game_OnAppleMissed;
        
    }

    public void DisableTexts()
    {
        Game.OnAppleCatched -= Game_OnAppleCatched;
        Game.OnAppleMissed -= Game_OnAppleMissed;
    }

    private void Game_OnAppleMissed()
    {
        m_missedAnimator.SetTrigger("Play");
    }

    private void Game_OnAppleCatched()
    {
        m_gotpointAnimator.SetTrigger("Play");
    }
}
