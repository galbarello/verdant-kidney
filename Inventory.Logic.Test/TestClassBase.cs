using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Logic.Test
{
    public class TestClassBase<T> where T : class
    {
        #region Properties

        public T Target { get; set; }

        #endregion

        #region Methods

        public virtual void Initialize()
        {

        }

        #endregion
    }
}
