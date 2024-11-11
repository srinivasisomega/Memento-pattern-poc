using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento_pattern_poc
{
    public class CartHistory
    {
        private Stack<CartMemento> _history = new Stack<CartMemento>();

        public void Save(CartMemento memento)
        {
            _history.Push(memento);
        }

        public CartMemento Restore()
        {
            return _history.Count > 0 ? _history.Pop() : null;
        }
    }


}
