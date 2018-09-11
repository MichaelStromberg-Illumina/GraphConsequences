using VariantAnnotation.Interface.AnnotatedPositions;

namespace GraphConsequences
{
    public interface IOntologyNode
    {
        bool IsActive { get; }
        bool AreAllParentsActive { get; }
        ConsequenceTag Consequence { get; }
        IOntologyNode[] Children { get; }
        void Evaluate(INodeData data);
        void Register(ConsequenceTag parentConsequence);
    }
}
