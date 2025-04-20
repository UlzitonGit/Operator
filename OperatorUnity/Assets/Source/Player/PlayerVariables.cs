using UnityEngine;
using UnityEngine.AI;

public class PlayerVariables : MonoBehaviour
{
    protected Animator m_Animator;
    protected PlayerStates m_States;
    protected WeaponGeneral m_WeaponGeneral;
    protected NavMeshAgent m_Agent;
    protected PlayerShootingActions m_ShootingAcions;
    protected PlayerMovement m_PlayerMovement;
    private void Awake()
    {
        m_Animator = GetComponentInChildren<Animator>();
        m_States = GetComponent<PlayerStates>();
        m_Agent = GetComponent<NavMeshAgent>();
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_ShootingAcions = GetComponent<PlayerShootingActions>();
        m_WeaponGeneral = GetComponentInChildren<WeaponGeneral>();
    }
}
