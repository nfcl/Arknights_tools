﻿using System;
using System.Collections.Generic;
using System.Text;

namespace json_real
{
    /// <summary>
    /// 
    /// </summary>
    public class MakableItem
    {
        /// <summary>
        /// 材料名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 材料稀有度等级
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 材料数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 材料Uid名称用于和干员材料信息对接
        /// </summary>
        public int Uid { get; set; }
    }

    public class Matriels
    {
        public List<MakableItem> Makable { get; set; }
    }

    public class Matriels_Root
    {
        public Matriels Matriels { get; set; }
    }
    //-----------------------------------------------------------------------------------------------------------------------------------

    //-----------------------------------------------------------------------------------------------------------------------------------

    public class AttributesKeyFramesItem
    {
        /// <summary>
        /// 当前数值的等级
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 当前等级的数值信息
        /// </summary>
        public Data data { get; set; }
    }

    public class PhasesItem
    {
        /// <summary>
        /// 当前精英化的攻击范围
        /// </summary>
        public string rangeId { get; set; }
        /// <summary>
        /// 当前精英化的最大等级
        /// </summary>
        public int maxLevel { get; set; }
        /// <summary>
        /// 当前精英化的最小和最大等级的数值信息
        /// </summary>
        public List<AttributesKeyFramesItem> attributesKeyFrames { get; set; }
        /// <summary>
        /// 精英化到这一等级所需材料
        /// </summary>
        public List<EvolveCostItem> evolveCost { get; set; }
    }

    public class EvolveCostItem
    {
        /// <summary>
        /// 材料名称
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 材料数量
        /// </summary>
        public int count { get; set; }
    }

    public class UnlockCond
    {
        /// <summary>
        /// 精英化程度
        /// </summary>
        public int phase { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public int level { get; set; }
    }

    public class LevelUpCostItem
    {
        /// <summary>
        /// 材料名称
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 材料数量
        /// </summary>
        public int count { get; set; }
    }

    public class LevelUpCostCondItem
    {
        /// <summary>
        /// 专精需要的精英化程度和等级
        /// </summary>
        public UnlockCond unlockCond { get; set; }
        /// <summary>
        /// 专精需要的时间
        /// </summary>
        public int lvlUpTime { get; set; }
        /// <summary>
        /// 专精需要的材料
        /// </summary>
        public List<LevelUpCostItem> levelUpCost { get; set; }
    }

    public class SkillsItem
    {
        /// <summary>
        /// 技能名称
        /// </summary>
        public string skillId { get; set; }
        /// <summary>
        /// 技能升级消耗
        /// </summary>
        public List<LevelUpCostCondItem> levelUpCostCond { get; set; }
    }

    public class CandidatesItem
    {
        /// <summary>
        /// 解锁需要精英化程度和等级
        /// </summary>
        public UnlockCond unlockCondition { get; set; }
        /// <summary>
        /// 解锁需要潜能等级
        /// </summary>
        public int requiredPotentialRank { get; set; }
        /// <summary>
        /// 天赋名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 天赋描述
        /// </summary>
        public string description { get; set; }
    }

    public class TalentsItem
    {
        /// <summary>
        /// 天赋详情
        /// </summary>
        public List<CandidatesItem> candidates { get; set; }
    }

