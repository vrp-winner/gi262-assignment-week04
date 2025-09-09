using System.Collections.Generic;
using UnityEngine;

namespace Solution {
    public class Inventory : MonoBehaviour
    {
        // ["Key": 10] ["Potion": 2] ["Sword": 1]
        public Dictionary<string, int> inventory = new Dictionary<string, int>();

        // ���������
        public void AddItem(string item, int amount)
        {
            // 1. ��Ǩ�ͺ�������������㹤�ѧ���������ѧ
            if (inventory.ContainsKey(item))
            {
                inventory[item] += amount;
            }
            else
            {
                inventory.Add(item, amount);
            }

            Debug.Log("Added " + amount + " " + item + ". Total: " + inventory[item]);
        }

        // ź�����
        public void RemoveItem(string item, int amount)
        {
            //4. ��Ǩ�ͺ�������������㹤�ѧ�������
            if (inventory.ContainsKey(item))
            {
                inventory[item] -= amount;
                if (inventory[item] <= 0)
                {
                    inventory.Remove(item);
                }
            }
        }
        public bool HasItem(string item, int amount)
        {
            //2. ��Ǩ�ͺ�������������㹤�ѧ������� ����ըӹǹ��§���������
            return inventory.ContainsKey(item) && inventory[item] >= amount;
        }
        // ��Ǩ�ͺ�ӹǹ�����
        public int GetItemCount(string item)
        {
            //3. ��Ǩ�ͺ�������������㹤�ѧ������� ��������׹��Ҩӹǹ��������
            if (inventory.ContainsKey(item))
            {
                return inventory[item];
            }
            else
            {
                return 0;
            }
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

