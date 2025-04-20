using System.Collections;
using UnityEngine;

public class PlayerShootingActions : PlayerVariables
{
    [SerializeField] private float _rotationSpeed;

    private bool m_ReadyForAction = true;
    private float m_SingleShootDelay = 1;
    public bool m_SingleShootPreparing;
    public bool m_CoverShootPreparing;
    private bool m_IsAiming;
    private Vector2 _input;
    private Vector3 _direction;
    public void SingleShot()
    {
        m_Animator.SetTrigger("Shoot");
        StartCoroutine(ActionReloading(m_SingleShootDelay));
        m_WeaponGeneral.Shoot();
    }
    public void CoverShot(bool state)
    {
        //m_CoverShootPreparing = state;
        m_Animator.SetBool("CoverShoot", state);
        m_WeaponGeneral.CoverShoot(state);
        m_States.InCoverPosition = !state;
        m_ReadyForAction = !state;
    }
    IEnumerator ActionReloading(float time)
    {
        m_States.InCoverPosition = false;
        m_ReadyForAction = false;
        yield return new WaitForSeconds(time);
        m_SingleShootPreparing = false;
        m_IsAiming = false;
        m_ReadyForAction = true;
        m_States.InCoverPosition = transform;
    }
    private void Update()
    {
        if (!m_ReadyForAction) return;
        if (m_IsAiming)
        {
            _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _direction = Quaternion.Euler(0, Camera.allCameras[0].transform.eulerAngles.y, 0) * new Vector3(_input.x, 0, _input.y);
            if (Physics.Raycast(Camera.allCameras[0].ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                Vector3 diff = hit.point - transform.position;
                diff.Normalize();
                float rot = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rot, 0), Time.deltaTime * _rotationSpeed);
                _direction = transform.InverseTransformDirection(_direction);
            }
        }
        if (m_SingleShootPreparing && Input.GetMouseButtonDown(1))
        {
            SingleShot();
        }
        if (m_CoverShootPreparing && Input.GetMouseButtonDown(1))
        {
            CoverShot(true);
        }
        m_States.ShootState = m_IsAiming;
    }
    public void PrepareForSingleShoot()
    {
        if (m_States.MovingState) return;
        m_IsAiming = !m_IsAiming;
        m_SingleShootPreparing = !m_SingleShootPreparing;
    }
    public void PrepareForCoverShoot()
    {
        if (m_States.MovingState) return;
        if(m_CoverShootPreparing) CoverShot(false);
        m_IsAiming = !m_IsAiming;
        m_CoverShootPreparing = !m_CoverShootPreparing;
    }
}
