using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock.Extension
{
    public class FixedSizeList<T> : List<T>
    {
        public int Size { get; private set; }

        public FixedSizeList(int size)
        {
            Size = size;
        }

        public new void Add(T item)
        {
            base.Add( item );
            RemoveExtra();
        }

        public new void AddRange(IEnumerable<T> collection)
        {
            base.AddRange( collection );
            RemoveExtra();
        }

        private void RemoveExtra()
        {
            if ( this.Count > Size )
            {
                this.RemoveRange( 0, this.Count - Size );
            }
        }
    }
}
