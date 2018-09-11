using VariantAnnotation.Interface.AnnotatedPositions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A transcript variant of a non coding RNA gene.
    // SO:0001619
    public class NonCodingTranscriptVariant : IOntologyNode
    {
        public bool IsActive { get; private set; }
        public bool AreAllParentsActive { get; private set; }
        public ConsequenceTag Consequence { get; } = ConsequenceTag.non_coding_transcript_variant;
        public IOntologyNode[] Children { get; } = null;

        public void Evaluate(INodeData data)
        {
            if (data.Transcript.Translation == null) IsActive = true;
        }

        public void Register(ConsequenceTag parentConsequence)
        {
            if (parentConsequence == ConsequenceTag.transcript_variant) AreAllParentsActive = true;
        }
    }
}
