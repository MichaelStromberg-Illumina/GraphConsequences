using VariantAnnotation.Interface.AnnotatedPositions;
using VariantAnnotation.Interface.Positions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A sequence variant that causes the extension of a genomic feature, with 
    // regard to the reference sequence.
    // SO:0001907
    public class FeatureElongation : IOntologyNode
    {
        public bool IsActive { get; private set; }
        public bool AreAllParentsActive { get; private set; }
        public ConsequenceTag Consequence { get; } = ConsequenceTag.feature_elongation;
        public IOntologyNode[] Children { get; }

        public FeatureElongation(IOntologyNode[] children) => Children = children;

        public void Evaluate(INodeData data)
        {
            if (data.Variant.Type == VariantType.MNV || data.Variant.Type == VariantType.SNV) return;

            bool isLarger = data.Variant.RefAllele.Length < data.Variant.AltAllele.Length;
            if (isLarger) IsActive = true;
        }

        public void Register(ConsequenceTag parentConsequence)
        {
            if (parentConsequence == ConsequenceTag.transcript_variant) AreAllParentsActive = true;
        }
    }
}
