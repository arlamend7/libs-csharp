using System;
using System.Collections.Generic;

namespace Linq.Fluent.Tests.Base
{
    public abstract class BaseDataTests
    {
        protected readonly List<int?> listInt;
        protected readonly List<long?> listLong;
        protected readonly List<DateTime?> listDateTime;
        protected readonly List<string> listString;
        protected readonly List<ComplexClass> listComplex;

        protected readonly ComplexClass firstComplexClass;
        protected readonly ComplexClass secondComplexClass;

        public BaseDataTests()
        {
            listInt = new List<int?>() { null, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            listLong = new List<long?>() { null, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            listDateTime = new List<DateTime?>() { null, DateTime.Now, DateTime.MinValue, DateTime.MaxValue };
            listString = new List<string>() { null, "", " ", "test", "someone" };

            firstComplexClass = new ComplexClass() { listInt = new List<int>(), DateTime = null, Int = null, Long = null, listComplex = new List<ComplexClass>(), String = null, Boolean = false };
            secondComplexClass = new ComplexClass() { listInt = new List<int>() { 1 }, DateTime = DateTime.Now, Int = 1, Long = 1, String = "test", listComplex = new List<ComplexClass>() { firstComplexClass } };
            listComplex = new List<ComplexClass>() { null, firstComplexClass, secondComplexClass };
        }
    }
}
