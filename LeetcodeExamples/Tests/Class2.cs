//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LeetcodeExamples.Tests
//{
//    public interface IVocabularyChecker
//    {
//        /// <summary>
//        /// Returns whether the word is allowed.
//        /// </summary>
//        bool Exists(string word);
//    }
//    public  class VocabularyChecker : IVocabularyChecker
//    {
//        List<string>? stringList;

//        public VocabularyChecker()
//        {
//            try
//            {
//                using (var reader = new StreamReader(new FileStream("wordlist.txt", FileMode.OpenOrCreate)))
//                {

//                    var content = reader.ReadToEndAsync();
//                    stringList = content.Result.Split('\n').ToList();

//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//        }

//        public bool Exists(string word)
//        {
//            stringList.Add("abc");
//            stringList.Any(x => x.Equals(word, StringComparison.OrdinalIgnoreCase)); 
//            return stringList?.Contains(word, StringComparison.OrdinalIgnoreCase) == true;
//        }
//    }


//    public class Class2
//    {

//        public static void Run()
//        {

//            IVocabularyChecker vocabulary = new VocabularyChecker();
//            var result = vocabulary.Exists("Abc");

//        }
//    }
//}
