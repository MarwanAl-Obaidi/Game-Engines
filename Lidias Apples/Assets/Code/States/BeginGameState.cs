using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGameState : StateMachineBehaviour
{
    private string[] m_level = { "Disclaimer", "Cinematic", "Menu", "Level", "Ui", "Credits" };
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        for (int i = 0; i < m_level.Length; ++i)
        {
            SceneManager.LoadScene(m_level[i], LoadSceneMode.Additive);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bool allLoaded = true;
        for (int i=0; i < m_level.Length; ++i)
        {
            if (Game.SceneLoaded(SceneManager.GetSceneByName(m_level[i])) == false)
            {
                allLoaded = false;
            }
        }

        if (allLoaded)
        {
            Game.m_gameStateMachine.SetTrigger("Credits");
        }
    }
}
