using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 3f;
    public float swimRange = 5f;
    
    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // 1. เคลื่อนที่ไปตามแกน X ของโลก (World Space) เสมอ ไม่สนว่าตัวจะหันไปทางไหน
        float step = speed * Time.deltaTime;
        if (movingRight)
        {
            transform.position += Vector3.right * step;
            // ตรวจสอบระยะ
            if (transform.position.x >= startPos.x + swimRange)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.position += Vector3.left * step;
            // ตรวจสอบระยะ
            if (transform.position.x <= startPos.x - swimRange)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        // สั่งหมุนตัว 180 องศาจากทิศปัจจุบัน
        transform.Rotate(0, 180, 0);
    }
}