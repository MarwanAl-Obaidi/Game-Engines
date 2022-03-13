using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseLevelState : StateMachineBehaviour
{
    private Scene m_scene;
    private Controller m_controller;

    public virtual void OnEnter(string sceneName)
    {
        m_scene = SceneManager.GetSceneByName(sceneName);
        m_controller = Game.FindController(m_scene);
        m_controller.ShowScene();
        m_controller.StartScene();
    }

    public virtual void OnExit()
    {
        m_controller.HideScene();
        m_controller.StopScene();
    }
}
