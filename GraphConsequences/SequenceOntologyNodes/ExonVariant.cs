using VariantAnnotation.Interface.AnnotatedPositions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A sequence variant that changes exon sequence.
    // SO:0001791
    public class ExonVariant : IOntologyNode
    {
        public bool IsActive { get; private set; }
        public bool AreAllParentsActive { get; private set; }
        public ConsequenceTag Consequence { get; } = ConsequenceTag.exon_variant;
        public IOntologyNode[] Children { get; }

        public ExonVariant(IOntologyNode[] children) => Children = children;

        public void Evaluate(INodeData data)
        {
            if (data.MappedPosition.ExonStart != -1 || data.MappedPosition.ExonEnd != -1) IsActive = true;
        }

        public void Register(ConsequenceTag parentConsequence)
        {
            if (parentConsequence == ConsequenceTag.transcript_variant) AreAllParentsActive = true;
        }
    }
}
