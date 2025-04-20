using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Vector3 m_Dir;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(m_Dir);
    }
}
