using UnityEngine;

namespace Solution
{
    public class CollectAbleItem : Identity
    {
        public override bool Hit()
        {
            Debug.Log("Item: " + Name + " has been picked up.");
            // �����������͡�ҡ�ҡ
            mapGenerator.player.inventory.AddItem(Name, 1);
            Destroy(gameObject);
            mapGenerator.player.inventory.PrintInventory();

            return true;
        }
    }
}

