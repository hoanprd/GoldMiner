using UnityEngine;

public enum GoldType
{
    GoldLight,   // Vàng nhẹ
    GoldMedium,  // Vàng trung bình
    GoldHeavy,    // Vàng nặng
    Diamond,
    Pack,
    RockLight,
    RockMedium,
    RockHeavy
}

public class GoldController : MonoBehaviour
{
    public GoldType goldType; // Loại vàng (Light, Medium, Heavy)
    private Transform hook; // Tham chiếu đến móc câu
    private bool isAttached = false; // Trạng thái vàng đã dính vào móc câu

    public int value;
    public int weight;

    /*public int lightGoldValue = 10;  // Điểm cho vàng nhẹ
    public int mediumGoldValue = 20; // Điểm cho vàng trung bình
    public int heavyGoldValue = 30;  // Điểm cho vàng nặng
    public int diamondValue = 40;
    public int packValue = 50;
    public int lightRockValue = 10;  // Điểm cho vàng nhẹ
    public int mediumRockValue = 20; // Điểm cho vàng trung bình
    public int heavyRockValue = 30;  // Điểm cho vàng nặng

    public float lightGoldWeight = 1f;  // Khối lượng của vàng nhẹ
    public float mediumGoldWeight = 2f; // Khối lượng của vàng trung bình
    public float heavyGoldWeight = 3f;  // Khối lượng của vàng nặng
    public float lightRockWeight = 1f;  // Khối lượng của vàng nhẹ
    public float mediumRockWeight = 2f; // Khối lượng của vàng trung bình
    public float heavyRockWeight = 3f;  // Khối lượng của vàng nặng*/

    private int goldValue; // Điểm của vàng hiện tại
    private float goldWeight; // Khối lượng của vàng

    void Start()
    {
        // Cập nhật giá trị điểm và khối lượng của vàng dựa trên loại vàng
        goldValue = value;
        goldWeight = weight;

        /*switch (goldType)
        {
            case GoldType.GoldLight:
                goldValue = lightGoldValue;
                goldWeight = lightGoldWeight;
                break;
            case GoldType.GoldMedium:
                goldValue = mediumGoldValue;
                goldWeight = mediumGoldWeight;
                break;
            case GoldType.GoldHeavy:
                goldValue = heavyGoldValue;
                goldWeight = heavyGoldWeight;
                break;
            case GoldType.Diamond:
                goldValue = diamondValue;
                goldWeight = mediumGoldWeight;
                break;
            case GoldType.Pack:
                goldValue = packValue;
                goldWeight = mediumGoldWeight;
                break;
            case GoldType.RockLight:
                goldValue = lightRockValue;
                goldWeight = lightRockWeight;
                break;
            case GoldType.RockMedium:
                goldValue = mediumRockValue;
                goldWeight = mediumRockWeight;
                break;
            case GoldType.RockHeavy:
                goldValue = heavyRockValue;
                goldWeight = heavyRockWeight;
                break;
        }*/
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
