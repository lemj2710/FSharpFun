using System;

namespace Util
{
    public interface Option<TypeValue>
    {
        TResult Match<TResult>(Func<TypeValue, TResult> some, Func<TResult> none);
    }

    public class Some<TypeValue> : Option<TypeValue>
    {
        private readonly TypeValue _value;
        
        public Some(TypeValue value)
        {
            _value = value;
        }

        public TResult Match<TResult>(Func<TypeValue, TResult> some, Func<TResult> none) => some(_value);
    }

    public class None<TypeValue> : Option<TypeValue>
    {
        public TResult Match<TResult>(Func<TypeValue, TResult> some, Func<TResult> none) => none();        
    }
}