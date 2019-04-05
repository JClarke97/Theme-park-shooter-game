/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscript : MonoBehaviour
{

    private Vector3 m_startpos;
    private Vector3 m_endpos;
    private float m_travelTime;
    private float m_timer;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        m_timer += Time.deltaTime;
        transform.position = Vector3.Lerp(m_startpos, m_endpos, m_timer / m_travelTime);
        if (m_timer >= m_travelTime) Destroy(GameObject);
    }
    public void SetValues(Vector3 start, Vector3 end, float duration)
    {
        m_startpos = start;
        m_endpos = end;
        m_timer = 0;
    }
    public void SpawnBullet(Vector3 start, Vector3 end, float duration)
    {
        GameObject bulletGameObject = Instantiate(Resources.Load("Bullet", typeof(GameObject)), start, transform.rotation);
        Bullet bulletComponent = bulletGameObject.AddComponent<Bullet>();
        bulletComponent.SetVelues(start, end, duration);
    }
}
*/