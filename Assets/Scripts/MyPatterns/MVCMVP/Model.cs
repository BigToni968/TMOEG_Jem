using UnityEngine;
using System;

namespace Patterns
{
    public interface IModel
    {
        public void OnInit(IModel model);
        public IModel Copy();
    }
    public interface IModel<T> : IModel
    {
        public T ReadData { get; }
        public void Set(T data);
    }

    [Serializable]
    public abstract class Model<T> : IModel
    {
        public T ReadData => Data;
        public T Data;

        public virtual void OnInit(IModel model)
        {
            Data = (model as Model<T>).Data;
        }
        public virtual void Set(T data)
        {
            Data = data;
        }
        public virtual IModel Copy()
        {
            return MemberwiseClone() as IModel;
        }
    }
}