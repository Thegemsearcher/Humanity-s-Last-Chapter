using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehvaiourTree : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public RootNode GetPcBt()
    {
        List<Node> nodes = new List<Node>();

        #region combat
        LeafNode inCombatRange = new LeafNode(GetComponent<PlayerAttack>().InCombatRange);
        LeafNode isRanged = new LeafNode(GetComponent<PlayerAttack>().IsRanged);
        LeafNode atkMelee = new LeafNode(GetComponent<PlayerAttack>().MeleeAttack);
        LeafNode atkRanged = new LeafNode(GetComponent<PlayerAttack>().RangeAttack);
        LeafNode lineOfSight = new LeafNode(GetComponent<PlayerAttack>().LineOfSight);
        List<Node> forMeleeSelector = new List<Node>();
        forMeleeSelector.Add(isRanged);
        forMeleeSelector.Add(atkMelee);
        Selector meleeSelector = new Selector(forMeleeSelector);
        List<Node> forCombatSequence = new List<Node>();
        forCombatSequence.Add(inCombatRange);
        forCombatSequence.Add(meleeSelector);
        forCombatSequence.Add(lineOfSight);
        forCombatSequence.Add(atkRanged);
        Sequence forCombat = new Sequence(forCombatSequence);
        #endregion

        nodes.Add(forCombat);


        RootNode toReturn = new RootNode(nodes);
        return toReturn;
    }

}
/// <summary>
/// startar processen, går igenom alla noder och kör deras evaluates.
/// 
/// OBS! endast de noderna som ska vara direkt kopplade till rot-noden ska vara i input-listan OCH DE KOMMER ALLA KÖRAS!
/// </summary>
public class RootNode
{
    List<Node> children = new List<Node>();
    public RootNode(List<Node> nodes)
    {
        children = nodes;
    }
    public void Start()
    {
        foreach (Node node in children)
        {
            node.Evaluate();
        }
    }
}
public abstract class Node
{
    public enum NodeStates
    {
        fail,
        success,
        running
    }
    protected NodeStates nodeState;
    public NodeStates getNodeState
    {
        get { return nodeState; }
    }
    public Node()
    {
    }
    public abstract NodeStates Evaluate();
}
/// <summary>
/// Tar en lista av nodes, itererar igenom listan och om någonting blir success så returnar den success och slutar
/// iterera igenom listan. om någonting är running så skickar den tillbaks running
/// </summary>
public class Selector : Node
{
    protected List<Node> children = new List<Node>();
    public Selector(List<Node> nodes) 
    {
        children = nodes;
    }
    public override NodeStates Evaluate()
    {
        foreach (Node node in children)
        {
            switch (node.Evaluate())
            {
                case NodeStates.fail:
                    continue;
                case NodeStates.success:
                    nodeState = NodeStates.success;
                    return nodeState;
                case NodeStates.running:
                    nodeState = NodeStates.running;
                    return nodeState;
                default:
                    continue;
            }
        }
        nodeState = NodeStates.fail;
        return nodeState;
    }
}
/// <summary>
/// Tar en lista av nodes och itererar igenom dem, om någonting returnar fail så returnar även denna fail och
/// avslutar sin iteration genom listan. Om running så returnar den running.
/// </summary>
public class Sequence : Node
{
    protected List<Node> children = new List<Node>();
    public Sequence(List<Node> nodes)
    {
        children = nodes;
    }
    public override NodeStates Evaluate()
    {
        bool anyChildRunning = false;

        foreach (Node node in children)
        {
            switch (node.Evaluate())
            {
                case NodeStates.fail:
                    nodeState = NodeStates.fail;
                    return nodeState;
                case NodeStates.success:
                    continue;
                case NodeStates.running:
                    anyChildRunning = true;
                    continue;
                default:
                    nodeState = NodeStates.success;
                    return nodeState;
            }
        }
        nodeState = anyChildRunning ? NodeStates.running : NodeStates.success;
        return nodeState;
    }
}
/// <summary>
/// tar en node och byter dens return värde: node.success = fail. node.fail = success. Annars running
/// </summary>
public class Inverter : Node
{
    protected Node child;
    public Inverter(Node node)
    {
        child = node;
    }
    public override NodeStates Evaluate()
    {
        switch (child.Evaluate())
        {
            case NodeStates.fail:
                nodeState = NodeStates.success;
                return nodeState;
            case NodeStates.success:
                nodeState = NodeStates.fail;
                return nodeState;
            case NodeStates.running:
                nodeState = NodeStates.running;
                return nodeState;
        }
        nodeState = NodeStates.success;
        return nodeState;
    }
}
/// <summary>
/// In parametern är ett delegate, alltså typ en metod, den metoden måste ha returnvärdet NodeStates
/// </summary>
public class LeafNode : Node
{
    public delegate NodeStates leafNodeDelegate();
    private leafNodeDelegate runAction;

    /// <summary>
    /// OBS! inparametern ska vara en metod med returnvärdet NodeStates
    /// </summary>
    /// <param name="action"></param>
    public LeafNode(leafNodeDelegate action)
    {
        runAction = action;
    }
    public override NodeStates Evaluate()
    {
        switch (runAction())
        {
            case NodeStates.success:
                nodeState = NodeStates.success;
                return nodeState;
            case NodeStates.fail:
                nodeState = NodeStates.fail;
                return nodeState;
            case NodeStates.running:
                nodeState = NodeStates.running;
                return nodeState;
            default:
                nodeState = NodeStates.fail;
                return nodeState;
        }
    }
}
    

