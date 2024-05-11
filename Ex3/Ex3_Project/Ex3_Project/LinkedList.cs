using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class LinkedList
    {
        private Node head;
        private Node tail;
        private Node maxNode;
        private Node minNode;

        public LinkedList() 
        {
            tail = null;
            head = null;
            maxNode = null;
            minNode = null;
        }

        public void Append(int value)
        {
            Node newNode = new Node(value, null);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                maxNode = newNode;
                minNode = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = tail.Next;
                UpdateMinMax(newNode);  
            }
        }

        private void UpdateMinMax(Node newNode)
        {
            if (newNode.Value > maxNode.Value)
                maxNode = newNode;
            if (newNode.Value < minNode.Value)
                minNode = newNode;
        }

        public void Prepend(int value)
        {
            Node newNode = new Node(value, head);
            head = newNode;
            if (tail == null)
                tail = newNode;
            UpdateMinMax(newNode) ;

        }

        public int Pop()
        {
            return tail.Value;
        }
        public int Unqueue() 
        {
            int head_value = head.Value;
            head = head.Next;
            return head_value;
        }

        public bool IsCircular()
        {
            return tail.Next == head;
        }
        public IEnumerable<int> ToList()
        {
            List<int> list = new List<int>();
            Node current = head;
            while (current != null)
            {
                list.Add(current.Value);
                current = current.Next;
            }
            return list;
        }
        public void Sort()
        {
            IEnumerable<int> numbers = ToList();
            List<int> numbers_list = numbers.ToList();
            numbers_list.Sort();

            Node current = head;
            foreach (int value in numbers_list)
            {
                current.Value = value;
                current = current.Next;
            }

        }

        public Node GetMaxNode()
        {
            return maxNode;
        }

        public Node GetMinNode()
        {
            return minNode;
        }

    }
}
