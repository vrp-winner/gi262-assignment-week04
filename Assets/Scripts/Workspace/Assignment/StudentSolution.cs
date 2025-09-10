using UnityEngine;
using AssignmentSystem.Services;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Assignment
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {
        #region Lecture

        public void LCT01_SyntaxLinkedList()
        {
            LinkedList<string> linkedlist = new LinkedList<string>();
            linkedlist.AddLast("Node 1"); // ["Node 1"]
            linkedlist.AddLast("Node 2"); // ["Node 1"]->["Node 2"]

            linkedlist.AddFirst("Node 0"); // ["Node 0"]->["Node 1"]->["Node 2"]

            PrintLCT01(linkedlist);

            LinkedListNode<string> firstNode = linkedlist.First;
            Debug.Log($"first {firstNode.Value}");

            LinkedListNode<string> lastNode = linkedlist.Last;
            Debug.Log($"last {lastNode.Value}");

            //Debug.Log(firstNode.Next.Value);
            //Debug.Log(lastNode.Previous.Value);

            LinkedListNode<string> node1 = linkedlist.Find("Node 1");
            Debug.Log(node1.Previous.Value);
            Debug.Log(node1.Next.Value);

            if (firstNode.Previous == null)
            {
                Debug.Log("firstNode.Previous is null");
            }
            if (lastNode.Next == null)
            {
                Debug.Log("lastNode.Next is null");
            }

            linkedlist.AddAfter(node1, "Node 1.5");
            linkedlist.AddBefore(node1, "Node 0.5");
            PrintLCT01(linkedlist);
            // ["Node 0"]->["Node 0.5"]->["Node 1"]->["Node 1.5"]->["Node 2"]

            linkedlist.RemoveFirst();
            PrintLCT01(linkedlist);
            // ["Node 0.5"]->["Node 1"]->["Node 1.5"]->["Node 2"]

            linkedlist.Remove("Node 2");
            PrintLCT01(linkedlist);
            // ["Node 0.5"]->["Node 1"]->["Node 1.5"]
        }

        private void PrintLCT01(LinkedList<string> linkedlist)
        {
            Debug.Log("LinkedList ...");
            foreach (var node in linkedlist)
            {
                Debug.Log(node);
            }
        }

        public void LCT02_SyntaxHashTable()
        {
            // 1. สร้าง Hashtable
            Hashtable hashtable = new Hashtable();

            // 2. การเพิ่มข้อมูลลงใน Hashtable
            hashtable.Add(1, "Apple");
            hashtable.Add(2, "Banana");
            hashtable.Add("bad-fruit", "Rotten Tomato");

            // 3. เข้าถึงข้อมูลใน Hashtable ด้วย Key
            string fruit1 = (string)hashtable[1];
            string fruit2 = (string)hashtable[2];
            string badFruit = (string)hashtable["bad-fruit"];
            Debug.Log($"fruit1: {fruit1}");
            Debug.Log($"fruit2: {fruit2}");
            Debug.Log($"badFruit: {badFruit}");

            // 4. แสดงข้อมูลใน Hashtable
            LCT02_PrintHashTable(hashtable);

            // 5. ตรวจสอบการมีอยู่ของ Key
            int key = 2;
            if (hashtable.ContainsKey(key))
            {
                Debug.Log($"found {key}");
            }
            else
            {
                Debug.Log($"not found {key}");
            }

            // 6. ลบข้อมูลออกจาก Hashtable
            int keyToRemove = 1;
            hashtable.Remove(keyToRemove);
            LCT02_PrintHashTable(hashtable);
        }

        private void LCT02_PrintHashTable(Hashtable hashtable)
        {
            // 4. แสดงข้อมูลใน Hashtable
            Debug.Log("table ...");
            foreach (DictionaryEntry entry in hashtable)
            {
                Debug.Log($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }

        public void LCT03_SyntaxDictionary()
        {

            // 1. สร้าง Dictionary โดยระบุชนิดของ Key และ Value
            // กำหนดให้ Key เป็น int และ Value เป็น string
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            // 2. การเพิ่มข้อมูลลงใน Dictionary
            dictionary.Add(1, "Apple");
            dictionary.Add(2, "Banana");
            dictionary[3] = "Cherry";

            // 3. แสดงข้อมูลใน Dictionary
            LCT03_PrintDictionary(dictionary);

            // 4. การตรวจสอบการมีอยู่ของคีย์ และการดึงค่าออกมาโดยใช้
            int keyToCheck = 1;
            bool hasKey = dictionary.ContainsKey(keyToCheck);
            Debug.Log($"has key {keyToCheck} : {hasKey}");
            if (hasKey)
            {
                string value = dictionary[keyToCheck];
                Debug.Log($"value of key {keyToCheck} : {value}");
            }

            // 5. การดึง key ออกมาทั้งหมด
            Debug.Log("All keys in dictionary:");
            foreach (int key in dictionary.Keys)
            {
                Debug.Log(key);
            }

            // 6. ลบข้อมูลออกจาก Dictionary
            int keyToRemove = 1;
            dictionary.Remove(keyToRemove);
            LCT03_PrintDictionary(dictionary);

            // 7. clear ข้อมูลใน Dictionary
            dictionary.Clear();
        }

        private void LCT03_PrintDictionary(Dictionary<int, string> dictionary)
        {
            // 3. แสดงข้อมูลใน Dictionary
            Debug.Log($"Dictionary has {dictionary.Count} keys");
            foreach (KeyValuePair<int, string> entry in dictionary)
            {
                Debug.Log($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }

        #endregion

        #region Assignment

        public void AS01_CountWords(string[] words)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            string[] keys = new string[wordCount.Keys.Count];
            int[] values = new int[wordCount.Values.Count];
            wordCount.Keys.CopyTo(keys, 0);
            wordCount.Values.CopyTo(values, 0);

            for (int i = 0; i < keys.Length; i++)
            {
                Debug.Log($"word: '{keys[i]}' count: {values[i]}");
            }
        }

        public void AS02_CountNumber(int[] numbers)
        {
            Dictionary<int, int> numberCount = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int num = numbers[i];

                if (numberCount.ContainsKey(num))
                {
                    numberCount[num]++;
                }
                else
                {
                    numberCount[num] = 1;
                }
            }

            int[] keys = new int[numberCount.Keys.Count];
            int[] values = new int[numberCount.Values.Count];
            numberCount.Keys.CopyTo(keys, 0);
            numberCount.Values.CopyTo(values, 0);

            for (int i = 0; i < keys.Length; i++)
            {
                Debug.Log($"number: {keys[i]} count: {values[i]}");
            }
        }

        public void AS03_CheckValidBrackets(string input)
        {
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            LinkedList<char> stack = new LinkedList<char>();

            foreach (char ch in input)
            {
                if (bracketPairs.ContainsKey(ch))
                {
                    stack.AddLast(ch);
                }
                else if (bracketPairs.ContainsValue(ch))
                {
                    if (stack.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }

                    char lastOpen = stack.Last.Value;
                    stack.RemoveLast();

                    if (bracketPairs[lastOpen] != ch)
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                }
            }

            Debug.Log(stack.Count == 0 ? "Valid" : "Invalid");
        }

        public void AS04_PrintReverseLinkedList(LinkedList<int> list)
        {
            if (list == null || list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<int> current = list.Last;
            while (current != null)
            {
                Debug.Log(current.Value);
                current = current.Previous;
            }
        }

        public void AS05_FindMiddleElement(LinkedList<string> list)
        {
            if (list == null || list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;
            
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Debug.Log(slow.Value);
        }

        public void AS06_MergeDictionaries(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
        {
            Dictionary<string, int> merged = new Dictionary<string, int>(dict1);

            foreach (var kv in dict2)
            {
                if (merged.ContainsKey(kv.Key))
                {
                    merged[kv.Key] += kv.Value;
                }
                else
                {
                    merged[kv.Key] = kv.Value;
                }
            }

            foreach (var kv in merged)
            {
                Debug.Log($"key: {kv.Key}, value: {kv.Value}");
            }
        }

        public void AS07_RemoveDuplicatesFromLinkedList(LinkedList<int> list)
        {
            if (list == null || list.Count <= 1) return;

            Dictionary<int, bool> seen = new Dictionary<int, bool>();
            LinkedListNode<int> current = list.First;

            while (current != null)
            {
                if (seen.ContainsKey(current.Value))
                {
                    LinkedListNode<int> toRemove = current;
                    current = current.Next;
                    list.Remove(toRemove);
                }
                else
                {
                    seen[current.Value] = true;
                    current = current.Next;
                }
            }

            foreach (var val in list)
            {
                Debug.Log(val);
            }
        }

        public void AS08_TopFrequentNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }

            Dictionary<int, int> freq = new Dictionary<int, int>();

            foreach (int num in numbers)
            {
                if (freq.ContainsKey(num)) freq[num]++;
                else freq[num] = 1;
            }

            int topNumber = 0;
            int maxCount = 0;

            foreach (var kv in freq)
            {
                if (kv.Value > maxCount)
                {
                    topNumber = kv.Key;
                    maxCount = kv.Value;
                }
            }

            Debug.Log($"{topNumber} count: {maxCount}");
        }

        public void AS09_PlayerInventory(Dictionary<string, int> inventory, string itemName, int quantity)
        {
            if (inventory == null)
            {
                Debug.Log("Inventory is null");
                return;
            }

            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory[itemName] = quantity;
            }

            foreach (var kv in inventory)
            {
                Debug.Log($"{kv.Key}: {kv.Value}");
            }
        }

        #endregion 

        #region Extra

        public void EX01_GameEventQueue(LinkedList<GameEvent> eventQueue)
        {
            if (eventQueue == null || eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }

            while (eventQueue.Count > 0)
            {
                GameEvent currentEvent = eventQueue.First.Value;
                eventQueue.RemoveFirst();

                Debug.Log($"Processing event: {currentEvent.Name}");
                Debug.Log($"Remaining events in queue: {eventQueue.Count}");

                string lowerName = currentEvent.Name.ToLower();

                if (lowerName.Contains("goblin") || lowerName.Contains("enemy"))
                {
                    Debug.Log($"Enemy event processed - {currentEvent.Name}");
                }
                else if (lowerName.Contains("boost") || lowerName.Contains("powerup"))
                {
                    Debug.Log($"Power-up event processed - {currentEvent.Name}");
                }
                else if (lowerName.Contains("level"))
                {
                    Debug.Log($"Level event processed - {currentEvent.Name}");
                }
                else if (lowerName.Contains("kill") || lowerName.Contains("achievement"))
                {
                    Debug.Log($"Achievement unlocked - {currentEvent.Name}");
                }
                else
                {
                    Debug.Log($"Generic event processed - {currentEvent.Name}");
                }
            }
        }

        public void EX02_PlayerStatsTracker(Dictionary<string, int> playerStats, string statName, int value)
        {
            if (playerStats == null)
            {
                Debug.Log("Player stats dictionary is null");
                return;
            }

            if (string.IsNullOrEmpty(statName))
            {
                Debug.Log("Stat name is null or empty");
                return;
            }

            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
            }
            else
            {
                playerStats[statName] = value;
            }

            Debug.Log($"Updated {statName}: {playerStats[statName]}");

            Debug.Log("Current player statistics:");
            foreach (var stat in playerStats)
            {
                Debug.Log($"{stat.Key}: {stat.Value}");
            }
        }

        #endregion
    }
}