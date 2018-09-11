using VariantAnnotation.Interface.AnnotatedPositions;
using VariantAnnotation.Interface.Positions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A sequence_variant which is predicted to change the protein encoded in the coding sequence.
    // SO:0001818
    public class ProteinAlteringVariant : IOntologyNode
    {
        public bool IsActive { get; private set; }
        public bool AreAllParentsActive { get; private set; }
        public ConsequenceTag Consequence { get; } = ConsequenceTag.protein_altering_variant;
        public IOntologyNode[] Children { get; }

        public ProteinAlteringVariant(IOntologyNode[] children) => Children = children;

        public void Evaluate(INodeData data)
        {
            if (data.Variant.Type != VariantType.MNV && data.Variant.Type != VariantType.SNV)
            {
                IsActive = true;
                return;
            }

            if (data.ReferenceAminoAcids != data.AlternateAminoAcids) IsActive = true;
        }

        public void Register(ConsequenceTag parentConsequence)
        {
            if (parentConsequence == ConsequenceTag.coding_sequence_variant) AreAllParentsActive = true;
        }
    }
}
