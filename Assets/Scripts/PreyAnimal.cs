using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class PreyAnimal : Animal
{
    
    protected override void Update()
    {
        if (m_agent.remainingDistance < 2)
        {
            m_agent.isStopped = true;
            Animal predator = SearchForNearestAnimal(1 << 6);
            if (predator != null)
            {
                //Get away from perdator
                SetDoubleSpped();
                Vector3 oppositeDirection = (transform.position - predator.gameObject.transform.position).normalized;
                GoTo(oppositeDirection * 10);
            }
            else
            {
                m_agent.speed = m_speed;
                WanderAround();
            }
        }
    }

    void SetDoubleSpped()
    {
        if (m_agent.speed <= m_speed)
            m_agent.speed = m_speed * 2;
    }
}
