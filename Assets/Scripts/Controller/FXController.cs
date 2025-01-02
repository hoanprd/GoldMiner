using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Tự hủy object sau 2 giây
        Destroy(gameObject, 1f);
    }
}
