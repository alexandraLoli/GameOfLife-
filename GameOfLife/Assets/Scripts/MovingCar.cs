using UnityEngine;

public class CarMovementLoop : MonoBehaviour
{
    public Transform pointA; // Punctul A
    public Transform pointB; // Punctul B
    public float speed = 100f; 

    private Transform target; 
    private bool movingToB = true; 

    private void Start()
    {
        target = pointB;
    }

    private void Update()
    {
        
        if (target != null)
        {
            
            float step = speed * Time.deltaTime;

            
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                 if (movingToB)
                {
                
                    movingToB = false;
                    transform.position = pointA.position;
                }
                else
                {
                    target = pointB;
                    movingToB = true;
                    transform.position = pointB.position;
                }
            }
        }
    }
}
