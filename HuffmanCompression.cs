using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

public class HuffmanCompression
{
    public class HuffmanNode
    {
        public byte Value { get; set; }
        public int Frequency { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }
    }

    private class HuffmanCode
    {
        public byte Value { get; set; }
        public string Code { get; set; }
    }

    public static Dictionary<byte, int> CountDataFrequencies(byte[] data)
    {
        Dictionary<byte, int> frequencies = new Dictionary<byte, int>();

        foreach (byte chunk in data)
        {
            if (frequencies.ContainsKey(chunk))
            {
                frequencies[chunk]++;
            }
            else
            {
                frequencies[chunk] = 1;
            }
        }

        return frequencies;

    }


    public static HuffmanNode BuildHuffmanTree(Dictionary<byte, int> frequencies)
    {
        PriorityQueue<HuffmanNode, int> priorityQueue = new PriorityQueue<HuffmanNode, int>();

        foreach (KeyValuePair<byte, int> kvp in frequencies)
        {
            HuffmanNode node = new HuffmanNode { Value = kvp.Key, Frequency = kvp.Value };
            priorityQueue.Enqueue(node, kvp.Value);
        }

        while (priorityQueue.Count > 1)
        {
            HuffmanNode left = priorityQueue.Dequeue();
            HuffmanNode right = priorityQueue.Dequeue();

            HuffmanNode parent = new HuffmanNode
            {
                Value = 0,
                Frequency = left.Frequency + right.Frequency,
                Left = left,
                Right = right
            };

            priorityQueue.Enqueue(parent, parent.Frequency);
        }

        return priorityQueue.Dequeue();
    }

    public static Dictionary<byte, string> GenerateHuffmanCodes(HuffmanNode root)
    {
        Dictionary<byte, string> huffmanCodes = new Dictionary<byte, string>();
        GenerateHuffmanCodesRecursive(root, "", huffmanCodes);
        return huffmanCodes;
    }

    private static void GenerateHuffmanCodesRecursive(HuffmanNode node, string code, Dictionary<byte, string> huffmanCodes)
    {
        if (node.Left == null && node.Right == null)
        {
            huffmanCodes[node.Value] = code;
        }
        else
        {
            GenerateHuffmanCodesRecursive(node.Left, code + "0", huffmanCodes);
            GenerateHuffmanCodesRecursive(node.Right, code + "1", huffmanCodes);
        }
    }

    public static BitArray CompressData(byte[] data, Dictionary<byte, string> huffmanCodes)
    {
        List<bool> compressedDataBits = new List<bool>();

        foreach (byte pixelValue in data)
        {
            string huffmanCode = huffmanCodes[pixelValue];
            foreach (char bit in huffmanCode)
            {
                compressedDataBits.Add(bit == '1');
            }
        }

        return new BitArray(compressedDataBits.ToArray());
    }

    public static byte[] DecompressData(BitArray compressedData, Dictionary<string, byte> huffmanCodes, int originalDataLength)
    {
        List<byte> decompressedData = new List<byte>();
        string kod = "";
        byte value;
        foreach (bool bit in compressedData)
        {
            kod += bit ? "1" : "0";
            if(huffmanCodes.TryGetValue(kod, out value))
            {
                decompressedData.Add(value);
                kod = "";
            }
        }

        return decompressedData.ToArray();
    }


}