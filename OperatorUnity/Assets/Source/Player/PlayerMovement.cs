using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : PlayerVariables
{

    [SerializeField] private GameObject m_TargetMark;
    [SerializeField] private GameObject m_Target;
    [SerializeField] private GameObject m_ChooseLight;
    private Transform m_ActualTarget;
    private GameObject m_GraphicTarget;
    private bool m_ChooseTarget;
    private bool m_IsMove;

    void Update()
    {
        FindTarget();
        Animations();
    }
    private void Animations()
    {
        m_Animator.SetBool("Run", m_IsMove);
    }
    private void FindTarget()
    {
        if (Physics.Raycast(Camera.allCameras[0].ScreenPointToRay(Input.mousePosition), out RaycastHit hit) && m_ChooseTarget && !m_IsMove)
        {
            
            if(m_GraphicTarget == null) m_GraphicTarget = Instantiate(m_TargetMark, hit.point, Quaternion.identity);
            else m_GraphicTarget.transform.position = hit.point;
            if (Input.GetMouseButtonDown(1))
            {
                m_ActualTarget = Instantiate(m_Target, hit.point, Quaternion.identity).GetComponent<Transform>();
                m_States.InCoverPosition = false;
                m_IsMove = true;
            }
        }
        if (m_IsMove && m_ActualTarget != null)
        {
            m_Agent.SetDestination(m_ActualTarget.position);
        }
        if(m_Agent.remainingDistance <= 10f && m_Agent.hasPath)
        {
            m_IsMove=false;        
        }
        if(m_Agent.remainingDistance <= 1f && m_Agent.hasPath)
        {
            m_States.InCoverPosition = true;
            m_Agent.destination = m_Agent.transform.position;
            
            Destroy(m_GraphicTarget.gameObject);
        }
        m_States.MovingState = m_ChooseTarget;
       
    }
    public void SwitchMovementPhase()
    {
       
        if (m_Agent.hasPath || m_States.ShootState) return;
        if (m_GraphicTarget != null) Destroy(m_GraphicTarget.gameObject);
        m_ChooseTarget = !m_ChooseTarget;
        m_TargetMark.SetActive(m_ChooseTarget);
    }
    public void SwitchTargetPlayer(bool phase)
    {
        m_ChooseTarget = false;
        m_ChooseLight.SetActive(phase);
    }
}
