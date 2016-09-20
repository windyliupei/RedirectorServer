using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.IOCP
{
    /// <summary>
    /// AsyncUserToken对象池（固定缓存设计）
    /// </summary>
    public class AsyncUserTokenPool
    {
        List<AsyncUserToken> _connectedToken = new List<AsyncUserToken>();
        public List<AsyncUserToken> ConnectedToken
        {
            get
            {
                return _connectedToken;
            }
        }

        Stack<AsyncUserToken> m_pool;

        // Initializes the object pool to the specified size
        //
        // The "capacity" parameter is the maximum number of 
        // AsyncUserToken objects the pool can hold
        public AsyncUserTokenPool(int capacity)
        {
            m_pool = new Stack<AsyncUserToken>(capacity);
        }

        // Add a SocketAsyncEventArg instance to the pool
        //
        //The "item" parameter is the AsyncUserToken instance 
        // to add to the pool
        public void Push(AsyncUserToken item)
        {
            if (item == null) { throw new ArgumentNullException("Items added to a SocketAsyncEventArgsPool cannot be null"); }
            lock (m_pool)
            {
                m_pool.Push(item);
            }
        }

        // Removes a AsyncUserToken instance from the pool
        // and returns the object removed from the pool
        public AsyncUserToken Pop()
        {
            lock (m_pool)
            {
                var token = m_pool.Pop();
                _connectedToken.Add(token);
                return token;
            }
        }

        // The number of AsyncUserToken instances in the pool
        public int Count
        {
            get { return m_pool.Count; }
        }

        internal AsyncUserToken GetTokenByMacId(string macId)
        {
            foreach (var item in _connectedToken)
            {
                if (item.MacId == macId)
                {
                    return item;
                }
            } 
            return null;
        }

        internal void RemoveToken(string macId)
        {
            var token = _connectedToken.FirstOrDefault(x => x.MacId == macId);
            if (_connectedToken.Contains(token))
            {
                _connectedToken.Remove(token);
            }
        }
    }
}
