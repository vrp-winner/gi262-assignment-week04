using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Solution
{
    public class ZombieParade : Character
    {
        // �� LinkedList 㹡�èѴ�����ǹ�ͧ�����ͻ���Է���Ҿ㹡������/ź
        private LinkedList<GameObject> Parade = new LinkedList<GameObject>();

        public GameObject bodyPrefab; // Prefab �ͧ��ǹ�ӵ�ǧ�
        public float moveInterval = 0.5f; // ��ǧ����㹡������͹��� (0.5 �Թҷ�)

        private Vector3 moveDirection;

        private void Start()
        {
           
            moveDirection = Vector3.up;
            isAlive = true;
            // ����� Coroutine ����Ѻ�������͹���
            StartCoroutine(MoveParade());

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Grow();
            }
        }
        private Vector3 RandomizeDirection()
        {
            List<Vector3> possibleDirections = new List<Vector3>
            {
                Vector3.up,
                Vector3.down,
                Vector3.left,
                Vector3.right
            };

            return possibleDirections[Random.Range(0, possibleDirections.Count)];
        }
        // Coroutine ����Ѻ�������͹�����Ъ�ͧ
        IEnumerator MoveParade()
        {
            //0. ���ҧ��ǧ�
            Parade.AddFirst(this.gameObject);

            while (isAlive)
            {
                // 1. �֧��ǹ�á�ͧ���͡��
                var firstNode = Parade.First;
                var firstPart = firstNode.Value;

                // 2. �֧��ǹ�ش���¢ͧ���͡��
                var lastNode = Parade.Last;
                var lastPart = lastNode.Value;
             
                // 3. ź��ǹ�ش�����͡�ҡ LinkedList
                Parade.RemoveLast();

                // 5. ��˹����˹���з�ȷҧ�ͧ��ǹ���١����������
                // ������������˹觢ͧ��ǹ��ǧ� (����������͹��������ͤ���)
                bool isCollide = true;
                while (isCollide)
                {
                    var moveDir = RandomizeDirection();
                    int toX = (int)(firstPart.transform.position.x + moveDir.x);
                    int toY = (int)(firstPart.transform.position.y + moveDir.y);
                    
                    isCollide = IsCollision(toX, toY);
                    
                    positionX = toX;
                    positionY = toY;
                }

                lastPart.transform.position = new Vector3 (positionX, positionY, 0);
   
                //6. ����͹���

                // 7. ������ǹ��鹡�Ѻ��������ǹ����ͧ�ͧ LinkedList
                // (��觡�����ǹ�á�ͧ�ӵ��)
                Parade.AddFirst(lastNode);

                // �͵�����ҷ���˹���͹�������͹�����駵���
                yield return new WaitForSeconds(moveInterval);
            }
        }
        private bool IsCollision(int x, int y)
        {
            // 4. ��Ǩ�ͺ��觡մ��ҧ
            if (HasPlacement(x, y))
            {
                return true;
            }
            return false;
        }
        void Move(Vector2 direction,GameObject targetMove)
        {
            int toX = (int)direction.x;
            int toY = (int)direction.y;
            Debug.Log("Move to: " + toX + "," + toY);
        }
        

        // �ѧ��ѹ����Ѻ������ǹ�ͧ�� (Grow)
        private void Grow()
        {
            GameObject newPart = Instantiate(bodyPrefab);
            // ��˹����˹�������鹢ͧ��ǹ����������������ǡѺ��ǹ�ش���¢ͧ��
            GameObject lastPart = Parade.Last.Value;
            newPart.transform.position = lastPart.transform.position;
            //newPart.transform.rotation = lastPart.transform.rotation;
            // ������ǹ��������� Linked List
            Parade.AddLast(newPart);
        }

    }
}
