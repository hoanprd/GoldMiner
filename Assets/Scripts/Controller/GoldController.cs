using UnityEngine;

public enum GoldType
{
    Light,   // Vàng nhẹ
    Medium,  // Vàng trung bình
    Heavy    // Vàng nặng
}

public class GoldController : MonoBehaviour
{
    public GoldType goldType; // Loại vàng (Light, Medium, Heavy)
    private Transform hook; // Tham chiếu đến móc câu
    private bool isAttached = false; // Trạng thái vàng đã dính vào móc câu

    public int lightGoldValue = 10;  // Điểm cho vàng nhẹ
    public int mediumGoldValue = 20; // Điểm cho vàng trung bình
    public int heavyGoldValue = 30;  // Điểm cho vàng nặng

    public float lightGoldWeight = 1f;  // Khối lượng của vàng nhẹ
    public float mediumGoldWeight = 2f; // Khối lượng của vàng trung bình
    public float heavyGoldWeight = 3f;  // Khối lượng của vàng nặng

    private int goldValue; // Điểm của vàng hiện tại
    private float goldWeight; // Khối lượng của vàng

    void Start()
    {
        // Cập nhật giá trị điểm và khối lượng của vàng dựa trên loại vàng
        switch (goldType)
        {
            case GoldType.Light:
                goldValue = lightGoldValue;
                goldWeight = lightGoldWeight;
                break;
            case GoldType.Medium:
                goldValue = mediumGoldValue;
                goldWeight = mediumGoldWeight;
                break;
            case GoldType.Heavy:
                goldValue = heavyGoldValue;
                goldWeight = heavyGoldWeight;
                break;
        }
    }

    void Update()
    {
        if (isAttached && hook != null)
        {
            // Vàng di chuyển cùng với móc câu
            transform.position = hook.position;
        }
    }

    public void AttachToHook(Transform hookTransform)
    {
        hook = hookTransform; // Gán móc câu hiện tại
        isAttached = true;    // Đánh dấu vàng đã được gắn
    }

    public int GetGoldValue()
    {
        return goldValue; // Trả về giá trị điểm của vàng
    }

    public float GetGoldWeight()
    {
        return goldWeight; // Trả về khối lượng của vàng
    }
}
