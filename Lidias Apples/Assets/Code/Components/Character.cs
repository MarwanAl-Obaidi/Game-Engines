using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector]
    public Animator m_animator = null;

    public virtual void Start()
    {
        m_animator = this.GetComponent<Animator>();
    }

    public virtual void InitCharacter()
    {

    }
}
