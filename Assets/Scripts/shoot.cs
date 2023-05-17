/// <summary>
/// 防守阵营的踢球策略;
/// </summary>
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Basic.UnityGameObject;
using UnityEngine;

namespace FootBallAI
{
    public class shoot : Action
    {
        /// 球员脚本;
        private Agent mAgent;
        /// 足球脚本;
        private Ball Ball;
        
        /// 球的位置;
        private GameObject redpo;
        private Vector3 ballLocation;
        /// 球员的位置;
        private Vector3 agentLocation;
        private Vector3 doorLocation;

        public override void OnStart()
        {
            //获取球员脚本;
            mAgent = GetComponent<Agent>();
            Ball = mAgent.GetBall().GetComponent<Ball>();
            redpo = GameObject.FindGameObjectWithTag("t");
        }
        public override TaskStatus OnUpdate()
        {
            //获取足球位置;
            ballLocation = mAgent.GetBallLocation();
            //获取球员位置;
            agentLocation = mAgent.transform.position;
            doorLocation = redpo.transform.position;
            mAgent.transform.LookAt(doorLocation);
            //根据自己的阵营,给球一个力;
            Ball.AddForceBig(ballLocation, doorLocation);
            return TaskStatus.Success;
        }
    }
}     

