using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Course.zad03
{
    class Queue : ArrayList
    {
        public void Enqueue(Object value) { base.Add(value); }
        public Object Dequeue()
        {
            if (base.Count == 0)
                return null;
            Object obj = base[0];
            base.RemoveAt(0);
            return obj;
        }
    }
    class QueueComposition
    {
        ArrayList _queue = [];

        public void Enqueue(Object value)
        {
            _queue.Add(value);
        }
        public Object Dequeue()
        {
            if (_queue.Count == 0)
                return null;
            Object obj = _queue[0];
            _queue.RemoveAt(0);
            return obj;
        }
    }
}
