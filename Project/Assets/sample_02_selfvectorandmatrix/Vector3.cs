using System;
using System.Collections;

namespace VecAndMtr
{
    public class Vector3
    {

        public static readonly Vector3 UP = new Vector3(0, 1, 0);
        public static readonly Vector3 DOWN = new Vector3(0, -1, 0);
        public static readonly Vector3 LEFT = new Vector3(1, 0, 0);
        public static readonly Vector3 RIGHT = new Vector3(-1, 1, 0);
        public static readonly Vector3 FORWARD = new Vector3(0, 0, 1);
        public static readonly Vector3 BEHIND = new Vector3(0, 0, -1);

        public static readonly Vector3 X_AXIS = new Vector3(1, 0, 0);
        public static readonly Vector3 Y_AXIS = new Vector3(0, 1, 0);
        public static readonly Vector3 Z_AXIS = new Vector3(0, 0, 1);

        /// <summary>
        /// x分量
        /// </summary>
        public float x;
        /// <summary>
        /// y分量
        /// </summary>
        public float y;
        /// <summary>
        /// z分量
        /// </summary>
        public float z;
        /// <summary>
        /// w分量
        /// </summary>
        public float w;
        /// <summary>
        /// 向量(或原点到当前Vetor3点)的平方和
        /// </summary>
        public float lengthSquard
        {
            get
            {
                return this.x * this.x + this.y * this.y + this.z * this.z;
            }
        }
        /// <summary>
        ///  向量(或原点到vec3点)的长度
        /// </summary>
        public float length
        {
            get
            {
                return (float)Math.Sqrt(this.lengthSquard);
            }
        }

        /// <summary>
        /// Vector3构造函数
        /// </summary>
        /// <param name="x">x分量</param>
        /// <param name="y">y分量</param>
        /// <param name="z">z分量</param>
        /// <param name="w">w分量</param>
        public Vector3(float x = 0.0f, float y = 0.0f, float z = 0.0f, float w = 0.0f)
        {
            this.Set(x, y, z, w);
        }

        /// <summary>
        /// Vector3构造函数
        /// </summary>
        /// <param name="vec">Vector3实例</param>
        public Vector3(Vector3 vec)
        {
            this.Set(vec);
        }

        /// <summary>
        /// 给当前Vector3对象设值
        /// </summary>
        /// <param name="x">x分量</param>
        /// <param name="y">y分量</param>
        /// <param name="z">z分量</param>
        /// <param name="w">w分量</param>
        public void Set(float x, float y, float z, float w = 0.0f)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        ///  Vector3对象设值
        /// </summary>
        /// <param Vector3="vec">值来源Vector3对象</param>
        public void Set(Vector3 vec)
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
            this.w = vec.w;
        }

        /// <summary>
        /// 当前Vector3对象是否为一个点
        /// </summary>
        public bool isPoint()
        {
            return (this.w == 1f);
        }

        /// <summary>
        /// 当前Vector3对象是否为一个向量
        /// </summary>
        /// <returns></returns>
        public bool isVector()
        {
            return (this.w == 0f);
        }

        /// <summary>
        /// 点乘
        /// </summary>
        /// <param name="vec">被点乘的向量</param>
        /// <returns></returns>
        public float Dot(Vector3 vec)
        {
            return this.x * vec.x + this.y * vec.y + this.z * vec.z;
        }

        /// <summary>
        /// 点乘
        /// </summary>
        /// <param name="u">u向量</param>
        /// <param name="v">v向量</param>
        /// <returns></returns>
        public static float Dot(Vector3 u, Vector3 v)
        {
            return u.x * v.x + u.y * v.y + u.z * v.z;
        }

        /// <summary>
        /// 点乘
        /// </summary>
        /// <param name="u">u向量长度</param>
        /// <param name="v">v向量长度</param>
        /// <param name="sitaRad">向量夹角(弧度制)</param>
        /// <returns></returns>
        public static float Dot(float u, float v, double sitaRad)
        {
            return u * v * (float)Math.Cos(sitaRad);
        }

