using VariantAnnotation.Interface.AnnotatedPositions;
using VariantAnnotation.Interface.IO;

namespace GraphConsequences
{
    public class CodingRegion : ICodingRegion
    {
        public int Start { get; }
        public int End { get; }
        public int CdnaStart { get; }
        public int CdnaEnd { get; }
        public int Length { get; }

        public CodingRegion(int start, int end, int cdnaStart, int cdnaEnd, int length)
        {
            Start     = start;
            End       = end;
            CdnaStart = cdnaStart;
            CdnaEnd   = cdnaEnd;
            Length    = length;
        }

        public void Write(IExtendedBinaryWriter writer)
        {
            writer.WriteOpt(Start);
            writer.WriteOpt(End);
            writer.WriteOpt(CdnaStart);
            writer.WriteOpt(CdnaEnd);
            writer.WriteOpt(Length);
        }
    }
}
