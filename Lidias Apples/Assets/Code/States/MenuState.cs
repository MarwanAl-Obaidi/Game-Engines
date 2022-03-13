using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuState : StateMachineBehaviour
{
    private Scene m_scene;
    private Controller m_controller = null;

    private Scene m_level;
    private Controller m_levelController = null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_scene = SceneManager.GetSceneByName("Menu");
        m_level = SceneManager.GetSceneByName("Level");

        m_controller = Game.FindController(m_scene);
        m_levelController = Game.FindController(m_level);

        m_controller.ShowScene();
        m_controller.StartScene();
        
        m_levelController.ShowScene();
        SceneManager.SetActiveScene(m_level);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_controller.StopScene();
        m_controller.HideScene();
    }
}
