using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class PredatorAnimal : Animal
{
    [SerializeField]
    private float chaseSpeed = 10;
    [SerializeField]
    private float searchingSpeed = 5;

    // POLYMORPHISM
    protected override void Update()
    {
        //Chasing prey
        if (m_target != null)
        {
            if (Vector3.Distance(transform.position, m_target.transform.position) < 2.0f)
            {
                Destroy(m_target);
                m_target = null;
                m_agent.isStopped = true;
            }
            else
                ChaseTarget(m_target);
        }
        else
        {
            if (m_agent.remainingDistance < 2 || m_agent.isStopped)
            {
                Speed = searchingSpeed;
                m_agent.isStopped = true;
                Animal target = SearchForNearestAnimal(1 << 7);
                if (target != null)
                {
                    m_target = target.gameObject;
                } else
                    WanderAround();
            }
        }
    }

    public virtual void ChaseTarget(GameObject target)
    {
        Speed = chaseSpeed;
        m_target = target;
        GoTo(m_target.transform.position);
    }
}
