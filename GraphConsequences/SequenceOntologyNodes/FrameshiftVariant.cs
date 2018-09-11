using System;
using VariantAnnotation.Interface.AnnotatedPositions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A sequence variant which causes a disruption of the translational reading 
    // frame, because the number of nucleotides inserted or deleted is not a 
    // multiple of three.
    // SO:0001589
    public class FrameshiftVariant : IOntologyNode
    {
        public bool IsActive { get; private set; }
        public bool AreAllParentsActive { get; private set; }
        public ConsequenceTag Consequence { get; } = ConsequenceTag.frameshift_variant;
        public IOntologyNode[] Children { get; } = null;

        public void Evaluate(INodeData data)
        {
            if (IsFrameshift(data.CoveredCdsStart, data.CoveredCdsEnd, data.Variant.AltAllele.Length)) IsActive = true;
        }

        public static bool IsFrameshift(int coveredCdsStart, int coveredCdsEnd, int altAlleleLen)
        {
            var varLen = coveredCdsEnd - coveredCdsStart + 1;
            Console.WriteLine($"  - CDS: {coveredCdsStart}-{coveredCdsEnd} frameshift: varLen: {varLen}, altAlleleLen: {altAlleleLen}");
            return Math.Abs(altAlleleLen - varLen) % 3 != 0;
        }

        public void Register(ConsequenceTag parentConsequence)
        {
            if (parentConsequence == ConsequenceTag.protein_altering_variant) AreAllParentsActive = true;
        }
    }
}
