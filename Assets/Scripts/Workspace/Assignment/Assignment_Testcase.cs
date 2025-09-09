using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AssignmentSystem.Services;
using System;

namespace Assignment
{
    public class Assignment_Testcase
    {
        private IAssignment assignment;

        [SetUp]
        public void Setup()
        {
            // Reset static state before each test
            AssignmentDebugConsole.Clear();

            // Use FinalSolution as the test subject
            assignment = new StudentSolution();
        }

        [TearDown]
        public void Teardown()
        {
            if (assignment is MonoBehaviour)
            {
                MonoBehaviour.DestroyImmediate(assignment as MonoBehaviour);
            }
        }

        #region Lecture Tests

        [Test]
        [Category("Lecture")]
        public void Test_LCT01_SyntaxLinkedList()
        {
            assignment.LCT01_SyntaxLinkedList();

            string output = AssignmentDebugConsole.GetOutput();

            // Check for expected output patterns
            Assert.IsTrue(output.Contains("LinkedList ..."));
            Assert.IsTrue(output.Contains("Node 0"));
            Assert.IsTrue(output.Contains("Node 1"));
            Assert.IsTrue(output.Contains("Node 2"));
            Assert.IsTrue(output.Contains("first"));
            Assert.IsTrue(output.Contains("last"));
            Assert.IsTrue(output.Contains("firstNode.Previous is null"));
            Assert.IsTrue(output.Contains("lastNode.Next is null"));
            Assert.IsTrue(output.Contains("Node 0.5"));
            Assert.IsTrue(output.Contains("Node 1.5"));
        }

        [Test]
        [Category("Lecture")]
        public void Test_LCT02_SyntaxHashTable()
        {
            assignment.LCT02_SyntaxHashTable();

            string output = AssignmentDebugConsole.GetOutput();

            // Check for expected output patterns
            Assert.IsTrue(output.Contains("fruit1: Apple"));
            Assert.IsTrue(output.Contains("fruit2: Banana"));
            Assert.IsTrue(output.Contains("badFruit: Rotten Tomato"));
            Assert.IsTrue(output.Contains("found 2"));
            Assert.IsTrue(output.Contains("table ..."));
        }

        [Test]
        [Category("Lecture")]
        public void Test_LCT03_SyntaxDictionary()
        {
            assignment.LCT03_SyntaxDictionary();

            string output = AssignmentDebugConsole.GetOutput();

            // Check for expected output patterns
            Assert.IsTrue(output.Contains("Dictionary has 3 keys"));
            Assert.IsTrue(output.Contains("has key 1 : True"));
            Assert.IsTrue(output.Contains("value of key 1 : Apple"));
            Assert.IsTrue(output.Contains("All keys in dictionary:"));
            Assert.IsTrue(output.Contains("Dictionary has 2 keys"));
        }

        #endregion

        #region Assignment Tests

        [Category("Assignment")]
        [TestCase(new string[] { "apple", "banana", "apple", "cherry", "banana", "apple" },
                  "word: 'apple' count: 3\nword: 'banana' count: 2\nword: 'cherry' count: 1",
                  TestName = "AS01_CountWords_BasicScenario", Description = "Count word frequencies in basic scenario")]
        [TestCase(new string[] { "hello", "world", "hello" },
                  "word: 'hello' count: 2\nword: 'world' count: 1",
                  TestName = "AS01_CountWords_SimpleCase", Description = "Count word frequencies in simple case")]
        [TestCase(new string[] { "test" },
                  "word: 'test' count: 1",
                  TestName = "AS01_CountWords_SingleWord", Description = "Count single word")]
        [TestCase(new string[] { "a", "b", "c", "a", "b", "a" },
                  "word: 'a' count: 3\nword: 'b' count: 2\nword: 'c' count: 1",
                  TestName = "AS01_CountWords_ShortWords", Description = "Count frequencies of short words")]
        public void Test_AS01_CountWords_AllCases(string[] words, string expectedPattern)
        {
            assignment.AS01_CountWords(words);

            string output = AssignmentDebugConsole.GetOutput();

            // Verify all expected word counts are present (allowing flexible order)
            string[] expectedLines = expectedPattern.Split('\n');
            foreach (string expectedLine in expectedLines)
            {
                Assert.IsTrue(output.Contains(expectedLine),
                    $"Expected output to contain: {expectedLine}\nActual output: {output}");
            }
        }

