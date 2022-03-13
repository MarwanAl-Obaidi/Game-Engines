using System.Collections;
using UnityEngine;

public class LevelController : Controller
{
    [SerializeField]
    private Boy m_boy = null;
    [SerializeField]
    private Girl m_girl = null;
    private float m_delay = 0.0f;
    [SerializeField]
    private ParticleSystem m_splashEffectPS = null;
    [SerializeField]
    private AudioSource m_splashAudio = null;
    [SerializeField]
    private StatusTexts m_statusTexts = null;

    public override void Start()
    {
        base.Start();
    }

    public override void HideScene()
    {
        base.HideScene();
        m_boy.HideApple();
    }

    public override void StartScene()
    {
        m_boy.InitCharacter();
        m_girl.InitCharacter();

        Game.ResetRequested = false;

        Game.m_boy = m_boy;
        Game.m_girl = m_girl;

        Game.OnAppleMissed += Game_OnAppleMissed;
        Game.OnLevelReset += Game_OnLevelReset;

        m_statusTexts.InitTexts();

        StartCoroutine(ThrowApple());
    }

    private void Game_OnLevelReset()
    {
        StopCoroutine(ThrowApple());
        StopScene();
    }

    private void Game_OnAppleMissed()
    {
        m_splashEffectPS.transform.position = Game.m_boy.m_apple.transform.position;
        m_splashEffectPS.Stop();
        m_splashEffectPS.Play();
        m_splashAudio.Play();
        Game.CheckGameWinLoose();
    }

    public override void StopScene()
    {
        m_girl.ClearCharacter();
        m_statusTexts.DisableTexts();
        Game.OnAppleMissed -= Game_OnAppleMissed;
        Game.OnLevelReset -= Game_OnLevelReset;
    }

    private IEnumerator ThrowApple()
    {
        m_delay = Random.Range(0f, 5f) + m_boy.m_delay;
        yield return new WaitForSeconds(m_delay);
        if (!Game.ResetRequested)
        {
            Game.m_boy.m_animator.SetTrigger("PickupApple");
            StartCoroutine(ThrowApple());
        }
    }
}
