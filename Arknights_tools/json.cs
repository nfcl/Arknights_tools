using System;
using System.Collections.Generic;
using System.Text;

namespace json_real
{
    /// <summary>
    /// <para>可合成材料（直译）</para>
    /// <para>特指固源岩等材料（包括了技能书）</para>
    /// </summary>
    public class CompositableItem
    {
        /// <summary>
        /// 材料中文名字
        /// </summary>
        public string Ch_Name { get; set; }
        /// <summary>
        /// 材料英文名字
        /// </summary>
        public string En_Name { get; set; }
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

    public class ChipItem
    {
        /// <summary>
        /// 材料中文名字
        /// </summary>
        public string Ch_Name { get; set; }
        /// <summary>
        /// 材料英文名字
        /// </summary>
        public string En_Name { get; set; }
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
        public List<CompositableItem> Compositable { get; set; }
        public List<ChipItem> chip { get; set; }
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

    public class SkillDescribleItem
    {
        /// <summary>
        /// 当前等级技能描述
        /// </summary>
        public string describle { get; set; }
        /// <summary>
        /// 当前等级技能初始技力
        /// </summary>
        public int? start { get; set; }
        /// <summary>
        /// 当前等级技能消耗技力
        /// </summary>
        public int? deplete { get; set; }
        /// <summary>
        /// 当前等级技能持续时间
        /// </summary>
        public int? continued { get; set; }
    }

    public class SkillsItem
    {
        /// <summary>
        /// 技能名字（中文）
        /// </summary>
        public string skillname { get; set; }
        /// <summary>
        /// 技能图片名称
        /// </summary>
        public string skillId { get; set; }
        /// <summary>
        /// <para/>技能描述
        /// <para/>按顺序为1-7级 专精1，2，3
        /// <para/>因此存在1星和2星干员没有技能所以该成员数量为0
        /// <para/>3星没有精二所以成员数量为7
        /// <para/>正常（有不正常的吗？）4星，5星6星成员数量为10
        /// </summary>
        public List<SkillDescribleItem> skillDescrible { get; set; }
        /// <summary>
        /// 技能回复类型
        /// </summary>
        public string replykind { get; set; }
        /// <summary>
        /// 技能触发方式
        /// </summary>
        public string triggerkind { get; set; }
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

    public class SkinItem
    {
        /// <summary>
        /// 时装名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string picture_name { get; set; }
        /// <summary>
        /// 是精英化时装
        /// </summary>
        public bool is_phase { get; set; }
        /// <summary>
        /// 时装描述
        /// </summary>
        public string describle { get; set; }
        /// <summary>
        /// 时装系列
        /// </summary>
        public string series { get; set; }
        /// <summary>
        /// 时装颜色
        /// </summary>
        public string color { get; set; }
    }

    public class Char_infoItem
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// <para/>用于筛选
        /// <para/>从低位到高位分别为
        /// <para/>职业：先锋 近卫 重装 狙击 术士 医疗 辅助 特种
        /// <para/>稀有度：1星 2星 3星 4星 5星 6星
        /// <para/>tag：新手 治疗 支援 输出 群攻 减速 生存 防护 削弱 位移 控场 爆发 召唤 快速复活 费用回复
        /// </summary>
        public int tagIdnum { get; set; }
        /// <summary>
        /// 实装顺序
        /// </summary>
        public int ImplementationOrder { get; set; }
        /// <summary>
        /// 时装
        /// </summary>
        public List<SkinItem> Skins { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 能否使用通用信物升潜能
        /// </summary>
        public bool canUseGeneralPotentialItem { get; set; }
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
        public bool isNotObtainable { get; set; }
        /// <summary>
        /// 是异格角色
        /// </summary>
        public bool isSpChar { get; set; }
        /// <summary>
        /// 最大潜能等级
        /// </summary>
        public int maxPotentialLevel { get; set; }
        /// <summary>
        /// 稀有度为实际稀有度 - 1
        /// </summary>
        public int rarity { get; set; }
        /// <summary>
        /// 主职业(英)
        /// </summary>
        public string Profession_En { get; set; }
        /// <summary>
        /// 主职业(中)
        /// </summary>
        public string Profession_Ch { get; set; }
        /// <summary>
        /// 职业分支(英)
        /// </summary>
        public string SubProfessionId_En { get; set; }
        /// <summary>
        /// 职业分支(中)
        /// </summary>
        public string SubProfessionId_Ch { get; set; }
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

    public class Root_CharTable
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Char_infoItem> char_info { get; set; }
    }
    // ------------------------------------------------------------------------------------------------------------------

    // ------------------------------------------------------------------------------------------------------------------
    public class CharacterItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Picname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Qban { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Camp { get; set; }
        /// <summary>
        /// 阿米娅
        /// </summary>
        public string Ch_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string En_name { get; set; }
    }

    public class Root_character
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> Campname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<CharacterItem> Character { get; set; }
    }
}
