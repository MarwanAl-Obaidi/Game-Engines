using UnityEngine;

public class Terrain : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Game.m_boy.m_apple.HideApple();
        Game.AddMissedApple();
    }
}
