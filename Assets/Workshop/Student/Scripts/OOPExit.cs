using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Solution
{

    public class OOPExit : Identity
    {
        public GameObject YouWin;
        // กำหนดชื่อไอเท็มและจำนวนที่ต้องการใช้ในการเปิดทางออก

        public override bool Hit()
        {
            bool hasEnoughKey = mapGenerator.player.inventory.HasItem("Key", 2);
            // ตรวจสอบว่าผู้เล่นมีไอเท็มที่ต้องการหรือไม่
            if (hasEnoughKey)
            {
                YouWin.SetActive(true);
                Debug.Log("You win");
            }
            return true;
          
        }
    }
}