        /// <summary>
        /// 点乘
        /// </summary>
        /// <param name="u">u向量长度</param>
        /// <param name="v">v向量长度</param>
        /// <param name="sitaRad">向量夹角(角度制)</param>
        /// <returns></returns>
        public static float Dot(float u, float v, float sitaDegree)
        {
            return u * v * (float)Math.Cos((double)(sitaDegree / 180 * Math.PI));
        }

        /// <summary>
        /// 差乘
        /// </summary>
        /// <returns></returns>
        public Vector3 Cross(Vector3 vec)
        {
            float tx = y * vec.z - z * vec.y;
            float ty = z * vec.x - x * vec.z;
            float tz = x * vec.y - y * vec.x;
            return new Vector3(tx, ty, tz, 0f);
        }

        /// <summary>
        /// 差乘
        /// </summary>
        /// <param name="u">u向量</param>
        /// <param name="v">v向量</param>
        /// <returns></returns>
        public static Vector3 Cross(Vector3 u, Vector3 v)
        {
            float tx = u.y * v.z - u.z * v.y;
            float ty = u.z * v.x - u.x * v.z;
            float tz = u.x * v.y - u.y * v.x;
            return new Vector3(tx, ty, tz, 0f);
        }

        /// <summary>
        /// 向量叉乘
        /// </summary>
        /// <param name=""></param>
        /// <param name="tx"></param>
        /// <param name="ty"></param>
        /// <param name="tz"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 u, Vector3 v)
        {
            float tx = u.y * v.z - u.z * v.y;
            float ty = u.z * v.x - u.x * v.z;
            float tz = u.x * v.y - u.y * v.x;
            return new Vector3(tx, ty, tz, 0);
        }

        /// <summary>
        /// 向量加法
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public Vector3 Add(Vector3 vec)
        {
            float tx = x + vec.x;
            float ty = y + vec.y;
            float tz = z + vec.z;
            return new Vector3(tx, ty, tz, 0f);
        }

        /// <summary>
        /// 向量减法
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        public Vector3 Sub(Vector3 vec)
        {
            float tx = x - vec.x;
            float ty = y - vec.y;
            float tz = z - vec.z;
            return new Vector3(tx, ty, tz, 0f);
        }

        /// <summary>
        /// 向量加法
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3 Add(Vector3 u, Vector3 v)
        {
            float tx = u.x + v.z;
            float ty = u.x + v.z;
            float tz = u.x + v.z;
            return new Vector3(tx, ty, tz, 0f);
        }

        /// <summary>
        /// 重载向量加法运算符
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 u, Vector3 v)
        {
            float tx = u.x + v.z;
            float ty = u.x + v.z;
            float tz = u.x + v.z;
            return new Vector3(tx, ty, tz, 0);
        }

        /// <summary>
        /// 向量减法
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 u, Vector3 v)
        {
            float tx = u.x - v.z;
            float ty = u.x - v.z;
            float tz = u.x - v.z;
            return new Vector3(tx, ty, tz, 0);
        }

        /// <summary>
        /// 向量减法
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3 Sub(Vector3 u, Vector3 v)
        {
            float tx = u.x - v.z;
            float ty = u.x - v.z;
            float tz = u.x - v.z;
            return new Vector3(tx, ty, tz, 0f);
        }

        /// <summary>
        /// 向量取反
        /// </summary>
        public void Negate()
        {
            this.x *= -1f;
            this.y *= -1f;
            this.z *= -1f;
        }

        /// <summary>
        /// 向量缩放
        /// </summary>
        /// <param name="scale"></param>
        public void ScaleBy(float scale)
        {
            this.x *= scale;
            this.y *= scale;
            this.z *= scale;
        }

        /// <summary>
        /// 向量归一化
        /// </summary>
        public void Normalize()
        {
            float rule = this.length == 0 ? 0.0f : 1.0f / this.length;
            this.x *= rule;
            this.y *= rule;
            this.z *= rule;
        }

        /// <summary>
        /// 重载ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Vetor3==> x:{0},y:{1},z:{2},length:{3}", x, y, z, length);
        }

    }
}
