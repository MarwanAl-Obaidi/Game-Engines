using System;
using UnityEngine;
using UnityEngine.UI;

[Obsolete("Do not use!")]
public class WinLoose : MonoBehaviour
{
    [SerializeField]
    private Text m_winText = null;
    [SerializeField]
    private Text m_looseText = null;

    public void HideTexts()
    {
        m_winText.gameObject.SetActive(false);
        m_looseText.gameObject.SetActive(false);
    }

    public void ShowTexts()
    {
        m_winText.gameObject.SetActive(true);
        m_looseText.gameObject.SetActive(true);
    }

    public void ShowWin()
    {
        m_winText.gameObject.SetActive(true);
        m_looseText.gameObject.SetActive(false);
    }

    public void ShowLost()
    {
        m_winText.gameObject.SetActive(false);
        m_looseText.gameObject.SetActive(true);
    }
}
