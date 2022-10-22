using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    /// <summary>
    /// 変数0.05を、float方で作成したmoveに入れる
    /// </summary>
    float move = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //変形設定の位置情報の、vector3で作成した変数posにいれます
        Vector3 pos = transform.position;
        //変数posのx座標に変数moveを足して入れる
        pos.x += move;
        //変数posを、変形設定の位置情報に入れる
        transform.position = pos;
    }
}
