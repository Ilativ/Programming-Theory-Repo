using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Animal : MonoBehaviour
{
    protected NavMeshAgent m_agent;

    [SerializeField]
    protected GameObject m_target;
    [SerializeField]
    protected float senseRange;

    protected float m_speed = 3;
    // ENCAPSULATION
    public float Speed
    {
        get => m_speed;
        set { 
            m_speed = value;
            m_agent.speed = value;
        }
    }

    public float acceleration = 8;
    public float angularSpeed = 120;

    protected void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.speed = Speed;
        m_agent.acceleration = acceleration;
        m_agent.angularSpeed = angularSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_agent.isStopped = true;        
    }

    // ABSTRACTION
    // Update is called once per frame
    protected abstract void Update();

    //protected virtual void GetDistance

    protected virtual Animal SearchForNearestAnimal(LayerMask layer)
    {
        Animal nearestAnimal = null;
        float nearestTarget = float.MaxValue;
        float nextTarget = 0;
        foreach (Collider col in GetAllAnimalsInRange(layer))
        {
            Debug.Log(col.gameObject.name);
            nextTarget = Vector3.Distance(col.gameObject.transform.position, transform.position);
            if (nextTarget < nearestTarget)
            {
                nearestTarget = nextTarget;
                nearestAnimal = col.gameObject.GetComponent<Animal>();
            }
        }
        return nearestAnimal;
    }

    protected virtual Collider[] GetAllAnimalsInRange(LayerMask layer)
    {
        return Physics.OverlapSphere(transform.position, senseRange, layer);
    }

    protected virtual void WanderAround()
    {
        if (m_agent.isStopped)
            GoTo(new Vector3(Random.Range(-15, 15), 0, Random.Range(-10, 10)));
    }

    public virtual void GoTo(Vector3 position)
    {        
        m_agent.SetDestination(position);
        m_agent.isStopped = false;
    }
}
