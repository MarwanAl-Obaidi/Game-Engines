using UnityEngine;

public class Controller : MonoBehaviour
{
    private GameObject m_visualObject = null;

    public virtual void Start()
    {
        m_visualObject = GameObject.Find("Visuals");
        HideScene();
    }

    public virtual void StartScene()
    {

    }

    public virtual void StopScene()
    {

    }

    public virtual void HideScene()
    {
        m_visualObject.SetActive(false);
    }

    public virtual void ShowScene()
    {
        m_visualObject.SetActive(true);
    }
}