    public class PotentialRanksItem
    {
        /// <summary>
        /// 潜能描述
        /// </summary>
        public string description { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 最大血量
        /// </summary>
        public int maxHp { get; set; }
        /// <summary>
        /// 攻击力
        /// </summary>
        public int atk { get; set; }
        /// <summary>
        /// 防御力
        /// </summary>
        public int def { get; set; }
        /// <summary>
        /// 法抗
        /// </summary>
        public double magicResistance { get; set; }
        /// <summary>
        /// 部署费用
        /// </summary>
        public int cost { get; set; }
        /// <summary>
        /// 阻挡数
        /// </summary>
        public int blockCnt { get; set; }
        /// <summary>
        /// 攻击速度
        /// </summary>
        public double attackSpeed { get; set; }
        /// <summary>
        /// 基础攻击间隔
        /// </summary>
        public double baseAttackTime { get; set; }
        /// <summary>
        /// 再部署时间
        /// </summary>
        public int respawnTime { get; set; }
        /// <summary>
        /// 每秒回复技力
        /// </summary>
        public double spRecoveryPerSec { get; set; }
        /// <summary>
        /// 占用部署位
        /// </summary>
        public int maxDeployCount { get; set; }
        /// <summary>
        /// 嘲讽等级，优先被攻击等级
        /// </summary>
        public int tauntLevel { get; set; }
    }

    public class FavorKeyFramesItem
    {
        /// <summary>
        /// 当前数值的等级
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 当前等级的数值信息
        /// </summary>
        public Data data { get; set; }
    }

    public class LvlUpCostItem
    {
        /// <summary>
        /// 材料名称
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 材料数量
        /// </summary>
        public int count { get; set; }
    }

    public class AllSkillLvlupItem
    {
        /// <summary>
        /// 解锁条件
        /// </summary>
        public UnlockCond unlockCond { get; set; }
        /// <summary>
        /// 升级消耗
        /// </summary>
        public List<LvlUpCostItem> lvlUpCost { get; set; }
    }

    public class ModeleItem
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 能否使用通用信物升潜能
        /// </summary>
        public string canUseGeneralPotentialItem { get; set; }
        /// <summary>
        /// 所属国家
        /// </summary>
        public string nationId { get; set; }
        /// <summary>
        /// 所属组织
        /// </summary>
        public string groupId { get; set; }
        /// <summary>
        /// 所属团队
        /// </summary>
        public string teamId { get; set; }
        /// <summary>
        /// 情报编号
        /// </summary>
        public string displayNumber { get; set; }
        /// <summary>
        /// 干员外文名
        /// </summary>
        public string appellation { get; set; }
        /// <summary>
        /// 位置：高台和地面
        /// </summary>
        public string position { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public List<string> tagList { get; set; }
        /// <summary>
        /// 招聘合同描述
        /// </summary>
        public string itemUsage { get; set; }
        /// <summary>
        /// 招聘合同描述补充
        /// </summary>
        public string itemDesc { get; set; }
        /// <summary>
        /// 信物获取途径
        /// </summary>
        public string itemObtainApproach { get; set; }
        /// <summary>
        /// 信物是否可获得
        /// </summary>
        public string isNotObtainable { get; set; }
        /// <summary>
        /// 是异格角色
        /// </summary>
        public string isSpChar { get; set; }
        /// <summary>
        /// 最大潜能等级
        /// </summary>
        public int maxPotentialLevel { get; set; }
        /// <summary>
        /// 稀有度为实际稀有度 - 1
        /// </summary>
        public int rarity { get; set; }
        /// <summary>
        /// 主职业
        /// </summary>
        public string profession { get; set; }
        /// <summary>
        /// 职业分支
        /// </summary>
        public string subProfessionId { get; set; }
        /// <summary>
        /// 精英化相关数据（不包含信赖加成）
        /// </summary>
        public List<PhasesItem> phases { get; set; }
        /// <summary>
        /// 技能专精材料
        /// </summary>
        public List<SkillsItem> skills { get; set; }
        /// <summary>
        /// 天赋
        /// </summary>
        public List<TalentsItem> talents { get; set; }
        /// <summary>
        /// 潜能效果
        /// </summary>
        public List<PotentialRanksItem> potentialRanks { get; set; }
        /// <summary>
        /// 信赖加成
        /// </summary>
        public List<FavorKeyFramesItem> favorKeyFrames { get; set; }
        /// <summary>
        /// 所有技能的升级材料需要
        /// </summary>
        public List<AllSkillLvlupItem> allSkillLvlup { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ModeleItem> Modele { get; set; }
    }

}
