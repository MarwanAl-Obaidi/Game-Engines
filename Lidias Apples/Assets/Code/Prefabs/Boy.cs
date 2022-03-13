using UnityEngine;

public class Boy : Character
{
    public Apple m_apple = null;
    public float m_delay = 3f;
    public Vector2 m_throwForce = new Vector2(3f, 10f);

    public override void InitCharacter()
    {
        HideApple();
    }

    public void HideApple()
    {
        m_apple.transform.position = Vector3.zero;
        m_apple.HideApple();
    }

    public void ShowApple()
    {
        m_apple.ShowApple();
    }

    public void AttachApple()
    {
        m_apple.AttachApple();
    }

    public void DetachApple(float f)
    {
        m_apple.DetachApple(f);
    }

    public void Throw()
    {
        float f = Random.Range(m_throwForce[0], m_throwForce[1]);
        Debug.Log(string.Format("Force: {0}", f));
        DetachApple(f);
    }
}
