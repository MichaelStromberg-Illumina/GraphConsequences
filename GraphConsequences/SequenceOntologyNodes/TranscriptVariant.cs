using VariantAnnotation.Interface.AnnotatedPositions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A sequence variant that changes the structure of the transcript.
    // SO:0001576
    public class TranscriptVariant : IOntologyNode
    {
        // always active in Nirvana
        public bool IsActive { get; } = true;
        public bool AreAllParentsActive { get; } = true;
        public ConsequenceTag Consequence { get; } = ConsequenceTag.transcript_variant;
        public IOntologyNode[] Children { get; }

        public TranscriptVariant(IOntologyNode[] children) => Children = children;

        public void Evaluate(INodeData data) {}
        public void Register(ConsequenceTag parentConsequence) {}
    }
}
