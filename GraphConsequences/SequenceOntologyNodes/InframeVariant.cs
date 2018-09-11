using System;
using VariantAnnotation.Interface.AnnotatedPositions;
using VariantAnnotation.Interface.Positions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A sequence variant which does not cause a disruption of the translational reading frame.
    // SO:0001650
    public class InframeVariant : IOntologyNode
    {
        public bool IsActive { get; private set; }
        public bool AreAllParentsActive { get; private set; }
        public ConsequenceTag Consequence { get; } = ConsequenceTag.inframe_variant;
        public IOntologyNode[] Children { get; }

        public InframeVariant(IOntologyNode[] children) => Children = children;

        public void Evaluate(INodeData data)
        {
            if (!FrameshiftVariant.IsFrameshift(data.CoveredCdsStart, data.CoveredCdsEnd, data.Variant.AltAllele.Length)) IsActive = true;
        }

        public void Register(ConsequenceTag parentConsequence)
        {
            if (parentConsequence == ConsequenceTag.protein_altering_variant) AreAllParentsActive = true;
        }
    }
}
