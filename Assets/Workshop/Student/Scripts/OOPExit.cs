using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Solution
{

    public class OOPExit : Identity
    {
        public GameObject YouWin;
        // ��˹������������Шӹǹ����ͧ�����㹡���Դ�ҧ�͡

        public override bool Hit()
        {
            // ��Ǩ�ͺ��Ҽ����������������ͧ����������
            YouWin.SetActive(true);
            Debug.Log("You win");
            return true;
          
        }
    }
}