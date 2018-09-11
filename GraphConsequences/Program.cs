using System;
using System.Collections.Generic;
using Moq;
using VariantAnnotation.Interface.AnnotatedPositions;
using VariantAnnotation.Interface.Positions;

namespace GraphConsequences
{
    class Program
    {
        private static int GetProteinPosition(int cdsPosition)
        {
            if (cdsPosition == -1) return -1;
            return (cdsPosition + 2) / 3;
        }

        static void Main()
        {
            var rootNode       = ConsequenceGraphFactory.Build();
            var mappedPosition = new MappedPosition(132, 141, 108, -1, 36, -1, 2, 2, -1, -1, 8, 8);
            var consequences   = new List<ConsequenceTag>();

            var transcriptRegions = new ITranscriptRegion[11];
            transcriptRegions[8] = new TranscriptRegion(TranscriptRegionType.Exon, 2, 174517971, 174518077, 118, 224);

            var codingRegion = new CodingRegion(174518057, 174522451, 25, 138, 114);
            var translation = new Translation(codingRegion, CompactId.Empty, null);

            var transcript = new Mock<ITranscript>();
            transcript.SetupGet(x => x.Start).Returns(10);
            transcript.SetupGet(x => x.TranscriptRegions).Returns(transcriptRegions);
            transcript.SetupGet(x => x.Translation).Returns(translation);

            var variant = new Mock<IVariant>();
            variant.SetupGet(x => x.Start).Returns(174518054);
            variant.SetupGet(x => x.End).Returns(174518063);
            variant.SetupGet(x => x.RefAllele).Returns("GGTCTACAAC");
            variant.SetupGet(x => x.AltAllele).Returns("TG");
            variant.SetupGet(x => x.Type).Returns(VariantType.indel);

            INodeData data = new NodeData();
            data.Assign(variant.Object, transcript.Object, mappedPosition, 108, 117, "", "", GetProteinPosition(108), GetProteinPosition(117));

            try
            {
                rootNode.IsNodeActive(ConsequenceTag.transcript_variant, consequences, data);
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nCONSEQUENCES:");
            Console.ResetColor();

            foreach(var consequence in consequences) Console.WriteLine($"- {consequence}");
        }
    }
}
