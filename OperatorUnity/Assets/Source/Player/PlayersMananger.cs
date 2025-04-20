using UnityEngine;

public class PlayersMananger : MonoBehaviour
{
    [SerializeField] private PlayerMovement[] m_Players;
    [SerializeField] private PlayerUICards[] m_Cards;
    public void ChoosePlayer(int playerIndex)
    {
        for (int i = 0; i < m_Players.Length; i++)
        {
            if(i == playerIndex)
            {
                m_Players[i].SwitchTargetPlayer(true);
                m_Cards[i].SwitchStatus(true);
            }
            else
            {
                m_Players[i].SwitchTargetPlayer(false);
                m_Cards[i].SwitchStatus(false);
            }
        }
    }
}
