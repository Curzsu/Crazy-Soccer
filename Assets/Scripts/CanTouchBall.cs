/// <summary>
/// 防守阵营的踢球策略;
/// </summary>

using System;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace FootBallAI
{
    public class CanTouchBall : Conditional
    {
        /// <summary>
        /// 守门员脚本;
        /// </summary>
        private Agent mAgent;
        /// <summary>
        /// 足球脚本;
        /// </summary>
        private Ball Ball;
        /// <summary>
        /// 球的位置;
        /// </summary>
        private Vector3 ballLocation;
        /// <summary>
        /// 球员的位置;
        /// </summary>
        private Vector3 agentLocation;

        public override void OnStart()
        {
            //获取球员脚本;
            mAgent = GetComponent<Agent>();
            //获取足球脚本;
            Ball = mAgent.GetBall().GetComponent<Ball>();
        }

        public override TaskStatus OnUpdate()
        {
            //获取足球位置;
            ballLocation = mAgent.GetBallLocation();
            //获取球员位置;
            agentLocation = mAgent.transform.position;
            //判断能否踢球;
            if (Math.Abs(ballLocation.x - agentLocation.x) < 3) //位置在一个地方
            {
                return TaskStatus.Success;
            }
            return TaskStatus.Failure;
        }
    }
}     

