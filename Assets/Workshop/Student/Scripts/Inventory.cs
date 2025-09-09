using System.Collections.Generic;
using UnityEngine;

namespace Solution {
    public class Inventory : MonoBehaviour
    {
        public Dictionary<string, int> inventory = new Dictionary<string, int>();

        // ���������
        public void AddItem(string item, int amount)
        {
            // 1. ��Ǩ�ͺ�������������㹤�ѧ���������ѧ
           

            Debug.Log("Added " + amount + " " + item + ". Total: " + inventory[item]);
        }

        // ź�����
        public void RemoveItem(string item, int amount)
        {
            //4. ��Ǩ�ͺ�������������㹤�ѧ�������
            
        }
        public bool HasItem(string item, int amount)
        {
            //2. ��Ǩ�ͺ�������������㹤�ѧ������� ����ըӹǹ��§���������
            return false;
        }
        // ��Ǩ�ͺ�ӹǹ�����
        public int GetItemCount(string item)
        {
            //3. ��Ǩ�ͺ�������������㹤�ѧ������� ��������׹��Ҩӹǹ��������
            return 0;
        }

        // �ʴ���¡�÷�����㹤�ѧ
        public void PrintInventory()
        {
            Debug.Log("--- Inventory Content ---");
            if (inventory.Count == 0)
            {
                Debug.Log("Inventory is empty.");
                return;
            }

            foreach (var itemEntry in inventory)
            {
                Debug.Log(itemEntry.Key + ": " + itemEntry.Value);
            }
        }
    }
}

