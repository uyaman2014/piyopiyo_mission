using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    /// <summary>
    /// �ϐ�0.05���Afloat���ō쐬����move�ɓ����
    /// </summary>
    float move = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�ό`�ݒ�̈ʒu���́Avector3�ō쐬�����ϐ�pos�ɂ���܂�
        Vector3 pos = transform.position;
        //�ϐ�pos��x���W�ɕϐ�move�𑫂��ē����
        pos.x += move;
        //�ϐ�pos���A�ό`�ݒ�̈ʒu���ɓ����
        transform.position = pos;
    }
}
