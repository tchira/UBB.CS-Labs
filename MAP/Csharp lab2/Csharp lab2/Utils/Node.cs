using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_lab2.Utils
{
    [Serializable]
    class Node<T>
    {
        public T info;
        public Node<T> next;

        public Node(T info)
        {
            this.info = info;
            this.next = null;
        }
    }
}
