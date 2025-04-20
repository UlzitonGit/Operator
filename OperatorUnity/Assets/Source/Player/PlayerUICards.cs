using UnityEngine;

public class PlayerUICards : MonoBehaviour
{
    [SerializeField] private GameObject[] m_Buttons;

    private bool IsActive;
    public void SwitchStatus(bool status)
    {
        IsActive = status;
        for (int i = 0; i < m_Buttons.Length; i++)
        {
            m_Buttons[i].SetActive(status);
        }
    }

}
