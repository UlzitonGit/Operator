using System.Collections;
using UnityEngine;

public class AsslautRifle : WeaponGeneral
{

    public override void Shoot()
    {
        StartCoroutine(ShootingSingle());
    }
    public override void CoverShoot(bool i)
    {
        if(i) StartCoroutine(CoverShooting()); 
        else StopAllCoroutines();

    }
    public override void Reload()
    {
        StartCoroutine(Reloading());
    }
    public override void Recoil(float r)
    {
        m_ShootPoint.localRotation = Quaternion.Euler(0f, -90f + Random.Range(r * -1, r), 0f);
    }
    IEnumerator ShootingSingle()
    {
        for (int i = 0; i < m_SingleShootTimes; i++)
        {
            Recoil(m_singleShotRecoil);
            yield return new WaitForSeconds(m_ShootRate);
            Instantiate(m_Bullet, m_ShootPoint.position, m_ShootPoint.rotation);
        }
    }
    IEnumerator CoverShooting()
    {
        for (int i = 0; i < m_SingleShootTimes; i++)
        {
            Recoil(m_CoverShootRecoil);
            yield return new WaitForSeconds(m_ShootRate);
            Instantiate(m_Bullet, m_ShootPoint.position, m_ShootPoint.rotation);
        }
        yield return new WaitForSeconds(m_ShootRate * 10);
        StartCoroutine(CoverShooting());
    }
    IEnumerator Reloading()
    {
        m_CanShoot = false;
        m_Ammo = 0;
        yield return new WaitForSeconds(m_ReloadTime);
        m_Ammo = m_AmmoMax;
        m_CanShoot = true;
    }
}
