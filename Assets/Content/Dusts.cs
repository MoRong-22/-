using System;
using AboutDamage;
using Content.IHelper;
using UnityEngine;

namespace Content
{
    public abstract class Dusts :LifeCycle
    {
        
        public override void Update(){}

        public override void FixedUpdate(){}

        public override bool PreDraw() => true;

        public override void Draw(){}

        public virtual void SetDefault(Vector3 position, Quaternion rotation,
            Vector3 velocity, float speed)
        {
            this.Center = position;
            this.Rotation = rotation;
            this.Velocity = velocity;
            this.Speed = speed;
        }
        /// <summary>
        /// 生成粒子列表
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="velocity"></param>
        /// <param name="speed"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Func<T> NewDust<T>(Vector3 position, Quaternion rotation,
            Vector3 velocity, float speed) where T : Dusts
        {
            GameObject obj = new(typeof(T).Name);
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            T dusts = obj.AddComponent<T>();
            dusts.SetDefault(position, rotation, velocity, speed);
            Game.instance.Dusts.Add(dusts);
            return ()=>dusts;
        }
    }
}