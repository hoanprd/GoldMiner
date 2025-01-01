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
    public Animator playerAnim;

    private float currentAngle; // Góc hiện tại của móc câu
    private bool movingClockwise = true; // Hướng di chuyển
    private bool isShooting = false; // Trạng thái bắn móc câu
    private bool isReturning = false; // Trạng thái quay về
    private Vector3 shootDirection; // Hướng bắn của móc câu
    private Vector3 initialPosition; // Vị trí ban đầu của móc câu
    private int itemHookIndex;

    private GameObject attached = null; // Tham chiếu đến vàng được gắn (nếu có)

    void Start()
    {
        itemHookIndex = 0;
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
        if (itemHookIndex == 0)
            playerAnim.SetBool("hookGold", true);
        else if (itemHookIndex == 1)
        {
            Debug.Log("Hi");
            playerAnim.SetBool("hookRock", true);
        }

        float returnSpeed = baseReturnSpeed;

        if (attached != null)
        {
            // Lấy khối lượng của vàng để làm chậm tốc độ quay về
            float itemWeight = attached.GetComponent<GoldController>().GetGoldWeight();
            returnSpeed /= itemWeight; // Vàng nặng làm chậm tốc độ quay về
        }

        transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, initialPosition) < 0.01f)
        {
            isReturning = false;
            isShooting = false;

            if (attached != null)
            {
                // Thêm điểm từ vàng đã thu thập
                int goldPoints = attached.GetComponent<GoldController>().GetGoldValue();
                GameManager.Instance.AddScore(goldPoints); // Cộng điểm vào GameManager

                Destroy(attached); // Hủy vàng
                if (itemHookIndex == 0)
                    playerAnim.SetBool("hookGold", false);
                else if (itemHookIndex == 1)
                {
                    playerAnim.SetBool("hookRock", false);
                    playerAnim.SetBool("angry", true);
                }

                attached = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hookRange"))
        {
            isReturning = true;
        }
        else if (collision.CompareTag("gold") && attached == null)
        {
            attached = collision.gameObject;
            itemHookIndex = 0;
            collision.GetComponent<GoldController>().AttachToHook(transform);
            isReturning = true;
        }
        else if (collision.CompareTag("rock") && attached == null)
        {
            attached = collision.gameObject;
            itemHookIndex = 1;
            collision.GetComponent<GoldController>().AttachToHook(transform);
            isReturning = true;
        }
    }
}
