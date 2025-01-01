using UnityEngine;

public class HookController : MonoBehaviour
{
    public Transform pivot; // Điểm quay (ông già đào vàng)
    public float radius = 2f; // Bán kính của hình bán nguyệt
    public float rotationSpeed = 50f; // Tốc độ quay
    public float minAngle = -90f; // Góc quay nhỏ nhất (độ)
    public float maxAngle = 90f;  // Góc quay lớn nhất (độ)
    public float shootSpeed = 5f; // Tốc độ bắn móc câu
    public float baseReturnSpeed = 7f; // Tốc độ quay về của móc câu (không có vàng)

    private float currentAngle; // Góc hiện tại của móc câu
    private bool movingClockwise = true; // Hướng di chuyển
    private bool isShooting = false; // Trạng thái bắn móc câu
    private bool isReturning = false; // Trạng thái quay về
    private Vector3 shootDirection; // Hướng bắn của móc câu
    private Vector3 initialPosition; // Vị trí ban đầu của móc câu

    private GameObject attachedGold = null; // Tham chiếu đến vàng được gắn (nếu có)

    void Start()
    {
        currentAngle = minAngle; // Đặt góc ban đầu
        initialPosition = transform.position; // Ghi nhận vị trí ban đầu
    }

    void Update()
    {
        // Kiểm tra nếu game đã kết thúc, dừng tất cả các hành động
        if (GameManager.Instance.IsGameOver)
        {
            return; // Dừng lại nếu game over
        }

        // Tiến hành các hành động khác nếu game chưa kết thúc
        if (isReturning)
        {
            ReturnToStart();
        }
        else if (isShooting)
        {
            ShootHook();
        }
        else
        {
            UpdateRotation();
        }

        // Kiểm tra sự kiện bắn móc câu (khi game chưa kết thúc)
        if (Input.GetMouseButtonDown(0) && !isShooting && !isReturning)
        {
            StartShooting();
        }
    }

    private void UpdateRotation()
    {
        if (movingClockwise)
        {
            currentAngle += rotationSpeed * Time.deltaTime;
            if (currentAngle >= maxAngle)
            {
                currentAngle = maxAngle;
                movingClockwise = false;
            }
        }
        else
        {
            currentAngle -= rotationSpeed * Time.deltaTime;
            if (currentAngle <= minAngle)
            {
                currentAngle = minAngle;
                movingClockwise = true;
            }
        }

        float radians = currentAngle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Sin(radians), -Mathf.Cos(radians), 0) * radius;
        transform.position = pivot.position + offset;

        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
    }

    private void StartShooting()
    {
        isShooting = true;
        initialPosition = transform.position; // Ghi nhận vị trí trước khi bắn
        float radians = currentAngle * Mathf.Deg2Rad;
        shootDirection = new Vector3(Mathf.Sin(radians), -Mathf.Cos(radians), 0);
    }

    private void ShootHook()
    {
        transform.position += shootDirection * shootSpeed * Time.deltaTime;
    }

    private void ReturnToStart()
    {
        float returnSpeed = baseReturnSpeed;

        if (attachedGold != null)
        {
            // Lấy khối lượng của vàng để làm chậm tốc độ quay về
            float goldWeight = attachedGold.GetComponent<GoldController>().GetGoldWeight();
            returnSpeed /= goldWeight; // Vàng nặng làm chậm tốc độ quay về
        }

        transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, initialPosition) < 0.01f)
        {
            isReturning = false;
            isShooting = false;

            if (attachedGold != null)
            {
                // Thêm điểm từ vàng đã thu thập
                int goldPoints = attachedGold.GetComponent<GoldController>().GetGoldValue();
                GameManager.Instance.AddScore(goldPoints); // Cộng điểm vào GameManager

                Destroy(attachedGold); // Hủy vàng
                attachedGold = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hookRange"))
        {
            isReturning = true;
        }
        else if (collision.CompareTag("gold") && attachedGold == null)
        {
            attachedGold = collision.gameObject;
            collision.GetComponent<GoldController>().AttachToHook(transform);
            isReturning = true;
        }
    }
}