        [Category("Assignment")]
        [TestCase(new int[] { 1, 2, 3, 2, 1, 3, 1 },
                  "number: 1 count: 3\nnumber: 2 count: 2\nnumber: 3 count: 2",
                  TestName = "AS02_CountNumber_BasicScenario", Description = "Count number frequencies in basic scenario")]
        [TestCase(new int[] { 5, 5, 5 },
                  "number: 5 count: 3",
                  TestName = "AS02_CountNumber_SameNumbers", Description = "Count same numbers")]
        [TestCase(new int[] { 10 },
                  "number: 10 count: 1",
                  TestName = "AS02_CountNumber_SingleNumber", Description = "Count single number")]
        [TestCase(new int[] { 0, -1, 2, 0, -1 },
                  "number: 0 count: 2\nnumber: -1 count: 2\nnumber: 2 count: 1",
                  TestName = "AS02_CountNumber_WithNegatives", Description = "Count frequencies including negative numbers")]
        public void Test_AS02_CountNumber_AllCases(int[] numbers, string expectedPattern)
        {
            assignment.AS02_CountNumber(numbers);

            string output = AssignmentDebugConsole.GetOutput();

            // Verify all expected number counts are present (allowing flexible order)
            string[] expectedLines = expectedPattern.Split('\n');
            foreach (string expectedLine in expectedLines)
            {
                Assert.IsTrue(output.Contains(expectedLine),
                    $"Expected output to contain: {expectedLine}\nActual output: {output}");
            }
        }

        [Category("Assignment")]
        [TestCase("()", "Valid", TestName = "AS03_CheckValidBrackets_SimpleValid - ()", Description = "Simple valid parentheses")]
        [TestCase("([])", "Valid", TestName = "AS03_CheckValidBrackets_NestedValid - ([])", Description = "Nested valid brackets")]
        [TestCase("([{}])", "Valid", TestName = "AS03_CheckValidBrackets_AllTypesValid - ([{}])", Description = "All bracket types nested validly")]
        [TestCase("(]", "Invalid", TestName = "AS03_CheckValidBrackets_MismatchedTypes - (]", Description = "Mismatched bracket types")]
        [TestCase("(()", "Invalid", TestName = "AS03_CheckValidBrackets_UnclosedParens - (()", Description = "Unclosed parentheses")]
        [TestCase("())", "Invalid", TestName = "AS03_CheckValidBrackets_ExtraClosing - ())", Description = "Extra closing bracket")]
        [TestCase("", "Valid", TestName = "AS03_CheckValidBrackets_Empty", Description = "Empty string should be valid")]
        [TestCase("abc(def)ghi", "Valid", TestName = "AS03_CheckValidBrackets_WithText - abc(def)ghi", Description = "Valid brackets with surrounding text")]
        [TestCase("{[()]}", "Valid", TestName = "AS03_CheckValidBrackets_ComplexNested - {[()]}", Description = "Complex nested valid brackets")]
        [TestCase("{[(])}", "Invalid", TestName = "AS03_CheckValidBrackets_ComplexInvalid - {[(])}", Description = "Complex nested invalid brackets")]
        public void Test_AS03_CheckValidBrackets_AllCases(string input, string expected)
        {
            assignment.AS03_CheckValidBrackets(input);

            string output = AssignmentDebugConsole.GetOutput();
            TestUtils.AssertMultilineEqual(expected, output, $"Bracket validation result should be '{expected}'");
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS04_PrintReverseLinkedList_BasicScenario()
        {
            LinkedList<int> list = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 });
            assignment.AS04_PrintReverseLinkedList(list);

            string output = AssignmentDebugConsole.GetOutput();
            string expected = "5\n4\n3\n2\n1";

