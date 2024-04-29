namespace Wcng
{
    public interface IPhysicObject
    {
        abstract bool OnEntityHurt(float health,bool isHit = false);

        void OnEntityDestroy();
    }
}