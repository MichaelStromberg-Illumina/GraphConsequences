using VariantAnnotation.Interface.AnnotatedPositions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A transcript variant occurring within an intron.
    // SO:0001627
    public class IntronVariant : IOntologyNode
    {
        public bool IsActive { get; private set; }
        public bool AreAllParentsActive { get; private set; }
        public ConsequenceTag Consequence { get; } = ConsequenceTag.intron_variant;
        public IOntologyNode[] Children { get; }

        public IntronVariant(IOntologyNode[] children) => Children = children;

        public void Evaluate(INodeData data)
        {
            if (data.MappedPosition.IntronStart != -1 || data.MappedPosition.IntronEnd != -1) IsActive = true;
        }

        public void Register(ConsequenceTag parentConsequence)
        {
            if (parentConsequence == ConsequenceTag.transcript_variant) AreAllParentsActive = true;
        }
    }
}
