using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BidirectionalList
{
    public class ListNode
    {
        public ListNode Previous;
        public ListNode Next;
        public ListNode Random; // произвольный элемент внутри списка
        public string Data;
    }

    public class ListRandom
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public void Serialize(Stream s)
        {
            try
            {
                ListNode n1 = Head;
                List<ListNode> _list = new List<ListNode>();

                for (int i = 0; i < Count; i++) {
                    _list.Add(n1);
                    n1 = n1.Next;
                }

                using (BinaryWriter bw = new BinaryWriter(s))
                {
                    ListNode n = Head;
                    while (n != null)
                    {
                        byte[] b = Encoding.ASCII.GetBytes(n.Data);

                        bw.Write(b);
                        bw.Write((byte)0);
                        bw.Write(_list.IndexOf(n.Random));
                        n = n.Next;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Deserialize(Stream s)
        {
            try
            {
                List<ListNode> _list = new List<ListNode>();
                List<int> _randomIndexes = new List<int>();
                ListNode n, prev = null;
                Count = 0;
                string str = "";
                int stage = 0;

                using (BinaryReader bw = new BinaryReader(s))
                {
                    while (bw.BaseStream.Position != bw.BaseStream.Length)
                    {
                        switch (stage)
                        {
                            case 0:
                                byte b = bw.ReadByte();
                                if (b == 0x00)
                                    stage = 1;
                                else
                                    str += (char)b;
                                break;
                            case 1:
                                int i = bw.ReadInt32();
                                n = new ListNode();
                                n.Data = str;

                                if (Count == 0)
                                {
                                    Head = n;
                                    prev = n;
                                }
                                else
                                {
                                    n.Previous = prev;
                                    prev.Next = n;
                                    prev = n;
                                }
                                Count++;
                                str = "";
                                stage = 0;

                                _randomIndexes.Add(i);
                                _list.Add(n);

                                break;
                        }
                    }
                }

                for (int i = 0; i < _list.Count; i++)
                {
                    _list[i].Random = _list[_randomIndexes[i]];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public static ListRandom GenerateRandomList()
        {
            Random rnd = new Random();
            ListNode head, temp, prev = null;
            int len = rnd.Next(3, 15);
            List<ListNode> _list = new List<ListNode>();

            head = new ListNode() { Data = "N1" };

            var r = new ListRandom();

            for (int i = 1; i < len; i++)
            {
                temp = new ListNode();

                if (i == 1)
                {
                    head.Next = temp;
                    temp.Previous = head;
                }
                else
                {
                    temp.Previous = prev;
                    prev.Next = temp;
                }

                temp.Data = $"N{i + 1}";
                prev = temp;
            }

            temp = head;

            for (int i = 0; i < len; i++)
            {
                _list.Add(temp);
                temp = temp.Next;
            }

            for (int i = 0; i < len; i++)
            {
                int randomIndex = rnd.Next(1, len + 1);
                _list[i].Random = _list[randomIndex - 1];
            }

            r.Head = head;
            r.Tail = prev;
            r.Count = len;

            return r;
        }
    }
}
