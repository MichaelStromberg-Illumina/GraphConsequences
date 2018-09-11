using VariantAnnotation.Interface.AnnotatedPositions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A transcript variant of a protein coding gene.
    // SO:0001968
    public class CodingTranscriptVariant : IOntologyNode
    {
        public bool IsActive { get; private set; }
        public bool AreAllParentsActive { get; private set; }
        public ConsequenceTag Consequence { get; } = ConsequenceTag.coding_transcript_variant;
        public IOntologyNode[] Children { get; }

        public CodingTranscriptVariant(IOntologyNode[] children) => Children = children;

        public void Evaluate(INodeData data)
        {
            if (data.Transcript.Translation != null) IsActive = true;
        }

        public void Register(ConsequenceTag parentConsequence)
        {
            if (parentConsequence == ConsequenceTag.transcript_variant) AreAllParentsActive = true;
        }
    }
}
