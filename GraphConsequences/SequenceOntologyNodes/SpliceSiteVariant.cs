using System;
using VariantAnnotation.Interface.AnnotatedPositions;

namespace GraphConsequences.SequenceOntologyNodes
{
    // A sequence variant that changes the first two or last two bases of an intron, 
    // or the 5th base from the start of the intron in the orientation of the transcript.
    //
    // EBI term - essential splice site - In the first 2 or the last 2 base pairs of an
    // intron. The 5th base is on the donor (5') side of the intron. Updated to be in line 
    // with Cancer Genome Project at the Sanger.
    // SO:0001629
    public class SpliceSiteVariant : IOntologyNode
    {
        public bool IsActive { get; }
        public bool AreAllParentsActive { get; }
        public ConsequenceTag Consequence { get; } = ConsequenceTag.splice_site_variant;
        public IOntologyNode[] Children { get; } = null;

        public void Evaluate(INodeData data)
        {
            throw new NotImplementedException();
        }

        public void Register(ConsequenceTag parentConsequence)
        {
            throw new NotImplementedException();
        }
    }
}