            TestUtils.AssertMultilineEqual(expected, output, "Reversed linked list output should match expected order");
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS04_PrintReverseLinkedList_SingleElement()
        {
            LinkedList<int> list = new(new int[] { 42 });
            assignment.AS04_PrintReverseLinkedList(list);

            string output = AssignmentDebugConsole.GetOutput();
            string expected = "42";

            TestUtils.AssertMultilineEqual(expected, output, "Single element should be output correctly");
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS04_PrintReverseLinkedList_EmptyList()
        {
            LinkedList<int> list = new();
            assignment.AS04_PrintReverseLinkedList(list);

            string output = AssignmentDebugConsole.GetOutput();
            string expected = "List is empty";

            TestUtils.AssertMultilineEqual(expected, output, "Empty list should produce no output");
        }

        [Category("Assignment")]
        [TestCase(new string[] { "A" }, "A", TestName = "AS05_FindMiddleElement_Single", Description = "Single element")]
        [TestCase(new string[] { "A", "B" }, "B", TestName = "AS05_FindMiddleElement_Two", Description = "Two elements - should return second")]
        [TestCase(new string[] { "A", "B", "C" }, "B", TestName = "AS05_FindMiddleElement_Three", Description = "Three elements - should return middle")]
        [TestCase(new string[] { "A", "B", "C", "D" }, "C", TestName = "AS05_FindMiddleElement_Four", Description = "Four elements - should return third")]
        [TestCase(new string[] { "A", "B", "C", "D", "E" }, "C", TestName = "AS05_FindMiddleElement_Five", Description = "Five elements - should return middle")]
        public void Test_AS05_FindMiddleElement_AllCases(string[] elements, string expected)
        {
            LinkedList<string> list = new LinkedList<string>(elements);
            assignment.AS05_FindMiddleElement(list);

            string output = AssignmentDebugConsole.GetOutput();
            TestUtils.AssertMultilineEqual(expected, output, $"Middle element should be '{expected}'");
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS05_FindMiddleElement_EmptyList()
        {
            LinkedList<string> list = new LinkedList<string>();
            assignment.AS05_FindMiddleElement(list);

            string output = AssignmentDebugConsole.GetOutput();
            TestUtils.AssertMultilineEqual("List is empty", output, "Empty list should output 'List is empty'");
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS06_MergeDictionaries_BasicScenario()
        {
            Dictionary<string, int> dict1 = new Dictionary<string, int>
            {
                {"apple", 3},
                {"banana", 2}
            };

            Dictionary<string, int> dict2 = new Dictionary<string, int>
            {
                {"apple", 1},
                {"cherry", 4}
            };

            assignment.AS06_MergeDictionaries(dict1, dict2);

            string output = AssignmentDebugConsole.GetOutput();

            Assert.IsTrue(output.Contains("key: apple, value: 4"));
            Assert.IsTrue(output.Contains("key: banana, value: 2"));
            Assert.IsTrue(output.Contains("key: cherry, value: 4"));
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS06_MergeDictionaries_NoOverlap()
        {
            Dictionary<string, int> dict1 = new Dictionary<string, int>
            {
                {"a", 1},
                {"b", 2}
            };

            Dictionary<string, int> dict2 = new Dictionary<string, int>
            {
                {"c", 3},
                {"d", 4}
            };

            assignment.AS06_MergeDictionaries(dict1, dict2);

            string output = AssignmentDebugConsole.GetOutput();

            Assert.IsTrue(output.Contains("key: a, value: 1"));
            Assert.IsTrue(output.Contains("key: b, value: 2"));
            Assert.IsTrue(output.Contains("key: c, value: 3"));
            Assert.IsTrue(output.Contains("key: d, value: 4"));
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS07_RemoveDuplicatesFromLinkedList_BasicScenario()
        {
            LinkedList<int> list = new LinkedList<int>(new int[] { 1, 2, 2, 3, 3, 3, 4 });
            assignment.AS07_RemoveDuplicatesFromLinkedList(list);

            string output = AssignmentDebugConsole.GetOutput();
            string expected = "1\n2\n3\n4";

            TestUtils.AssertMultilineEqual(expected, output, "Duplicates should be removed, keeping only first occurrence");
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS07_RemoveDuplicatesFromLinkedList_AllSame()
        {
            LinkedList<int> list = new LinkedList<int>(new int[] { 5, 5, 5, 5 });
            assignment.AS07_RemoveDuplicatesFromLinkedList(list);

            string output = AssignmentDebugConsole.GetOutput();
            string expected = "5";

            TestUtils.AssertMultilineEqual(expected, output, "All same elements should result in single output");
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS07_RemoveDuplicatesFromLinkedList_NoDuplicates()
        {
            LinkedList<int> list = new LinkedList<int>(new int[] { 1, 2, 3, 4 });
            assignment.AS07_RemoveDuplicatesFromLinkedList(list);

            string output = AssignmentDebugConsole.GetOutput();
            string expected = "1\n2\n3\n4";

            TestUtils.AssertMultilineEqual(expected, output, "List with no duplicates should remain unchanged");
        }

        [Category("Assignment")]
        [TestCase(new int[] { 1, 2, 3, 2, 2, 1 }, "2 count: 3", TestName = "AS08_TopFrequentNumber_BasicScenario -  1, 2, 3, 2, 2, 1", Description = "Most frequent number in mixed array")]
        [TestCase(new int[] { 5, 5, 5, 5 }, "5 count: 4", TestName = "AS09_TopFrequentNumber_AllSame - 5, 5, 5, 5", Description = "All numbers are the same")]
        [TestCase(new int[] { 10 }, "10 count: 1", TestName = "AS09_TopFrequentNumber_SingleNumber - 10", Description = "Single number in array")]
        [TestCase(new int[] { 1, 2, 3, 4 }, "1 count: 1", TestName = "AS09_TopFrequentNumber_AllUnique - 1, 2, 3, 4", Description = "All numbers unique - should return first")]
        [TestCase(new int[] { -1, -1, 0, 1 }, "-1 count: 2", TestName = "AS09_TopFrequentNumber_WithNegatives - -1, -1, 0, 1", Description = "Include negative numbers")]
        public void Test_AS08_TopFrequentNumber_AllCases(int[] numbers, string expected)
        {
            assignment.AS08_TopFrequentNumber(numbers);

            string output = AssignmentDebugConsole.GetOutput();
            TestUtils.AssertMultilineEqual(expected, output, $"Top frequent number result should be '{expected}'");
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS08_TopFrequentNumber_EmptyArray()
        {
            assignment.AS08_TopFrequentNumber(new int[] { });

            string output = AssignmentDebugConsole.GetOutput();
            TestUtils.AssertMultilineEqual("Input array is empty", output, "Empty array should output 'Input array is empty'");
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS09_PlayerInventory_AddNewItem()
        {
            Dictionary<string, int> inventory = new()
            {
                {"sword", 1},
                {"potion", 5}
            };

            assignment.AS09_PlayerInventory(inventory, "shield", 2);

            string output = AssignmentDebugConsole.GetOutput();

            Assert.IsTrue(output.Contains("sword: 1"));
            Assert.IsTrue(output.Contains("potion: 5"));
            Assert.IsTrue(output.Contains("shield: 2"));
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS09_PlayerInventory_AddExistingItem()
        {
            Dictionary<string, int> inventory = new()
            {
                {"sword", 1},
                {"potion", 5}
            };

            assignment.AS09_PlayerInventory(inventory, "potion", 3);

            string output = AssignmentDebugConsole.GetOutput();

            Assert.IsTrue(output.Contains("sword: 1"));
            Assert.IsTrue(output.Contains("potion: 8"));
        }

        [Category("Assignment")]
        [Test]
        public void Test_AS09_PlayerInventory_NullInventory()
        {
            assignment.AS09_PlayerInventory(null, "item", 1);

            string output = AssignmentDebugConsole.GetOutput();
            TestUtils.AssertMultilineEqual("Inventory is null", output, "Null inventory should output 'Inventory is null'");
        }

        [Category("Extra")]
        [Test]
        public void Test_EX01_GameEventQueue_ProcessEvents()
        {
            LinkedList<GameEvent> eventQueue = new();
            eventQueue.AddLast(new GameEvent("enemy", "Goblin appeared"));
            eventQueue.AddLast(new GameEvent("powerup", "Health boost found"));
            eventQueue.AddLast(new GameEvent("level", "Reached level 2"));

            assignment.EX01_GameEventQueue(eventQueue);

            string output = AssignmentDebugConsole.GetOutput();
            string expected = "Processing event: Goblin appeared\n" +
                            "Remaining events in queue: 2\n" +
                            "Enemy event processed - Goblin appeared\n" +
                            "Processing event: Health boost found\n" +
                            "Remaining events in queue: 1\n" +
                            "Power-up event processed - Health boost found\n" +
                            "Processing event: Reached level 2\n" +
                            "Remaining events in queue: 0\n" +
                            "Level event processed - Reached level 2";

            TestUtils.AssertMultilineEqual(expected, output, "Game event queue should process events in correct order with proper messaging");
        }

        [Category("Extra")]
        [Test]
        public void Test_EX01_GameEventQueue_EmptyQueue()
        {
            LinkedList<GameEvent> eventQueue = new LinkedList<GameEvent>();

            assignment.EX01_GameEventQueue(eventQueue);

            string output = AssignmentDebugConsole.GetOutput();
            TestUtils.AssertMultilineEqual("Event queue is empty", output, "Empty queue should output 'Event queue is empty'");
        }

        [Category("Extra")]
        [Test]
        public void Test_EX01_GameEventQueue_NullQueue()
        {
            assignment.EX01_GameEventQueue(null);

            string output = AssignmentDebugConsole.GetOutput();
            TestUtils.AssertMultilineEqual("Event queue is empty", output, "Null queue should output 'Event queue is empty'");
        }

        [Category("Extra")]
        [Test]
        public void Test_EX01_GameEventQueue_DifferentEventTypes()
        {
            LinkedList<GameEvent> eventQueue = new LinkedList<GameEvent>();
            eventQueue.AddLast(new GameEvent("achievement", "First kill"));
            eventQueue.AddLast(new GameEvent("unknown", "Mystery event"));

            assignment.EX01_GameEventQueue(eventQueue);

            string output = AssignmentDebugConsole.GetOutput();
            string expected = "Processing event: First kill\n" +
                            "Remaining events in queue: 1\n" +
                            "Achievement unlocked - First kill\n" +
                            "Processing event: Mystery event\n" +
                            "Remaining events in queue: 0\n" +
                            "Generic event processed - Mystery event";

            TestUtils.AssertMultilineEqual(expected, output, "Game event queue should handle different event types correctly");
        }

        [Category("Extra")]
        [Test]
        public void Test_EX02_PlayerStatsTracker_AddNewStat()
        {
            Dictionary<string, int> playerStats = new Dictionary<string, int>
            {
                {"kills", 10},
                {"deaths", 2}
            };

            assignment.EX02_PlayerStatsTracker(playerStats, "assists", 5);

            string output = AssignmentDebugConsole.GetOutput();

            Assert.IsTrue(output.Contains("Updated assists: 5"));
            Assert.IsTrue(output.Contains("Current player statistics:"));
            Assert.IsTrue(output.Contains("kills: 10"));
            Assert.IsTrue(output.Contains("deaths: 2"));
            Assert.IsTrue(output.Contains("assists: 5"));
        }

        [Category("Extra")]
        [Test]
        public void Test_EX02_PlayerStatsTracker_UpdateExistingStat()
        {
            Dictionary<string, int> playerStats = new Dictionary<string, int>
            {
                {"kills", 10},
                {"deaths", 2}
            };

            assignment.EX02_PlayerStatsTracker(playerStats, "kills", 3);

            string output = AssignmentDebugConsole.GetOutput();

            Assert.IsTrue(output.Contains("Updated kills: 13"));
            Assert.IsTrue(output.Contains("Current player statistics:"));
            Assert.IsTrue(output.Contains("kills: 13"));
            Assert.IsTrue(output.Contains("deaths: 2"));
        }

        #endregion
    }

    public class TestUtils
    {
        internal static void AssertMultilineEqual(string expected, string actual, string message = null)
        {
            string normExpected = expected.Replace("\r\n", "\n").Replace("\r", "\n").Trim();
            string normActual = actual.Replace("\r\n", "\n").Replace("\r", "\n").Trim();
            if (string.IsNullOrEmpty(message))
            {
                message = $"Expected output:\n{normExpected}\n----\nActual output:\n{normActual}";
            }
            Assert.AreEqual(normExpected, normActual, message);
        }
    }
}
