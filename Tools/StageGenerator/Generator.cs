﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageGenerator
{
    public class Generator
    {


        public void Generate(string inputFileName)
        {
            if (!inputFileName.EndsWith(".def"))
            {
                Console.WriteLine("Input file name must ends with .def");
                return;
            }

            string outputFileName = inputFileName.Replace(".def", ".json");

            string content = string.Empty;
            using (StreamReader reader = new StreamReader(inputFileName))
            {
                content = reader.ReadToEnd();
            }

            StageDefinition stage = JsonConvert.DeserializeObject<StageDefinition>(content);

            stage.Poem.Title = EncodeCharactersToUnicode(stage.Poem.Title);
            stage.Poem.Author = EncodeCharactersToUnicode(stage.Poem.Author);
            
            for(int line = 0; line < stage.Poem.Content.Count; line++)
            {
                stage.Poem.Content[line] = EncodeCharactersToUnicode(stage.Poem.Content[line]);
            }

            stage.Puzzle.NoiseCharacters = EncodeCharactersToUnicode(stage.Puzzle.NoiseCharacters);

            for (int line = 0; line < stage.Formulas.Count; line++)
            {
                stage.Formulas[line] = EncodeCharactersToUnicode(stage.Formulas[line]);
            }


            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                writer.Write(JsonConvert.SerializeObject(stage, Formatting.Indented));

            }
        }

        private List<string> EncodeCharactersToUnicode(List<string> originList)
        {
            List<string> resultList = new List<string>(originList.Count);

            foreach(string character in originList)
            {
                if (character.StartsWith("~"))
                {
                    resultList.Add(character.Substring(1));
                }
                else
                {
                    // read the string as UTF-8 bytes.
                    byte[] encodedBytes = Encoding.UTF8.GetBytes(character);

                    // convert them into unicode bytes.
                    byte[] unicodeBytes = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                    string unicodeString = UnicodeBytesToString(unicodeBytes);
                    resultList.Add(unicodeString);
                }
            }

            return resultList;
        }
        
        static private string UnicodeBytesToString(byte[] value)
        {
            StringBuilder hex = new StringBuilder(4);
            hex.AppendFormat("{0:x2}", value[1]);
            hex.AppendFormat("{0:x2}", value[0]);
            return hex.ToString();
        }
    }
}
