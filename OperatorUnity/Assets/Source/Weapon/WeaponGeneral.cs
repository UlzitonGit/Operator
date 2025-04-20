using UnityEngine;

abstract public class WeaponGeneral : PlayerVariables
{
    [SerializeField] protected int m_SingleShootTimes;
    [SerializeField] protected GameObject m_Bullet;
    [SerializeField] protected int m_Ammo;
    [SerializeField] protected Transform m_ShootPoint;
    [SerializeField] protected float m_Damage;
    [SerializeField] protected float m_ReloadTime;
    [SerializeField] protected float m_ShootRate;
    [SerializeField] protected float m_singleShotRecoil;
    [SerializeField] protected float m_CoverShootRecoil;
    protected int m_AmmoMax => m_Ammo;
    protected bool m_CanShoot;
    abstract public void Shoot();
    abstract public void Reload();
    abstract public void CoverShoot(bool isStoped);
    abstract public void Recoil(float recoil);
}
