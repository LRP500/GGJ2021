using UnityEngine;

namespace GGJ2021
{
    public abstract class Action : ScriptableObject
    {
        public virtual void Execute() { }
    }

    public abstract class Action<T> : Action
    {
        public virtual void Execute(T parameter) => base.Execute();
    }
}
