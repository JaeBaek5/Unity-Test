using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float moveDistance = 2.0f;
    public float moveSpeed = 2.0f;

    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);

        float distanceFromStart = transform.position.x - startPos.x;

        if (direction == 1 && distanceFromStart > moveDistance)
        {
            transform.position = new Vector3(startPos.x + moveDistance, transform.position.y, transform.position.z);
            direction = -1;
        }
        else if (direction == -1 && distanceFromStart < -moveDistance)
        {
            transform.position = new Vector3(startPos.x - moveDistance, transform.position.y, transform.position.z);
            direction = 1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 부모 오브젝트가 비활성화 중이거나 파괴 중일 때 방지
            if (collision.transform.parent == this.transform)
            {
                collision.transform.SetParent(null);
            }
        }
    }
}


