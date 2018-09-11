using VariantAnnotation.Interface.AnnotatedPositions;
using VariantAnnotation.Interface.Positions;

namespace GraphConsequences
{
    public class NodeData : INodeData
    {
        public IVariant Variant { get; private set; }
        public ITranscript Transcript { get; private set; }
        public IMappedPosition MappedPosition { get; private set; }
        public int CoveredCdsStart { get; private set; }
        public int CoveredCdsEnd { get; private set; }
        public int CoveredProteinStart { get; private set; }
        public int CoveredProteinEnd { get; private set; }
        public string ReferenceAminoAcids { get; private set; }
        public string AlternateAminoAcids { get; private set; }

        public void Assign(IVariant variant, ITranscript transcript, IMappedPosition mappedPosition,
            int coveredCdsStart, int coveredCdsEnd, string referenceAminoAcids, string alternateAminoAcids, int coveredProteinStart, int coveredProteinEnd)
        {
            Variant             = variant;
            Transcript          = transcript;
            MappedPosition      = mappedPosition;
            CoveredCdsStart     = coveredCdsStart;
            CoveredCdsEnd       = coveredCdsEnd;
            ReferenceAminoAcids = referenceAminoAcids;
            AlternateAminoAcids = alternateAminoAcids;
            CoveredProteinStart = coveredProteinStart;
            CoveredProteinEnd   = coveredProteinEnd;
        }
    }
}
