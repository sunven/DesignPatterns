﻿using System;

namespace DesignPatterns.Structure
{
    /// <summary>
    /// 百度地图
    /// </summary>
    public interface IBaiduMap
    {
        void Gen();
    }

    /// <summary>
    /// 两个孔的插头，源角色——需要适配的类
    /// </summary>
    public abstract class GoogleMap
    {
        public void Build()
        {
            Console.WriteLine("goole map build");
        }
    }

    /// <summary>
    /// 适配器类
    /// 适配器类提供了百度地图生成方法，但实际提供了google地图的生成方法
    /// </summary>
    public class BaiduAdapter : GoogleMap, IBaiduMap
    {
        public void Gen()
        {
            Build();
        }
    }

    /// <summary>
    /// 百度地图
    /// </summary>
    public class BaiduMap1
    {
        public virtual void Gen()
        {
            Console.WriteLine("baidu map gen");
        }
    }

    /// <summary>
    /// google map
    /// </summary>
    public class GoogleMap1
    {
        public void Build()
        {
            Console.WriteLine("goole map build");
        }
    }

    /// <summary>
    /// 适配器类，这里适配器类没有TwoHole类，
    /// 而是引用了TwoHole对象，所以是对象的适配器模式的实现
    /// </summary>
    public class BaiduAdapter1 : BaiduMap1
    {
        public GoogleMap1 GoogleMap1 = new GoogleMap1();

        /// <summary>
        /// 实现三个孔插头接口方法
        /// </summary>
        public override void Gen()
        {
            GoogleMap1.Build();
        }
    }
}