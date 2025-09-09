using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class GameEvent
    {
        public string EventType { get; set; }
        public string Name { get; set; }

        public GameEvent(string eventType, string description, int priority = 1)
        {
            EventType = eventType;
            Name = description;
        }
    }

    public interface IAssignment
    {
        #region Lecture 

        public void LCT01_SyntaxLinkedList();

        public void LCT02_SyntaxHashTable();

        public void LCT03_SyntaxDictionary();

        #endregion

        #region Assignment

        // AS01_CountWords accepts an array of strings and counts the occurrences of each word, returning a dictionary where the keys are the words and the values are their respective counts.
        public void AS01_CountWords(string[] words);

        // AS02_CountNumber accepts an array of integers and counts the occurrences of each number, returning a dictionary where the keys are the numbers and the values are their respective counts.
        public void AS02_CountNumber(int[] numbers);

        // AS03_CheckValidBrackets accepts a string containing various types of brackets (e.g., (), {}, []) and checks if the brackets are validly matched and nested.
        public void AS03_CheckValidBrackets(string input);

        // AS04_ReverseLinkedList accepts a LinkedList of integers and reverses the order of its elements in place.
        public void AS04_PrintReverseLinkedList(LinkedList<int> list);

        // AS05_FindMiddleElement accepts a LinkedList of strings and finds the middle element.
        // For even count, returns the second middle element (e.g., for [1,2,3,4] returns 3).
        public void AS05_FindMiddleElement(LinkedList<string> list);

        // AS06_MergeDictionaries accepts two Dictionaries with string keys and int values, merges them by summing values for common keys.
        public void AS06_MergeDictionaries(Dictionary<string, int> dict1, Dictionary<string, int> dict2);

        // AS07_RemoveDuplicatesFromLinkedList accepts a LinkedList of integers and removes duplicate elements, keeping only the first occurrence.
        public void AS07_RemoveDuplicatesFromLinkedList(LinkedList<int> list);

        // AS08_TopFrequentNumber accepts an array of integers, and displays the most frequent number.
        public void AS08_TopFrequentNumber(int[] numbers);

        // AS09_PlayerInventory accepts a Dictionary representing player inventory (item name -> quantity) and an item name with quantity to add, updates the inventory.
        public void AS09_PlayerInventory(Dictionary<string, int> inventory, string itemName, int quantity);

        // EX01_GameEventQueue accepts a LinkedList of GameEvent objects and processes the next event in the queue.
        public void EX01_GameEventQueue(LinkedList<GameEvent> eventQueue);

        // EX02_PlayerStatsTracker accepts a Dictionary of player statistics and updates a specific stat by adding a value.
        public void EX02_PlayerStatsTracker(Dictionary<string, int> playerStats, string statName, int value);

        #endregion
    }
}
