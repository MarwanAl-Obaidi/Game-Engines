using UnityEngine;
using UnityEngine.SceneManagement;

public static class Game
{
    public static Animator m_gameStateMachine;
    public static Boy m_boy;
    public static Girl m_girl;
    private static int m_maxLooseCount = 3;
    private static int m_maxCountOfApples = 10;
    private static int m_catchedApples = 0;
    private static int m_missedApples = 0;
    private static bool m_resetRequested = false;

    public delegate void OnAcceptHandler();
    public static event OnAcceptHandler OnAccept;

    public delegate void OnUpHandler();
    public static event OnUpHandler OnUp;

    public delegate void OnUpReleaseHandler();
    public static event OnUpReleaseHandler OnUpRelease;

    public delegate void OnDownHandler();
    public static event OnDownHandler OnDown;

    public delegate void OnDownReleaseHandler();
    public static event OnDownReleaseHandler OnDownRelease;

    public delegate void OnLeftHandler();
    public static event OnLeftHandler OnLeft;

    public delegate void OnRightHandler();
    public static event OnRightHandler OnRight;

    public delegate void OnAppleCatchedHandler();
    public static event OnAppleCatchedHandler OnAppleCatched;

    public delegate void OnAppleMissedHandler();
    public static event OnAppleMissedHandler OnAppleMissed;

    public delegate void OnGameWonHandler();
    public static event OnGameWonHandler OnGameWon;

    public delegate void OnGameLostHandler();
    public static event OnGameLostHandler OnGameLost;

    public delegate void OnLevelResetHandler();
    public static event OnLevelResetHandler OnLevelReset;

    public static Controller FindController(Scene s)
    {
        GameObject[] objs = s.GetRootGameObjects();
        for (int i=0; i < objs.Length; ++i)
        {
            GameObject go = objs[i];
            Controller c = go.GetComponent<Controller>();
            if(c != null)
            {
                return c;
            }
        }
        return null;
    }

    public static bool SceneLoaded(Scene s)
    {
        if (s.isLoaded)
        {
            Controller c = FindController(s);
            if (c != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    public static void OnAcceptAction()
    {
        OnAccept?.Invoke();
    }

    public static void OnDownAction()
    {
        OnDown?.Invoke();
    }

    public static void OnDownReleaseAction()
    {
        OnDownRelease?.Invoke();
    }

    public static void OnUpAction()
    {
        OnUp?.Invoke();
    }

    public static void OnUpReleaseAction()
    {
        OnUpRelease?.Invoke();
    }

    public static void OnLeftAction()
    {
        OnLeft?.Invoke();
    }

    public static void OnRightAction()
    {
        OnRight?.Invoke();
    }

    public static void AddMissedApple()
    {
        m_missedApples++;
        OnAppleMissed?.Invoke();
    }

    public static void AddCatchedApple()
    {
        m_catchedApples++;
        OnAppleCatched?.Invoke();
    }

    public static void ResetCounters()
    {
        m_catchedApples = 0;
        m_missedApples = 0;
    }

    public static int CatchedApples
    {
        get
        {
            return m_catchedApples;
        }
    }

    public static int MissedApples
    {
        get
        {
            return m_missedApples;
        }
    }

    public static void GameWon()
    {
        OnGameWon?.Invoke();
        m_gameStateMachine.SetTrigger("Win");
    }

    public static void GameLost()
    {
        OnGameLost?.Invoke();
        m_gameStateMachine.SetTrigger("Loose");
    }

    public static void CheckGameWinLoose()
    {
        if (MissedApples >= m_maxLooseCount)
        {
            GameLost();
            return;
        }

        int catchedCount = MissedApples + CatchedApples;
        if (catchedCount >= m_maxCountOfApples)
        {
            GameWon();
        }
    }

    public static void ResetLevel()
    {
        m_resetRequested = true;
        OnLevelReset?.Invoke();
    }

    public static bool ResetRequested
    {
        set
        {
            m_resetRequested = value;
        }

        get
        {
            return m_resetRequested;
        }
    }
}
