using System;
using System.Collections.Generic;
using VariantAnnotation.Interface.AnnotatedPositions;

namespace GraphConsequences
{
    public static class NodeUtilities
    {
        public static bool IsNodeActive(this IOntologyNode node, ConsequenceTag parentConsequence,
            List<ConsequenceTag> consequences, INodeData data)
        {
            Console.WriteLine($"Entering {node.Consequence} (from {parentConsequence})");
            node.Register(parentConsequence);

            if (!node.AreAllParentsActive)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("- Not all parents are active.");
                Console.ResetColor();
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("- All parents active.");
            Console.ResetColor();

            if (!node.IsActive) node.Evaluate(data);

            if (node.IsActive)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("- Active.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("- Not active.");
                Console.ResetColor();
                return false;
            }

            bool hasActiveChildren = false;

            if (node.Children != null)
            {
                foreach (var child in node.Children)
                {
                    bool isActive = child.IsNodeActive(node.Consequence, consequences, data);
                    if (isActive) hasActiveChildren = true;
                }
            }

            if (hasActiveChildren)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"- {node.Consequence} has active children.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"- {node.Consequence} does not have active children.");
                Console.ResetColor();
                consequences.Add(node.Consequence);
            }

            return true;
        }
    }
}
